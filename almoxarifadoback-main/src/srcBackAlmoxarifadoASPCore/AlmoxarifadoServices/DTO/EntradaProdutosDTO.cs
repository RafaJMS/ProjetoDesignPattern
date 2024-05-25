using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class EntradaProdutosDTO
    {
        public NotaFiscalPostDTO NotaFiscal { get; set; }
        public List<ItensNotaPostDTO> ItensNota { get; set; }
    }
}
