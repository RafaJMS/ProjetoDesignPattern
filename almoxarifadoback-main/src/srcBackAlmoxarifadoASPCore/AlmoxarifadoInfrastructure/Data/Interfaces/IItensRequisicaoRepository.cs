using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensRequisicaoRepository
    {
        List<Itens_Requisicao> ObterTodosItensRequisicao();
        Itens_Requisicao CriarItemRequisicao(Itens_Requisicao itemRequisicao);
        Task<bool> UpdateItemRequisicaoAsync(int NUM_ITEM, int ID_REQ, int ID_PRO, int ID_SEC, Itens_Requisicao itemRequisicao);
        void DeleteItemRequisicao(int NUM_ITEM, int ID_REQ, int ID_PRO, int ID_SEC);
    }
}
