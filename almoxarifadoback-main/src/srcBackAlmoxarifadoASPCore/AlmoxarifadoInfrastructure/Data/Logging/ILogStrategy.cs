using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Logging
{
    public interface ILogStrategy
    {
        void CriarLog(Estoque estoque, decimal ID_REQ);
    }
}
