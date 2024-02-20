using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace WebApplication1.Models
{

    public class StaffListModel
    {
        private readonly string ConnStr = "Data Source = localhost\\SQLEXPRESS;Initial Catalog = Test; Integrated Security = True";

        /// <summary>
        /// 員工資料清單
        /// </summary>
        public List<Staff>StaffList { get; private set; }

        public class Staff
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

        /// <summary>
        /// 取的員工資料清單
        /// </summary>
        /// <returns></returns>
        public bool GetStaffList()
        {
            List<Staff> stafflist = new List<Staff>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ppm99$");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Staff stafflistdetail = new Staff
                    {
                        ppm99_stfn = reader.IsDBNull(reader.GetOrdinal("ppm99_stfn")) ? null : reader.GetDouble(reader.GetOrdinal("ppm99_stfn")).ToString(),
                        ppm99_name = reader.IsDBNull(reader.GetOrdinal("ppm99_name")) ? null : reader.GetString(reader.GetOrdinal("ppm99_name")),
                        ppm99_jdate = reader.IsDBNull(reader.GetOrdinal("ppm99_jdate")) ? null : reader.GetString(reader.GetOrdinal("ppm99_jdate")),
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

                return false;
            }
            sqlConnection.Close();

            StaffList = stafflist;

            return true;
        }

        ///// <summary>
        ///// 取得員工分頁清單
        ///// </summary>
        ///// <returns></returns>
        //public bool GetStaffPageList()
        //{
        //    int page = 1;
        //    int pageSize = 5;
        //
        //    if (StaffList == null || !StaffList.Any())
        //    {
        //        return false;
        //    }
        //
        //    StaffList.OrderBy(x => x.ppm99_stfn).ToPagedList(page, pageSize);
        //
        //    return true;
        //}
    }
}