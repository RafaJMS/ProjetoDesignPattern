using System.Collections.Generic;
using System.Linq;
using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.Observer;
using AlmoxarifadoServices.Services;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensNotaRepository : IItensNotaRepository
    {
        private readonly ContextSQL _context;
        private readonly EstoqueService _estoqueService;

        public ItensNotaRepository(ContextSQL pContext, EstoqueService estoqueService)
        {
            _context = pContext;
            _estoqueService = estoqueService;
        }

        public List<Itens_Nota> ObterTodosItensNota()
        {
            return _context.Itens_Nota.Select(i => new Itens_Nota
            {
                EST_LIN = i.EST_LIN,
                ID_NOTA = i.ID_NOTA,
                ID_PRO = i.ID_PRO,
                ID_SEC = i.ID_SEC,
                ITEM_NUM = i.ITEM_NUM,
                PRE_UNIT = i.PRE_UNIT,
                QTD_PRO = i.QTD_PRO,

            }).ToList();
        }

        public Itens_Nota CriarItemNota(Itens_Nota itemNota)
        {
            _context.Itens_Nota.Add(itemNota);
            _context.SaveChanges();

            var command = new EntradaEstoqueCommand(itemNota);
            _estoqueService.ExecutarComando(command);

            return itemNota;
        }

        public async Task<bool> UpdateItemNota(int itemNum, int IdPro, int IdNota, int IdSec, Itens_Nota itemNota)
        {
            var existingItemNota = await _context.Itens_Nota.FindAsync(itemNum, IdPro, IdNota, IdSec);

            if (existingItemNota == null)
            {
                return false;
            }

            existingItemNota.QTD_PRO = itemNota.QTD_PRO;
            existingItemNota.PRE_UNIT = itemNota.PRE_UNIT;
            existingItemNota.EST_LIN = itemNota.EST_LIN;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void DeleteItemNota(int itemNum, int IdPro, int IdNota, int IdSec)
        {
            var itemNota = _context.Itens_Nota.Find(itemNum, IdPro, IdNota, IdSec) ?? throw new Exception("Item de Nota fiscal não encontrada");
            _context.Itens_Nota.Remove(itemNota);
            _context.SaveChanges();
        }
    }
}
