using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class NotaFiscalPostDTO
    {
        public int? ID_FOR { get; set; }
        public int ID_SEC { get; set; }
        public string NUM_NOTA { get; set; }
        public decimal VALOR_NOTA { get; set; }
        public int QTD_ITEM { get; set; }
        public int? ICMS { get; set; }
        public int? ISS { get; set; }
        public int ANO { get; set; }
        public int? MES { get; set; }
        public DateTime? DATA_NOTA { get; set; }
        public int ID_TIPO_NOTA { get; set; }
        public string? OBSERVACAO_NOTA { get; set; }
        public int? EMPENHO_NUM { get; set; }
    }

    public class NotaFiscalGetDTO
    {
        public int ID_NOTA { get; set; }
        public int? ID_FOR { get; set; }
        public int ID_SEC { get; set; }
        public string NUM_NOTA { get; set; }
        public decimal VALOR_NOTA { get; set; }
        public int QTD_ITEM { get; set; }
        public int? ICMS { get; set; }
        public int? ISS { get; set; }
        public int ANO { get; set; }
        public int? MES { get; set; }
        public DateTime? DATA_NOTA { get; set; }
        public int ID_TIPO_NOTA { get; set; }
        public string? OBSERVACAO_NOTA { get; set; }
        public int? EMPENHO_NUM { get; set; }
    }

}
