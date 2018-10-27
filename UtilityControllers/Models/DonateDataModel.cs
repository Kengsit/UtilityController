using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace UtilityControllers.Models
{
    public class DonateDataModel
    {
        public string DocumentRunno { get; set; }
        public string WriteAt { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string PartymemID { get; set; }
        public string MemberName { get; set; }
        public string MemberID { get; set; }
        public DateTime? MemberBirthdate { get; set; }
        public string MemberHouseNumber { get; set; }
        public string MemberMoo { get; set; }
        public string MemberBuilding { get; set; }
        public string MemberSoi { get; set; }
        public string MemberRoad { get; set; }
        public string MemberTambon { get; set; }
        public string MemberAmphur { get; set; }
        public string MemberProvince { get; set; }
        public string MemberZipcode { get; set; }
        public string MemberTelephone { get; set; }
        public string MemberPosition { get; set; }
        public string DonateType { get; set; }
        public string DonateObjective { get; set; }
        public string DonatorName { get; set; }
        public string DonatorID { get; set; }
        public string DonatorRegisterNO { get; set; }
        public string DonatorTaxID { get; set; }
        public string DonatorHouseNumber { get; set; }
        public string DonatorMoo { get; set; }
        public string DonatorBuilding { get; set; }
        public string DonatorSoi { get; set; }
        public string DonatorRoad { get; set; }
        public string DonatorTambon { get; set; }
        public string DonatorAmphur { get; set; }
        public string DonatorProvince { get; set; }
        public string DonatorZipcode { get; set; }
        public string DonatorTelephone { get; set; }
        public double DonateAmount { get; set; }
        public List<DonateDetailDataModel> DonateDetail { get; set; }
    }
}
