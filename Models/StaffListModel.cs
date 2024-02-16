using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace WebApplication1.Models
{

        public class StaffList
    {
            public string ppm99_stfn { get; set; }
            public string ppm99_name { get; set; }
            public string ppm99_jdate { get; set; }
            public string ppm99_gender { get; set; }
            public string ppm99_military { get; set; }
            public string ppm99_transportList { get; set; }
            public string ppm99_city { get; set; }
            public string ppm99_zone { get; set; }
            public string ppm99_addr { get; set; }
        }
        public class StaffListModel
        {
        private readonly string ConnStr = "Data Source = localhost\\SQLEXPRESS;Initial Catalog = Test; Integrated Security = True";

        /// <summary>
        /// 取的員工資料清單
        /// </summary>
        /// <returns></returns>
        public List<StaffList> GetStaffList()
        {
            List<StaffList> stafflist = new List<StaffList>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ppm99$");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StaffList stafflistdetail = new StaffList
                    {
                        ppm99_stfn = reader.IsDBNull(reader.GetOrdinal("ppm99_stfn")) ? null : reader.GetDouble(reader.GetOrdinal("ppm99_stfn")).ToString(),
                        ppm99_name = reader.IsDBNull(reader.GetOrdinal("ppm99_name")) ? null : reader.GetString(reader.GetOrdinal("ppm99_name")),
                        ppm99_jdate = reader.IsDBNull(reader.GetOrdinal("ppm99_jdate")) ? null : reader.GetDateTime(reader.GetOrdinal("ppm99_jdate")).ToString("yyyyMMdd"),
                        ppm99_gender = reader.IsDBNull(reader.GetOrdinal("ppm99_gender")) ? null : reader.GetString(reader.GetOrdinal("ppm99_gender")),
                        ppm99_military = reader.IsDBNull(reader.GetOrdinal("ppm99_military")) ? null : reader.GetString(reader.GetOrdinal("ppm99_military")),
                        ppm99_transportList = reader.IsDBNull(reader.GetOrdinal("ppm99_transportList")) ? null : reader.GetString(reader.GetOrdinal("ppm99_transportList")),
                        ppm99_city = reader.IsDBNull(reader.GetOrdinal("ppm99_city")) ? null : reader.GetString(reader.GetOrdinal("ppm99_city")),
                        ppm99_zone = reader.IsDBNull(reader.GetOrdinal("ppm99_zone")) ? null : reader.GetDouble(reader.GetOrdinal("ppm99_zone")).ToString(),
                        ppm99_addr = reader.IsDBNull(reader.GetOrdinal("ppm99_addr")) ? null : reader.GetString(reader.GetOrdinal("ppm99_addr")),
                    };
                    stafflist.Add(stafflistdetail);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();

            return stafflist;
        }
    }
}
