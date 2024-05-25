using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class ItensRequisicaoGetDTO
    {
        public int NUM_ITEM { get; set; }
        public int ID_PRO { get; set; }
        public int ID_REQ { get; set; }
        public int ID_SEC { get; set; }
        public decimal QTD_PRO { get; set; }
        public decimal PRE_UNIT { get; set; }
        public decimal? TOTAL_REAL { get; set; }
    }
    public class ItensRequisicaoPostDTO
    {
        public int NUM_ITEM { get; set; }
        public int ID_PRO { get; set; }
        public int ID_REQ { get; set; }
        public int ID_SEC { get; set; }
        public decimal QTD_PRO { get; set; }
        public decimal PRE_UNIT { get; set; }
        public decimal? TOTAL_REAL { get; set; }
    }

    public class ItensRequisicaoPutDTO
    {
        public decimal QTD_PRO { get; set; }
        public decimal PRE_UNIT { get; set; }
        public decimal? VALOR_TOTAL { get; set; }
        public decimal? TOTAL_REAL { get; set; }
    }
}
