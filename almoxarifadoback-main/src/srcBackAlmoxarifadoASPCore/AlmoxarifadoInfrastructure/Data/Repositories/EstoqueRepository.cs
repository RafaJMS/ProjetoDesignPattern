using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ContextSQL _context;

        public EstoqueRepository(ContextSQL context)
        {
            _context = context;
        }
        public void AtualizarEstoque(Estoque Estoque)
        {
            _context.Estoque.Update(Estoque);
            _context.SaveChanges();
        }

        public Estoque ObterEstoquePorID(int ID_PRO, int ID_SEC)
        {

            var estoque = _context.Estoque.FirstOrDefault(e => e.ID_PRO == ID_PRO && e.ID_SEC == ID_SEC);
            return estoque ?? throw new Exception("Produto nao encontrado no estoque!");
        }
    }
}
