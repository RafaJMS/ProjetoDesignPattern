using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Observer
{
    public class EntradaEstoqueCommand : ICommand
    {
        private readonly Itens_Nota _itemNota;

        public EntradaEstoqueCommand(Itens_Nota itemNota)
        {
            _itemNota = itemNota;
        }

        public void Execute(ContextSQL context)
        {
            var estoque = context.Estoque.FirstOrDefault(e => e.ID_PRO == _itemNota.ID_PRO && e.ID_SEC == _itemNota.ID_SEC);
            if (estoque != null)
            {
                estoque.QTD_PRO += _itemNota.QTD_PRO;
                context.SaveChanges();
            }
        }
    }
}

