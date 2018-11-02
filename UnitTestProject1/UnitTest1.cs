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
    }
}
