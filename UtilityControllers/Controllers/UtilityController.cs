using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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

        [Route("ReadMasterData")]
        [HttpGet]
        public IHttpActionResult ReadMasterData()
        {
            MasterData result = new MasterData();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                MySqlCommand qExe = new MySqlCommand();
                qExe.Connection = conn.connection;
                SQLString = @"select * from masterdata";
                qExe.CommandText = SQLString;
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    result.partyname = dataReader["partyname"].ToString();
                    result.housenumber = dataReader["housenumber"].ToString();
                    result.soi = dataReader["soi"].ToString();
                    result.road = dataReader["road"].ToString();
                    result.moo = dataReader["moo"].ToString();
                    result.building = dataReader["building"].ToString();
                    result.tambon = dataReader["tambon"].ToString();
                    result.amphur = dataReader["amphur"].ToString();
                    result.province = dataReader["province"].ToString();
                    result.zipcode = dataReader["zipcode"].ToString();
                    result.telephone = dataReader["telephone"].ToString();
                }
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("AddMasterData")]
        [HttpPost]
        public IHttpActionResult AddMasterData([FromBody] MasterData item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"INSERT INTO masterdata (partyname, housenumber, soi, road, moo, building, tambon, amphur, province, zipcode, telephone)
                              VALUES (@partyname, @housenumber, @soi, @road, @moo, @building, @tambon, @amphur, @province, @zipcode, @telephone)";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@partyname", item.partyname);
                qExe.Parameters.AddWithValue("@housenumber", item.housenumber);
                qExe.Parameters.AddWithValue("@soi", item.soi);
                qExe.Parameters.AddWithValue("@road", item.road);
                qExe.Parameters.AddWithValue("@moo", item.moo);
                qExe.Parameters.AddWithValue("@building", item.building);
                qExe.Parameters.AddWithValue("@tambon", item.tambon);
                qExe.Parameters.AddWithValue("@amphur", item.amphur);
                qExe.Parameters.AddWithValue("@province", item.province);
                qExe.Parameters.AddWithValue("@zipcode", item.zipcode);
                qExe.Parameters.AddWithValue("@telephone", item.telephone);
                qExe.ExecuteNonQuery();
                return Ok();
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("EditMasterData")]
        [HttpPost]
        public IHttpActionResult EditMasterData([FromBody] MasterData item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"UPDATE masterdata SET partyname = @partyname, housenumber = @housenumber, soi = @soi,
                              road = @road, moo = @moo, building = @building, tambon = @tambon, amphur = @amphur,
                              province = @province, zipcode = @zipcode, telephone = @telephone";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@partyname", item.partyname);
                qExe.Parameters.AddWithValue("@housenumber", item.housenumber);
                qExe.Parameters.AddWithValue("@soi", item.soi);
                qExe.Parameters.AddWithValue("@road", item.road);
                qExe.Parameters.AddWithValue("@moo", item.moo);
                qExe.Parameters.AddWithValue("@building", item.building);
                qExe.Parameters.AddWithValue("@tambon", item.tambon);
                qExe.Parameters.AddWithValue("@amphur", item.amphur);
                qExe.Parameters.AddWithValue("@province", item.province);
                qExe.Parameters.AddWithValue("@zipcode", item.zipcode);
                qExe.Parameters.AddWithValue("@telephone", item.telephone);
                qExe.ExecuteNonQuery();
                return Ok();
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }

        [Route("AddMemberData")]
        [HttpPost]
        public IHttpActionResult AddMemberData([FromBody] MemberData item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"INSERT INTO memberdata (memberid, membername, positionno,
                              housenumber, soi, road, moo, building, tambon, amphur, province, zipcode, telephone, 
                              memberprename, membersurname)
                              VALUES (@memberid, @membername, @positionno, @housenumber, @soi,
                              @road, @moo, @building, @tambon, @amphur, @province, @zipcode, @telephone,
                              @memberprename, @membersurname)";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@memberid", item.memberid);
                qExe.Parameters.AddWithValue("@memberprename", item.memberprename);
                qExe.Parameters.AddWithValue("@membername", item.membername);
                qExe.Parameters.AddWithValue("@membersurname", item.membersurname);
                qExe.Parameters.AddWithValue("@positionno", item.positionno);
                qExe.Parameters.AddWithValue("@housenumber", item.housenumber);
                qExe.Parameters.AddWithValue("@soi", item.soi);
                qExe.Parameters.AddWithValue("@road", item.road);
                qExe.Parameters.AddWithValue("@moo", item.moo);
                qExe.Parameters.AddWithValue("@building", item.building);
                qExe.Parameters.AddWithValue("@tambon", item.tambon);
                qExe.Parameters.AddWithValue("@amphur", item.amphur);
                qExe.Parameters.AddWithValue("@province", item.province);
                qExe.Parameters.AddWithValue("@zipcode", item.zipcode);
                qExe.Parameters.AddWithValue("@telephone", item.telephone);
                qExe.ExecuteNonQuery();
                long returnid = qExe.LastInsertedId;
                conn.CloseConnection();
                return Ok(returnid.ToString());
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("EditMemberData")]
        [HttpPost]
        public IHttpActionResult EditMemberData([FromBody] MemberData item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"UPDATE memberdata SET memberrunno = @memberrunno, memberid = @memberid, membername = @membername,
                              positionno = @positionno, housenumber = @housenumber, soi = @soi, road = @road, moo = @moo,
                              building = @building, tambon = @tambon, amphur = @amphur, province = @province, zipcode = @zipcode,
                              telephone = @telephone, memberprename = @memberprename, membersurname = @membersurname
                              WHERE memberrunno = @memberrunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@memberrunno", item.memberrunno);
                qExe.Parameters.AddWithValue("@memberid", item.memberid);
                qExe.Parameters.AddWithValue("@memberprename", item.memberprename);
                qExe.Parameters.AddWithValue("@membername", item.membername);
                qExe.Parameters.AddWithValue("@membersurname", item.membersurname);
                qExe.Parameters.AddWithValue("@positionno", item.positionno);
                qExe.Parameters.AddWithValue("@housenumber", item.housenumber);
                qExe.Parameters.AddWithValue("@soi", item.soi);
                qExe.Parameters.AddWithValue("@road", item.road);
                qExe.Parameters.AddWithValue("@moo", item.moo);
                qExe.Parameters.AddWithValue("@building", item.building);
                qExe.Parameters.AddWithValue("@tambon", item.tambon);
                qExe.Parameters.AddWithValue("@amphur", item.amphur);
                qExe.Parameters.AddWithValue("@province", item.province);
                qExe.Parameters.AddWithValue("@zipcode", item.zipcode);
                qExe.Parameters.AddWithValue("@telephone", item.telephone);
                qExe.ExecuteNonQuery();
                conn.CloseConnection();
                return Ok();
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("DeleteMemberData/{id}")]
        [HttpPost]
        public IHttpActionResult DeleteMemberData(string id)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"DELETE FROM memberdata WHERE memberrunno = @memberrunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@memberrunno", id);
                qExe.ExecuteNonQuery();
                conn.CloseConnection();
                return Ok();
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }

        [Route("ListAllMember")]
        [HttpGet]
        public IHttpActionResult ListAllMember()
        {
            List<MemberData> result = new List<MemberData>();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"SELECT t1.*, t2.positionname FROM memberdata t1 left join partyposition t2 on t1.positionno = t2.positionno order by memberid";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    MemberData detail = new MemberData();
                    detail.memberrunno = int.Parse(dataReader["memberrunno"].ToString());
                    detail.memberid = dataReader["memberid"].ToString();
                    detail.memberprename = dataReader["memberprename"].ToString();
                    detail.membername = dataReader["membername"].ToString();
                    detail.membersurname = dataReader["membersurname"].ToString();
                    detail.positionno = int.Parse(dataReader["positionno"].ToString());
                    detail.positionname = dataReader["positionname"].ToString();
                    detail.housenumber = dataReader["housenumber"].ToString();
                    detail.soi = dataReader["soi"].ToString();
                    detail.road = dataReader["road"].ToString();
                    detail.moo = dataReader["moo"].ToString();
                    detail.building = dataReader["building"].ToString();
                    detail.tambon = dataReader["tambon"].ToString();
                    detail.amphur = dataReader["amphur"].ToString();
                    detail.province = dataReader["province"].ToString();
                    detail.zipcode = dataReader["zipcode"].ToString();
                    detail.telephone = dataReader["telephone"].ToString();
                    result.Add(detail);
                }
                dataReader.Close();
                dataReader.Dispose();
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("GetMemberData/{id}")]
        [HttpGet]
        public IHttpActionResult GetMemberData(string id)
        {
            MemberData result = new MemberData();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"SELECT t1.*, t2.positionname 
                              FROM memberdata t1 left join partyposition t2 on t1.positionno = t2.positionno 
                              where memberrunno = '" + id + @"'
                              order by memberid";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    result.memberrunno = int.Parse(dataReader["memberrunno"].ToString());
                    result.memberid = dataReader["memberid"].ToString();
                    result.memberprename = dataReader["memberprename"].ToString();
                    result.membername = dataReader["membername"].ToString();
                    result.membersurname = dataReader["membersurname"].ToString();
                    result.positionno = int.Parse(dataReader["positionno"].ToString());
                    result.positionname = dataReader["positionname"].ToString();
                    result.housenumber = dataReader["housenumber"].ToString();
                    result.soi = dataReader["soi"].ToString();
                    result.road = dataReader["road"].ToString();
                    result.moo = dataReader["moo"].ToString();
                    result.building = dataReader["building"].ToString();
                    result.tambon = dataReader["tambon"].ToString();
                    result.amphur = dataReader["amphur"].ToString();
                    result.province = dataReader["province"].ToString();
                    result.zipcode = dataReader["zipcode"].ToString();
                    result.telephone = dataReader["telephone"].ToString();
                }
                dataReader.Close();
                dataReader.Dispose();
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }

        [Route("AddDonatorData")]
        [HttpPost]
        public IHttpActionResult AddDonatorData([FromBody] DonatorData item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"INSERT INTO donatordata (donatorid, donatorprename, donatorname, donatorsurname, donatorcenid,
                              donatorregisterno, donatortaxid, housenumber, soi, road, moo, building, tambon,
                              amphur, province, zipcode, telephone, last_update) 
                              VALUES (@donatorrunno, @donatorid, @donatorprename, @donatorname, @donatorsurname,
                              @donatorcenid, @donatorregisterno, @donatortaxid, @housenumber, @soi,
                              @road, @moo, @building, @tambon, @amphur, @province, @zipcode,
                              @telephone ) ";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@donatorid", item.donatorid);
                qExe.Parameters.AddWithValue("@donatorprename", item.donatorprename);
                qExe.Parameters.AddWithValue("@donatorname", item.donatorname);
                qExe.Parameters.AddWithValue("@donatorsurname", item.donatorsurname);
                qExe.Parameters.AddWithValue("@donatorcenid", item.donatorcenid);
                qExe.Parameters.AddWithValue("@donatorregisterno", item.donatorregisterno);
                qExe.Parameters.AddWithValue("@donatortaxid", item.donatortaxid);
                qExe.Parameters.AddWithValue("@housenumber", item.housenumber);
                qExe.Parameters.AddWithValue("@soi", item.soi);
                qExe.Parameters.AddWithValue("@road", item.road);
                qExe.Parameters.AddWithValue("@moo", item.moo);
                qExe.Parameters.AddWithValue("@building", item.building);
                qExe.Parameters.AddWithValue("@tambon", item.tambon);
                qExe.Parameters.AddWithValue("@amphur", item.amphur);
                qExe.Parameters.AddWithValue("@province", item.province);
                qExe.Parameters.AddWithValue("@zipcode", item.zipcode);
                qExe.Parameters.AddWithValue("@telephone", item.telephone);
                qExe.ExecuteNonQuery();
                long returnid = qExe.LastInsertedId;
                conn.CloseConnection();
                return Ok(returnid.ToString());
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("EditDonatorData")]
        [HttpPost]
        public IHttpActionResult EditDonatorData([FromBody] DonatorData item)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {


                SQLString = @"UPDATE donatordata SET donatorrunno = @donatorrunno, donatorid = @donatorid, donatorprename = @donatorprename,
                              donatorname = @donatorname, donatorsurname = @donatorsurname, donatorcenid = @donatorcenid,
                              donatorregisterno = @donatorregisterno, donatortaxid = @donatortaxid, housenumber = @housenumber,
                              soi = @soi, road = @road, moo = @moo, building = @building, tambon = @tambon, amphur = @amphur,
                              province = @province, zipcode = @zipcode, telephone = @telephone WHERE donatorrunno = @donatorrunno ";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@donatorrunno", item.donatorrunno);
                qExe.Parameters.AddWithValue("@donatorid", item.donatorid);
                qExe.Parameters.AddWithValue("@donatorprename", item.donatorprename);
                qExe.Parameters.AddWithValue("@donatorname", item.donatorname);
                qExe.Parameters.AddWithValue("@donatorsurname", item.donatorsurname);
                qExe.Parameters.AddWithValue("@donatorcenid", item.donatorcenid);
                qExe.Parameters.AddWithValue("@donatorregisterno", item.donatorregisterno);
                qExe.Parameters.AddWithValue("@donatortaxid", item.donatortaxid);
                qExe.Parameters.AddWithValue("@housenumber", item.housenumber);
                qExe.Parameters.AddWithValue("@soi", item.soi);
                qExe.Parameters.AddWithValue("@road", item.road);
                qExe.Parameters.AddWithValue("@moo", item.moo);
                qExe.Parameters.AddWithValue("@building", item.building);
                qExe.Parameters.AddWithValue("@tambon", item.tambon);
                qExe.Parameters.AddWithValue("@amphur", item.amphur);
                qExe.Parameters.AddWithValue("@province", item.province);
                qExe.Parameters.AddWithValue("@zipcode", item.zipcode);
                qExe.Parameters.AddWithValue("@telephone", item.telephone);
                qExe.ExecuteNonQuery();
                conn.CloseConnection();
                return Ok();
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("DeleteDonatorData/{id}")]
        [HttpPost]
        public IHttpActionResult DeleteDonatorData(string id)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"DELETE FROM donatordata WHERE donatorrunno = @donatorrunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@donatorrunno", id);
                qExe.ExecuteNonQuery();
                conn.CloseConnection();
                return Ok();
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }

        [Route("ListAllDonator")]
        [HttpGet]
        public IHttpActionResult ListAllDonator()
        {
            List<DonatorData> result = new List<DonatorData>();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"SELECT * FROM donatordata order by donatorid";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    DonatorData detail = new DonatorData();
                    detail.donatorrunno = int.Parse(dataReader["donatorrunno"].ToString());
                    detail.donatorid = dataReader["donatorid"].ToString();
                    detail.donatorprename = dataReader["donatorprename"].ToString();
                    detail.donatorname = dataReader["donatorname"].ToString();
                    detail.donatorsurname = dataReader["donatorsurname"].ToString();
                    detail.donatorcenid = dataReader["donatorcenid"].ToString();
                    detail.donatorregisterno = dataReader["donatorregisterno"].ToString();
                    detail.donatortaxid = dataReader["donatortaxid"].ToString();
                    detail.housenumber = dataReader["housenumber"].ToString();
                    detail.soi = dataReader["soi"].ToString();
                    detail.road = dataReader["road"].ToString();
                    detail.moo = dataReader["moo"].ToString();
                    detail.building = dataReader["building"].ToString();
                    detail.tambon = dataReader["tambon"].ToString();
                    detail.amphur = dataReader["amphur"].ToString();
                    detail.province = dataReader["province"].ToString();
                    detail.zipcode = dataReader["zipcode"].ToString();
                    detail.telephone = dataReader["telephone"].ToString();
                    result.Add(detail);
                }
                dataReader.Close();
                dataReader.Dispose();
                return Json(result);
            }
            else
            {
                return BadRequest("Database connect fail!");
            }
        }
        [Route("GetDonatorData/{id}")]
        [HttpGet]
        public IHttpActionResult GetDonatorData(string id)
        {
            DonatorData result = new DonatorData();
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            string SQLString;
            if (conn.OpenConnection())
            {
                SQLString = @"SELECT t1.*, t2.positionname 
                              FROM Donatordata t1 left join partyposition t2 on t1.positionno = t2.positionno 
                              where Donatorrunno = '" + id + @"'
                              order by Donatorid";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    result.donatorrunno = int.Parse(dataReader["donatorrunno"].ToString());
                    result.donatorid = dataReader["donatorid"].ToString();
                    result.donatorprename = dataReader["donatorprename"].ToString();
                    result.donatorname = dataReader["donatorname"].ToString();
                    result.donatorsurname = dataReader["donatorsurname"].ToString();
                    result.donatorcenid = dataReader["donatorcenid"].ToString();
                    result.donatorregisterno = dataReader["donatorregisterno"].ToString();
                    result.donatortaxid = dataReader["donatortaxid"].ToString();
                    result.housenumber = dataReader["housenumber"].ToString();
                    result.soi = dataReader["soi"].ToString();
                    result.road = dataReader["road"].ToString();
                    result.moo = dataReader["moo"].ToString();
                    result.building = dataReader["building"].ToString();
                    result.tambon = dataReader["tambon"].ToString();
                    result.amphur = dataReader["amphur"].ToString();
                    result.province = dataReader["province"].ToString();
                    result.zipcode = dataReader["zipcode"].ToString();
                    result.telephone = dataReader["telephone"].ToString();
                }
                dataReader.Close();
                dataReader.Dispose();
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

        public string NumberGen(string rnKey)
        {
            DBConnector.DBConnector conn = new DBConnector.DBConnector();
            MySqlCommand qExe = new MySqlCommand
            {
                Connection = conn.connection,
                CommandText = "select * from sy_runnumber where rn_key = '" + rnKey + "'"
            };

            string result = "";
            string format = "99999";
            int runnumber = 1;
            result = runnumber.ToString("00000");
            return result;
        }
    }
}
