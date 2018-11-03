using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityControllers;
using UtilityControllers.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ทดสอบการดึงข้อมูลzipcode()
        {
            UtilityController service = new UtilityController();
            var result = service.getAmphurData("กรุงเทพมหานคร");
            Assert.IsNotNull(result);
            result = service.getTambonData("กรุงเทพมหานคร", "ดินแดง");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ทดสอบจำนวนเงินตัวอักษร()
        {
            UtilityController service = new UtilityController();
            string result = service.ThaiBaht("514.75");
            Assert.IsTrue(result != "");
        }

        [TestMethod]
        public void ทดสอบการดึงตำแหน่งในพรรค()
        {
            UtilityController service = new UtilityController();
            var result = service.GetPartyPositionList();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ทดสอบเพิ่มข้อมูลสมาชิกพรรค()
        {
            UtilityController service = new UtilityController();
            MemberData item = new MemberData();
            item.MemberId = "18-0001";
            item.MemberPreName = "นาย";
            item.MemberName = "ซื่อสัตย์";
            item.MemberSurname = "สุจริต";
            item.PositionNo = 2;
            var result = service.AddMemberData(item);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ทดสอบแก้ไขข้อมูลสมาชิกพรรค()
        {
            UtilityController service = new UtilityController();
            MemberData item = new MemberData();
            item.MemberRunno = 1;
            item.MemberId = "18-0001";
            item.MemberPreName = "นาย";
            item.MemberName = "คิดดี";
            item.MemberSurname = "ทำดี";
            item.PositionNo = 2;
            item.HouseNumber = "abc";
            item.Soi = "soi soi";
            item.Moo = "5";
            item.Building = "ตึก";
            item.Road = "ถนน";
            item.ZipCode = "10400";
            var result = service.EditMemberData(item);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ทดสอบลบข้อมูล()
        {
            UtilityController service = new UtilityController();
            var result = service.DeleteMemberData("2");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ทดสอบดึงข้อมูลสมาชิกพรรคในแต่ละแบบ()
        {
            UtilityController service = new UtilityController();
            var result = service.ListAllMember();
            Assert.IsNotNull(result);
            var result2 = service.GetMemberData("1");
            Assert.IsNotNull(result2);
        }

        [TestMethod]
        public void ทดสอบGenเลขที่เอกสาร()
        {
            UtilityController service = new UtilityController();
            string result = service.NumberGen("donate");
            Assert.IsTrue(result != "");
        }

        [TestMethod]
        public void ทดสอบเพิ่มข้อมูลผู้บริจาค()
        {
            UtilityController service = new UtilityController();
            DonatorData item = new DonatorData();
            item.DonatorId = "0003";
            item.DonatorPreName = "นาย";
            item.DonatorName = "ทดสอบลบ";
            item.DonatorSurName = "ลบได้เลย";
            item.DonatorCitizenId = "4564567890123";
            item.DonatorRegisterNo = "";
            item.DonatorTaxId = "";
            item.HouseNumber = "98";
            item.Soi = "ซอย";
            item.Road = "";
            item.Moo = "5";
            item.Building = "";
            item.Tambon = "";
            item.Amphur = "";
            item.Province = "";
            item.ZipCode = "10400";
            item.Telephone = "";
            var result = service.AddDonatorData(item);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ทดสอบแก้ไขข้อมูล()
        {
            UtilityController service = new UtilityController();
            DonatorData item = new DonatorData();
            item.DonatorRunno = 2;
            item.DonatorId = "0002";
            item.DonatorPreName = "นาย";
            item.DonatorName = "แก้ไขข้อมูล";
            item.DonatorSurName = "ทดสอบมา";
            item.DonatorCitizenId = "4";
            item.DonatorRegisterNo = "";
            item.DonatorTaxId = "";
            item.HouseNumber = "8";
            item.Soi = "3321";
            item.Road = "";
            item.Moo = "9";
            item.Building = "";
            item.Tambon = "";
            item.Amphur = "";
            item.Province = "";
            item.ZipCode = "99999";
            item.Telephone = "";
            var result = service.EditDonatorData(item);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ทดสอบลบข้อมูลผู้บริจาค()
        {
            UtilityController service = new UtilityController();
            DonatorData item = new DonatorData();
            item.DonatorRunno = 2;            
            var result = service.DeleteDonatorData(item.DonatorRunno.ToString());
            Assert.IsNotNull(result);
        }
    }
}
