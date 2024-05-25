using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class SaidaProdutosDTO
    {
        public RequisicaoPostDTO Requisicao { get; set; }
        public List<ItensRequisicaoPostDTO> ItensRequisicao { get; set; }
    }
}
