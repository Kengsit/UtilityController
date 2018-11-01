using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Web.UI;

namespace UtilityControllers.Models
{
    public class DonateDataModel
    {
        public int DocumentRunno { get; set; }
        public string WriteAt { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int MemberRunno { get; set; }
        public string MemberId { get; set; }
        public string DonateType { get; set; }
        public string DonateObjective { get; set; }
        public int DonatorRunno { get; set; }
        public string DonatorId { get; set; }
        public Double DonateAmount { get; set; }
        public string MemberName { get; set; }
        public string MemberID { get; set; }
        public DateTime? MemberBirthdate { get; set; }
        public string MemberAddress { get; set; }        
        public string MemberTelephone { get; set; }
        public string MemberPosition { get; set; }
        public string DonatorName { get; set; }
        public string DonatorID { get; set; }
        public string DonatorRegisterNO { get; set; }
        public string DonatorTaxID { get; set; }
        public string DonatorAddress { get; set; }
        public string DonatorTelephone { get; set; }
        public List<DonateDetailDataModel> DonateDetail { get; set; }
    }
}
