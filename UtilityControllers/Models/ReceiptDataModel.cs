using System;
using System.Data.SqlTypes;

namespace UtilityControllers.Models
{
    public class ReceiptDataModel
    {
        public string DocumentRunno { get; set; }
        public string DocumentBookNumber { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string payerName { get; set; }
        public string payerid { get; set; }
        public string houseNumber { get; set; }
        public string soi { get; set; }
        public string road { get; set; }
        public string moo { get; set; }
        public string building { get; set; }
        public string tambon { get; set; }
        public string amphur { get; set; }
        public string province { get; set; }
        public string zipcode { get; set; }
        public string telephone { get; set; }
        public string asReceiptTo { get; set; }
        public string asReceiptToRemark { get; set; } // สำหรับกรณีเป็นการเลือก Option อื่น ๆ จะเป็นส่วนของ การระบุ
        public Double receiptAmount { get; set; }
        public string receiptPayType { get; set; }
        public DateTime? receiptDate { get; set; }
        public string receiptBank { get; set; }
        public string receiptBillNumber { get; set; }
        public string receiptChqBank { get; set; }
        public string receiptChqNumber { get; set; }
        public string receiptOther { get; set; }
        
    }
}
