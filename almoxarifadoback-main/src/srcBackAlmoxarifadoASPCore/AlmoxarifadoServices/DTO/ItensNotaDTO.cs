
namespace AlmoxarifadoServices.DTO
{
    public class ItensNotaPostDTO
    {
        public int ITEM_NUM { get; set; }
        public int ID_PRO { get; set; }
        public decimal QTD_PRO { get; set; }
        public decimal PRE_UNIT { get; set; }
        public decimal EST_LIN { get; set; }
    }

    public class ItensNotaGetDTO
    {
        public int ITEM_NUM { get; set; }
        public int ID_PRO { get; set; }
        public int ID_NOTA { get; set; }
        public int ID_SEC { get; set; }
        public decimal QTD_PRO { get; set; }
        public decimal PRE_UNIT { get; set; }
        public decimal EST_LIN { get; set; }
    }

    public class ItensNotaPutDTO
    {
        public decimal QTD_PRO { get; set; }
        public decimal PRE_UNIT { get; set; }
        public decimal EST_LIN { get; set; }
    }
}