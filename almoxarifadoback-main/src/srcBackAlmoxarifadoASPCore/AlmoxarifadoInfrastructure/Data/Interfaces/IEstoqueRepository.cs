using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IEstoqueRepository
    {
        Estoque ObterEstoquePorID(int ID_PRO, int ID_SEC);
        void AtualizarEstoque(Estoque Estoque);
    }
}
