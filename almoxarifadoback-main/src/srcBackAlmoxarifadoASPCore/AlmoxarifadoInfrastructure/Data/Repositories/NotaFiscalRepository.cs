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
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ContextSQL _context;

        public NotaFiscalRepository(ContextSQL pContext)
        {
            _context = pContext;
        }

        public List<Nota_Fiscal> ObterTodasNotasFiscais()
        {
            return _context.Nota_Fiscal.Select(nf=>new Nota_Fiscal
            {
                ICMS = nf.ICMS ?? 0,
                ANO = nf.ANO,
                DATA_NOTA = nf.DATA_NOTA ?? null ,
                EMPENHO_NUM = nf.EMPENHO_NUM ?? 0,
                ID_FOR = nf.ID_FOR ?? 0,
                ID_NOTA = nf.ID_NOTA,
                ID_SEC = nf.ID_SEC,
                ID_TIPO_NOTA = nf.ID_TIPO_NOTA,
                ISS = nf.ISS ?? 0,
                MES = nf.MES ?? 0,
                NUM_NOTA = nf.NUM_NOTA,
                OBSERVACAO_NOTA = nf.OBSERVACAO_NOTA ?? "",
                QTD_ITEM = nf.QTD_ITEM,
                VALOR_NOTA = nf.VALOR_NOTA
            }).ToList();
        }

        public Nota_Fiscal CriarNotaFiscal(Nota_Fiscal notaFiscal)
        {
            _context.Nota_Fiscal.Add(notaFiscal);
            _context.SaveChanges();
            
            return notaFiscal;
        }

        public async Task<bool> UpdateNotaFiscal(int idNota, Nota_Fiscal notaFiscal)
        {
            var existingNotaFiscal = await _context.Nota_Fiscal.FindAsync(idNota);

            if (existingNotaFiscal == null)
            {
                return false;
            }

            existingNotaFiscal.ICMS = notaFiscal.ICMS;
            existingNotaFiscal.ANO = notaFiscal.ANO;
            existingNotaFiscal.DATA_NOTA = notaFiscal.DATA_NOTA;
            existingNotaFiscal.EMPENHO_NUM = notaFiscal.EMPENHO_NUM;
            existingNotaFiscal.ID_FOR = notaFiscal.ID_FOR;
            existingNotaFiscal.ID_SEC = notaFiscal.ID_SEC;
            existingNotaFiscal.ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA;
            existingNotaFiscal.ISS = notaFiscal.ISS;
            existingNotaFiscal.MES = notaFiscal.MES;
            existingNotaFiscal.NUM_NOTA = notaFiscal.NUM_NOTA;
            existingNotaFiscal.OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA ?? "";
            existingNotaFiscal.QTD_ITEM = notaFiscal.QTD_ITEM;
            existingNotaFiscal.VALOR_NOTA = notaFiscal.VALOR_NOTA;

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

        public void DeleteNotaFiscal(int idNota)
        {
            var notaFiscal = _context.Nota_Fiscal.Find(idNota) ?? throw new Exception("Nota fiscal não encontrada");
            _context.Nota_Fiscal.Remove(notaFiscal);
            _context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
