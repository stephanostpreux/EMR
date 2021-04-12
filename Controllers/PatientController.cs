using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using EMR_VCT.Models;
using Microsoft.AspNetCore.Authorization;

namespace EMR_VCT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PatientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]


        [HttpPost]
        //[Authorize]
        public JsonResult Post(Patients pat)
        {
            //using (SqlConnection con = new SqlConnection(Globalconnexion.GlobalConnection.ConnectionString))
            //{
                string sqlDataSource = _configuration.GetConnectionString("EmrConn");
                SqlDataReader myReader;
            SqlConnection con = new SqlConnection(sqlDataSource);
            SqlCommand cmd = new SqlCommand("sp_CreatePatient", con);
            
            cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Site_id", SqlDbType.Int).Value = pat.Site_id;
                    cmd.Parameters.Add("@Nihid", SqlDbType.VarChar).Value = pat.Nihid;
                    cmd.Parameters.Add("@Clinic", SqlDbType.VarChar).Value = pat.Clinic;
                    cmd.Parameters.Add("@VisitDate", SqlDbType.Date).Value = pat.VisitDate;
                    cmd.Parameters.Add("@DBODate", SqlDbType.Date).Value = pat.DBODate;
                    cmd.Parameters.Add("@AgeYear", SqlDbType.Int).Value = pat.AgeYear;
                    cmd.Parameters.Add("@AgeMonth", SqlDbType.Int).Value = pat.AgeMonth;
                    cmd.Parameters.Add("@GenderStart", SqlDbType.VarChar).Value = pat.GenderStart;
                    cmd.Parameters.Add("@GenderNow", SqlDbType.VarChar).Value = pat.GenderNow;
                    cmd.Parameters.Add("@SocialSecurityType", SqlDbType.TinyInt).Value = pat.SocialSecurityType;
                    cmd.Parameters.Add("@SocialSecurity", SqlDbType.VarChar).Value = pat.SocialSecurity;
                    cmd.Parameters.Add("@MotherFirstName", SqlDbType.VarChar).Value = pat.MotherFirstName;
                    cmd.Parameters.Add("@MotherLastName", SqlDbType.VarChar).Value = pat.MotherLastName;
                    cmd.Parameters.Add("@CreationUser", SqlDbType.VarChar).Value = pat.CreationUser;


            //Add the output parameter to the command object
            SqlParameter outPutParameter = new SqlParameter();
            outPutParameter = cmd.Parameters.Add("@result", SqlDbType.VarChar, 200);
            //outPutParameter.ParameterName = "@result";
            //outPutParameter.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter.Direction = System.Data.ParameterDirection.Output;
            //cmd.Parameters.Add(outPutParameter);


            con.Open();
                    myReader = cmd.ExecuteReader();
                    
                    con.Close();
                
            
            return new JsonResult(outPutParameter.Value.ToString());
        }
    }
}
