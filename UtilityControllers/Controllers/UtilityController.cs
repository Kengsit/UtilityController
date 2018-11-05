using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using MySql.Data.MySqlClient;
using UtilityControllers.Models;

namespace UtilityControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
                    detail.PositionRunno = int.Parse(dataReader["PositionRunno"].ToString());
                    detail.PositionNo = int.Parse(dataReader["PositionNo"].ToString());
                    detail.PositionName = dataReader["PositionName"].ToString();
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
                SQLString = @"INSERT INTO memberdata
                              (MemberId, MemberPreName, MemberName, MemberSurname, PositionNo,
                              BirthDate, HouseNumber, Soi, Road, Moo, Building, Tambon, Amphur,
                              Province, ZipCode, Telephone)
                              VALUES (@MemberId, @MemberPreName, @MemberName,
                              @MemberSurname, @PositionNo, @BirthDate, @HouseNumber, @Soi,
                              @Road, @Moo, @Building, @Tambon, @Amphur, @Province, @ZipCode, @Telephone)";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@MemberId", item.MemberId);
                qExe.Parameters.AddWithValue("@MemberPreName", item.MemberPreName);
                qExe.Parameters.AddWithValue("@MemberName", item.MemberName);
                qExe.Parameters.AddWithValue("@MemberSurname", item.MemberSurname);
                qExe.Parameters.AddWithValue("@PositionNo", item.PositionNo);
                qExe.Parameters.AddWithValue("@BirthDate", item.BirthDate);
                qExe.Parameters.AddWithValue("@HouseNumber", item.HouseNumber);
                qExe.Parameters.AddWithValue("@Soi", item.Soi);
                qExe.Parameters.AddWithValue("@Road", item.Road);
                qExe.Parameters.AddWithValue("@Moo", item.Moo);
                qExe.Parameters.AddWithValue("@Building", item.Building);
                qExe.Parameters.AddWithValue("@Tambon", item.Tambon);
                qExe.Parameters.AddWithValue("@Amphur", item.Amphur);
                qExe.Parameters.AddWithValue("@Province", item.Province);
                qExe.Parameters.AddWithValue("@ZipCode", item.ZipCode);
                qExe.Parameters.AddWithValue("@Telephone", item.Telephone);
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
                SQLString = @"UPDATE memberdata SET MemberId = @MemberId, MemberPreName = @MemberPreName,
                              MemberName = @MemberName, MemberSurname = @MemberSurname, PositionNo = @PositionNo, BirthDate = @BirthDate,
                              HouseNumber = @HouseNumber, Soi = @Soi, Road = @Road, Moo = @Moo, Building = @Building, Tambon = @Tambon,
                              Amphur = @Amphur, Province = @Province, ZipCode = @ZipCode, Telephone = @Telephone WHERE MemberRunno = @MemberRunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@MemberRunno", item.MemberRunno);
                qExe.Parameters.AddWithValue("@MemberId", item.MemberId);
                qExe.Parameters.AddWithValue("@MemberPreName", item.MemberPreName);
                qExe.Parameters.AddWithValue("@MemberName", item.MemberName);
                qExe.Parameters.AddWithValue("@MemberSurname", item.MemberSurname);
                qExe.Parameters.AddWithValue("@PositionNo", item.PositionNo);
                qExe.Parameters.AddWithValue("@BirthDate", item.BirthDate);
                qExe.Parameters.AddWithValue("@HouseNumber", item.HouseNumber);
                qExe.Parameters.AddWithValue("@Soi", item.Soi);
                qExe.Parameters.AddWithValue("@Road", item.Road);
                qExe.Parameters.AddWithValue("@Moo", item.Moo);
                qExe.Parameters.AddWithValue("@Building", item.Building);
                qExe.Parameters.AddWithValue("@Tambon", item.Tambon);
                qExe.Parameters.AddWithValue("@Amphur", item.Amphur);
                qExe.Parameters.AddWithValue("@Province", item.Province);
                qExe.Parameters.AddWithValue("@ZipCode", item.ZipCode);
                qExe.Parameters.AddWithValue("@Telephone", item.Telephone);
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
                SQLString = @"DELETE FROM memberdata WHERE MemberRunno = @MemberRunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@MemberRunno", id);
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
                SQLString = @"SELECT t1.*, t2.PositionName FROM memberdata t1 left join partyposition t2 on t1.PositionNo = t2.PositionNo order by MemberId";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    MemberData detail = new MemberData();
                    detail.MemberRunno = int.Parse(dataReader["MemberRunno"].ToString());
                    detail.MemberId = dataReader["MemberId"].ToString();
                    detail.MemberPreName = dataReader["MemberPreName"].ToString();
                    detail.MemberName = dataReader["MemberName"].ToString();
                    detail.MemberSurname = dataReader["MemberSurname"].ToString();
                    detail.PositionNo = int.Parse(dataReader["PositionNo"].ToString());
                    detail.PositionName = dataReader["PositionName"].ToString();
                    detail.HouseNumber = dataReader["HouseNumber"].ToString();
                    detail.Soi = dataReader["Soi"].ToString();
                    detail.Road = dataReader["Road"].ToString();
                    detail.Moo = dataReader["Moo"].ToString();
                    detail.Building = dataReader["Building"].ToString();
                    detail.Tambon = dataReader["Tambon"].ToString();
                    detail.Amphur = dataReader["Amphur"].ToString();
                    detail.Province = dataReader["Province"].ToString();
                    detail.ZipCode = dataReader["ZipCode"].ToString();
                    detail.Telephone = dataReader["Telephone"].ToString();
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
                SQLString = @"SELECT t1.*, t2.PositionName 
                              FROM memberdata t1 left join partyposition t2 on t1.PositionNo = t2.PositionNo
                              where MemberRunno = '" + id + @"'
                              order by MemberId";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    result.MemberRunno = int.Parse(dataReader["MemberRunno"].ToString());
                    result.MemberId = dataReader["MemberId"].ToString();
                    result.MemberPreName = dataReader["MemberPreName"].ToString();
                    result.MemberName = dataReader["MemberName"].ToString();
                    result.MemberSurname = dataReader["MemberSurname"].ToString();
                    result.PositionNo = int.Parse(dataReader["PositionNo"].ToString());
                    result.PositionName = dataReader["PositionName"].ToString();
                    result.HouseNumber = dataReader["HouseNumber"].ToString();
                    result.Soi = dataReader["Soi"].ToString();
                    result.Road = dataReader["Road"].ToString();
                    result.Moo = dataReader["Moo"].ToString();
                    result.Building = dataReader["Building"].ToString();
                    result.Tambon = dataReader["Tambon"].ToString();
                    result.Amphur = dataReader["Amphur"].ToString();
                    result.Province = dataReader["Province"].ToString();
                    result.ZipCode = dataReader["ZipCode"].ToString();
                    result.Telephone = dataReader["Telephone"].ToString();
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
                SQLString = @"INSERT INTO donatordata (DonatorId, DonatorPreName, DonatorName, DonatorSurName,
                              DonatorCitizenId, DonatorRegisterNo, DonatorTaxId, HouseNumber, Soi, Road, Moo, Building, Tambon,
                              Amphur, Province, ZipCode, Telephone) VALUES (@DonatorId, @DonatorPreName,
                              @DonatorName, @DonatorSurName, @DonatorCitizenId, @DonatorRegisterNo, @DonatorTaxId, @HouseNumber,
                              @Soi, @Road, @Moo, @Building, @Tambon, @Amphur, @Province, @ZipCode, @Telephone)";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@DonatorId", item.DonatorId);
                qExe.Parameters.AddWithValue("@DonatorPreName", item.DonatorPreName);
                qExe.Parameters.AddWithValue("@DonatorName", item.DonatorName);
                qExe.Parameters.AddWithValue("@DonatorSurName", item.DonatorSurName);
                qExe.Parameters.AddWithValue("@DonatorCitizenId", item.DonatorCitizenId);
                qExe.Parameters.AddWithValue("@DonatorRegisterNo", item.DonatorRegisterNo);
                qExe.Parameters.AddWithValue("@DonatorTaxId", item.DonatorTaxId);
                qExe.Parameters.AddWithValue("@HouseNumber", item.HouseNumber);
                qExe.Parameters.AddWithValue("@Soi", item.Soi);
                qExe.Parameters.AddWithValue("@Road", item.Road);
                qExe.Parameters.AddWithValue("@Moo", item.Moo);
                qExe.Parameters.AddWithValue("@Building", item.Building);
                qExe.Parameters.AddWithValue("@Tambon", item.Tambon);
                qExe.Parameters.AddWithValue("@Amphur", item.Amphur);
                qExe.Parameters.AddWithValue("@Province", item.Province);
                qExe.Parameters.AddWithValue("@ZipCode", item.ZipCode);
                qExe.Parameters.AddWithValue("@Telephone", item.Telephone);
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
                SQLString = @"UPDATE donatordata SET DonatorRunno = @DonatorRunno, DonatorId = @DonatorId, DonatorPreName = @DonatorPreName,
                              DonatorName = @DonatorName, DonatorSurName = @DonatorSurName, DonatorCitizenId = @DonatorCitizenId,
                              DonatorRegisterNo = @DonatorRegisterNo, DonatorTaxId = @DonatorTaxId, HouseNumber = @HouseNumber,
                              Soi = @Soi, Road = @Road, Moo = @Moo, Building = @Building, Tambon = @Tambon, Amphur = @Amphur,
                              Province = @Province, Zipcode = @Zipcode, Telephone = @Telephone WHERE DonatorRunno = @DonatorRunno ";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@DonatorRunno", item.DonatorRunno);
                qExe.Parameters.AddWithValue("@DonatorId", item.DonatorId);
                qExe.Parameters.AddWithValue("@DonatorPreName", item.DonatorPreName);
                qExe.Parameters.AddWithValue("@DonatorName", item.DonatorName);
                qExe.Parameters.AddWithValue("@DonatorSurName", item.DonatorSurName);
                qExe.Parameters.AddWithValue("@DonatorCitizenId", item.DonatorCitizenId);
                qExe.Parameters.AddWithValue("@DonatorRegisterNo", item.DonatorRegisterNo);
                qExe.Parameters.AddWithValue("@DonatorTaxId", item.DonatorTaxId);
                qExe.Parameters.AddWithValue("@HouseNumber", item.HouseNumber);
                qExe.Parameters.AddWithValue("@Soi", item.Soi);
                qExe.Parameters.AddWithValue("@Road", item.Road);
                qExe.Parameters.AddWithValue("@Moo", item.Moo);
                qExe.Parameters.AddWithValue("@Building", item.Building);
                qExe.Parameters.AddWithValue("@Tambon", item.Tambon);
                qExe.Parameters.AddWithValue("@Amphur", item.Amphur);
                qExe.Parameters.AddWithValue("@Province", item.Province);
                qExe.Parameters.AddWithValue("@ZipCode", item.ZipCode);
                qExe.Parameters.AddWithValue("@Telephone", item.Telephone);
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
                SQLString = @"DELETE FROM donatordata WHERE DonatorRunno = @DonatorRunno";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                qExe.Parameters.AddWithValue("@DonatorRunno", id);
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
                SQLString = @"SELECT * FROM donatordata order by DonatorId";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    DonatorData detail = new DonatorData();
                    detail.DonatorRunno = int.Parse(dataReader["DonatorRunno"].ToString());
                    detail.DonatorId = dataReader["DonatorId"].ToString();
                    detail.DonatorPreName = dataReader["DonatorPreName"].ToString();
                    detail.DonatorName = dataReader["DonatorName"].ToString();
                    detail.DonatorSurName = dataReader["DonatorSurName"].ToString();
                    detail.DonatorCitizenId = dataReader["DonatorCitizenId"].ToString();
                    detail.DonatorRegisterNo = dataReader["DonatorRegisterNo"].ToString();
                    detail.DonatorTaxId = dataReader["DonatorTaxId"].ToString();
                    detail.HouseNumber = dataReader["HouseNumber"].ToString();
                    detail.Soi = dataReader["Soi"].ToString();
                    detail.Road = dataReader["Road"].ToString();
                    detail.Moo = dataReader["Moo"].ToString();
                    detail.Building = dataReader["Building"].ToString();
                    detail.Tambon = dataReader["Tambon"].ToString();
                    detail.Amphur = dataReader["Amphur"].ToString();
                    detail.Province = dataReader["Province"].ToString();
                    detail.ZipCode = dataReader["ZipCode"].ToString();
                    detail.Telephone = dataReader["Telephone"].ToString();
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
                SQLString = @"SELECT * FROM donatordata where DonatorRunno = '" + id + @"'
                              order by DonatorId";
                MySqlCommand qExe = new MySqlCommand
                {
                    Connection = conn.connection,
                    CommandText = SQLString
                };
                MySqlDataReader dataReader = qExe.ExecuteReader();
                while (dataReader.Read())
                {
                    result.DonatorRunno = int.Parse(dataReader["DonatorRunno"].ToString());
                    result.DonatorId = dataReader["DonatorId"].ToString();
                    result.DonatorPreName = dataReader["DonatorPreName"].ToString();
                    result.DonatorName = dataReader["DonatorName"].ToString();
                    result.DonatorSurName = dataReader["DonatorSurName"].ToString();
                    result.DonatorCitizenId = dataReader["DonatorCitizenId"].ToString();
                    result.DonatorRegisterNo = dataReader["DonatorRegisterNo"].ToString();
                    result.DonatorTaxId = dataReader["DonatorTaxId"].ToString();
                    result.HouseNumber = dataReader["HouseNumber"].ToString();
                    result.Soi = dataReader["Soi"].ToString();
                    result.Road = dataReader["Road"].ToString();
                    result.Moo = dataReader["Moo"].ToString();
                    result.Building = dataReader["Building"].ToString();
                    result.Tambon = dataReader["Tambon"].ToString();
                    result.Amphur = dataReader["Amphur"].ToString();
                    result.Province = dataReader["Province"].ToString();
                    result.ZipCode = dataReader["ZipCode"].ToString();
                    result.Telephone = dataReader["Telephone"].ToString();
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
