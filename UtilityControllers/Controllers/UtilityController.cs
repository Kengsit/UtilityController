using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using UtilityControllers.Models;

namespace UtilityControllers
{
    [RoutePrefix("api/UtilityData")]
    public class UtilityController : ApiController
    {
        [Route("ZipCodeData/{zipcode}")]
        [HttpGet]
        public IHttpActionResult getZipCodeData(string zipcode)
        {
            zipcodedata result = new zipcodedata();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {

                if (!string.IsNullOrEmpty(zipcode))
                {
                    MySqlCommand qExe = new MySqlCommand();
                    qExe.Connection = conn.connection;
                    SQLString = @"select * from zip_data where zipcode = '" + zipcode + "'";
                    qExe.CommandText = SQLString;
                    MySqlDataReader dataReader = qExe.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result.province = dataReader["province"].ToString();
                        result.amphur = dataReader["amphur"].ToString();
                        result.tambon = dataReader["tambon"].ToString();
                        result.zipcode = dataReader["zipcode"].ToString();
                    }
                }
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("ProvinceData")]
        [HttpGet]
        public IHttpActionResult getProvinceData()
        {
            List<zipcodedata> result = new List<zipcodedata>();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                MySqlCommand qExe = new MySqlCommand();
                qExe.Connection = conn.connection;
                SQLString = @"select distinct province from zip_data order by province";
                qExe.CommandText = SQLString;
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    zipcodedata detail = new zipcodedata();
                    detail.province = dataReader["province"].ToString();
                    detail.amphur = "";
                    detail.tambon = "";
                    detail.zipcode = "";
                    result.Add(detail);
                }
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("AmphurData/{province}")]
        [HttpGet]
        public IHttpActionResult getAmphurData(string province)
        {
            List<zipcodedata> result = new List<zipcodedata>();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                MySqlCommand qExe = new MySqlCommand();
                qExe.Connection = conn.connection;
                SQLString = @"select distinct province, amphur from zip_data where province = '" + province + @"' order by amphur";
                qExe.CommandText = SQLString;
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    zipcodedata detail = new zipcodedata();
                    detail.province = dataReader["province"].ToString();
                    detail.amphur = dataReader["amphur"].ToString();
                    detail.tambon = "";
                    detail.zipcode = "";
                    result.Add(detail);
                }
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("TambonData/{province}/{amphur}")]
        [HttpGet]
        public IHttpActionResult getTambonData(string province, string amphur)
        {
            List<zipcodedata> result = new List<zipcodedata>();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                MySqlCommand qExe = new MySqlCommand();
                qExe.Connection = conn.connection;
                SQLString = @"select province, amphur, tambon, zipcode from zip_data 
                              where province = '" + province + @"' 
                              and amphur = '" + amphur + @"'
                              order by tambon";
                qExe.CommandText = SQLString;
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    zipcodedata detail = new zipcodedata();
                    detail.province = dataReader["province"].ToString();
                    detail.amphur = dataReader["amphur"].ToString();
                    detail.tambon = dataReader["tambon"].ToString();
                    detail.zipcode = dataReader["zipcode"].ToString();
                    result.Add(detail);
                }
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }

        [Route("PartyPositionList")]
        [HttpGet]
        public IHttpActionResult GetPartyPositionList()
        {
            List<partyposition> result = new List<partyposition>();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                MySqlCommand qExe = new MySqlCommand();
                qExe.Connection = conn.connection;
                SQLString = @"select positionrunno, positionno, positionname from partyposition
                              order by positionno";
                qExe.CommandText = SQLString;
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    partyposition detail = new partyposition();
                    detail.positionrunno = int.Parse(dataReader["positionrunno"].ToString());
                    detail.positionno = int.Parse(dataReader["positionno"].ToString());
                    detail.positionname = dataReader["positionname"].ToString();
                    result.Add(detail);
                }
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        public string ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }
    }
}
