using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Command;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Logging;
using AlmoxarifadoServices.Observer;
using AlmoxarifadoServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data
{
    public class ItensRequisicaoRepository : IItensRequisicaoRepository
    {
        private readonly ContextSQL _context;
        private readonly EstoqueService _estoqueService;
        private readonly ILogStrategy _logStrategy;

        public ItensRequisicaoRepository(ContextSQL contextSQL, EstoqueService estoqueService, ILogStrategy logStrategy)
        {
            _context = contextSQL;
            _estoqueService = estoqueService;
            _logStrategy = logStrategy;
        }
        public Itens_Requisicao CriarItemRequisicao(Itens_Requisicao itemRequisicao)
        {
            _context.Itens_Req.Add(itemRequisicao);
            _context.SaveChanges();
            
            var command = new SaidaEstoqueCommand(itemRequisicao, _logStrategy);
            _estoqueService.ExecutarComando(command);
            
            return itemRequisicao;
        }

        public void DeleteItemRequisicao(int NUM_ITEM, int ID_REQ, int ID_PRO, int ID_SEC)
        {
            var itemRequisicao = _context.Itens_Req.Find(NUM_ITEM, ID_REQ, ID_PRO, ID_SEC) ?? throw new Exception("Item de Requisicao não encontrado");
            _context.Itens_Req.Remove(itemRequisicao);
            _context.SaveChanges();
        }

        public List<Itens_Requisicao> ObterTodosItensRequisicao()
        {
            return _context.Itens_Req.Select(ir => new Itens_Requisicao 
            {
                ID_PRO = ir.ID_PRO,
                ID_REQ = ir.ID_REQ,
                ID_SEC = ir.ID_SEC,
                NUM_ITEM = ir.NUM_ITEM,
                PRE_UNIT = ir.PRE_UNIT,
                QTD_PRO = ir.QTD_PRO,
                TOTAL_REAL = ir.TOTAL_REAL,
            
            }).ToList();
        }

        public async Task<bool> UpdateItemRequisicaoAsync(int NUM_ITEM, int ID_REQ, int ID_PRO, int ID_SEC, Itens_Requisicao itemRequisicao)
        {
            var existingItemReq = await _context.Itens_Req.FindAsync(NUM_ITEM,ID_REQ,ID_PRO,ID_SEC);

            if(existingItemReq == null)
            {
                return false;
            }

            existingItemReq.PRE_UNIT = itemRequisicao.PRE_UNIT;
            existingItemReq.QTD_PRO = itemRequisicao.QTD_PRO;
            existingItemReq.TOTAL_REAL = itemRequisicao.TOTAL_REAL;
            

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
                throw;
            }
        }
    }
}
