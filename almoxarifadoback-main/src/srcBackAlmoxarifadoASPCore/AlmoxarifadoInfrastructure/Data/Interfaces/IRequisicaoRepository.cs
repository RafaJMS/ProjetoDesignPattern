using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IRequisicaoRepository
    {
        List<Requisicao> ObterTodasRequisicoes();
        Requisicao CriarRequisicao(Requisicao requisicao);
        Task<bool> UpdateRequisicao(int ID_REQ, Requisicao requisicao);
        void DeleteRequisicao(int ID_REQ);
        IDbContextTransaction BeginTransaction();
    }
}
