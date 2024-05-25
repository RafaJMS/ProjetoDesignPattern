using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class RequisicaoGetDTO
    {
        public int ID_REQ { get; set; }
        public int ID_CLI { get; set; }
        public decimal? TOTAL_REQ { get; set; }
        public int? QTD_ITEN { get; set; }
        public DateTime DATA_REQ { get; set; }
        public int ANO { get; set; }
        public int MES { get; set; }
        public int ID_SEC { get; set; }
        public int? ID_SET { get; set; }
        public string? OBSERVACAO { get; set; }
    }

    public class RequisicaoPostDTO
    {
        public int ID_CLI { get; set; }
        public decimal? TOTAL_REQ { get; set; }
        public int? QTD_ITEN { get; set; }
        public DateTime DATA_REQ { get; set; }
        public int ANO { get; set; }
        public int MES { get; set; }
        public int ID_SEC { get; set; }
        public int? ID_SET { get; set; }
        public string? OBSERVACAO { get; set; }
    }
}
