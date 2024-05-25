using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Command
{
    public class SaidaEstoqueCommand : ICommand
    {
        private readonly Itens_Requisicao _itemRequisicao;
        private readonly ILogStrategy _logStrategy;

        public SaidaEstoqueCommand(Itens_Requisicao itemRequisicao, ILogStrategy logStrategy)
        {
            _itemRequisicao = itemRequisicao;
            _logStrategy = logStrategy;
        }

        public void Execute(ContextSQL context)
        {
            var estoque = context.Estoque.FirstOrDefault(e => e.ID_PRO == _itemRequisicao.ID_PRO && e.ID_SEC == _itemRequisicao.ID_SEC);
            if (estoque != null)
            {
                if (estoque.QTD_PRO >= _itemRequisicao.QTD_PRO)
                {
                    estoque.QTD_PRO -= _itemRequisicao.QTD_PRO;
                    context.SaveChanges();
                }
                else
                {
                    _logStrategy.CriarLog(estoque, _itemRequisicao.ID_REQ);
                    throw new Exception("Quantidade de produtos para saída excede a quantidade no banco de dados!");
                }
            }
        }
    }
}
