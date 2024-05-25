using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensNotaRepository
    {
        List<Itens_Nota> ObterTodosItensNota();
        Itens_Nota CriarItemNota(Itens_Nota itemNota);
        Task<bool> UpdateItemNota(int itemNum, int IdPro, int IdNota, int IdSec, Itens_Nota itemNota);
        void DeleteItemNota(int itemNum, int IdPro, int IdNota, int IdSec);
    }
}
