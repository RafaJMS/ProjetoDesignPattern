using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        private readonly ContextSQL _context;

        public RequisicaoRepository(ContextSQL context)
        {
            _context = context;
        }
        public Requisicao CriarRequisicao(Requisicao requisicao)
        {
            _context.Requisicao.Add(requisicao);
            _context.SaveChanges();
            return requisicao;
        }
        public void DeleteRequisicao(int ID_REQ)
        {
            var requisicao = _context.Requisicao.Find(ID_REQ) ?? throw new Exception("Requisição de ID " + ID_REQ + " não encontrada!");
            _context.Requisicao.Remove(requisicao);
            _context.SaveChanges();
        }
        public List<Requisicao> ObterTodasRequisicoes()
        {
            return _context.Requisicao.Select(r=> new Requisicao
            {
                ANO = r.ANO,
                DATA_REQ = r.DATA_REQ,
                ID_CLI = r.ID_CLI,
                ID_REQ = r.ID_REQ,
                ID_SEC = r.ID_SEC,
                ID_SET = r.ID_SET,
                MES = r.MES,
                OBSERVACAO = r.OBSERVACAO,
                QTD_ITEN = r.QTD_ITEN,
                TOTAL_REQ = r.TOTAL_REQ

            }).ToList();
        }
        public async Task<bool> UpdateRequisicao(int ID_REQ, Requisicao requisicao)
        {
            var existingRequisicao = await _context.Requisicao.FindAsync(ID_REQ);

            if (existingRequisicao == null) 
            {
                return false;
            }

            existingRequisicao.MES = requisicao.MES;
            existingRequisicao.TOTAL_REQ = requisicao.TOTAL_REQ;
            existingRequisicao.ID_CLI = requisicao.ID_CLI;
            existingRequisicao.QTD_ITEN = requisicao .QTD_ITEN;
            existingRequisicao.DATA_REQ = requisicao.DATA_REQ;
            existingRequisicao.ANO = requisicao.ANO;
            existingRequisicao.ID_SEC = requisicao.ID_SEC;
            existingRequisicao.ID_SET = requisicao.ID_SET;
            existingRequisicao.OBSERVACAO = requisicao.OBSERVACAO;

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
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
