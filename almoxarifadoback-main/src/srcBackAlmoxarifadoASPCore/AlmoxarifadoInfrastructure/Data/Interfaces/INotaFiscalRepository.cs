using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface INotaFiscalRepository
    {
        List<Nota_Fiscal> ObterTodasNotasFiscais();
        Nota_Fiscal CriarNotaFiscal(Nota_Fiscal notaFiscal);
        Task<bool> UpdateNotaFiscal(int idNota, Nota_Fiscal notaFiscal);
        void DeleteNotaFiscal(int idNota);
        IDbContextTransaction BeginTransaction();
    }
}
