using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Logging;
using AlmoxarifadoServices.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Services
{
    public class EstoqueService
    {
        private readonly ContextSQL _context;

        public EstoqueService(ContextSQL context)
        {
            _context = context;
        }

        public void ExecutarComando(ICommand command)
        {
            command.Execute(_context);
        }
    }
}

