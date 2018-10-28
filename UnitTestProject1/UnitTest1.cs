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
            result = service.getTambonData("กรุงเทพมหานคร","ดินแดง");
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
    }
}
