using System;
using System.Data.SqlClient;

namespace WebApplication1.Models
{

    public class StaffDetail
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
    public class StaffDetailModel
    {
        private readonly string ConnStr = "Data Source = localhost\\SQLEXPRESS;Initial Catalog = Test; Integrated Security = True";

        /// <summary>
        /// �s�W���u����
        /// </summary>
        /// <param name="card"></param>
        public void AddStaffDetail(StaffDetail staffdetail)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @" INSERT INTO ppm99$
                             ( ppm99_stfn
                             , ppm99_name
                             , ppm99_jdate
                             , ppm99_gender
                             , ppm99_military
                             , ppm99_transportList
                             , ppm99_city
                             , ppm99_zone
                             , ppm99_addr
                             )
                        VALUES
                             ( @ppm99_stfn
                             , @ppm99_name
                             , @ppm99_jdate
                             , @ppm99_gender
                             , @ppm99_military
                             , @ppm99_transportList
                             , @ppm99_city
                             , @ppm99_zone
                             , @ppm99_addr
                             )");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_stfn", (object)staffdetail.ppm99_stfn ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_name", (object)staffdetail.ppm99_name ?? DBNull.Value));
            if (DateTime.TryParse(staffdetail.ppm99_jdate, out DateTime jdate))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ppm99_jdate", jdate));
            }
            else
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ppm99_jdate", DBNull.Value));
            }
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_gender", (object)staffdetail.ppm99_gender ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_military", (object)staffdetail.ppm99_military ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_transportList", (object)staffdetail.ppm99_transportList ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_city", (object)staffdetail.ppm99_city ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_zone", (object)staffdetail.ppm99_zone ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_addr", (object)staffdetail.ppm99_addr ?? DBNull.Value));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        /// <summary>
        /// ���o���u����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StaffDetail GetStaffDetail(int id)
        {
            StaffDetail ppm99 = new StaffDetail();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
               @"   SELECT *
                      FROM ppm99$
                     WHERE ppm99_stfn = @id"
               );
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ppm99 = new StaffDetail
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
                }
            }
            else
            {
                Console.WriteLine("��Ʈw���šI");
            }
            sqlConnection.Close();
            return ppm99;
        }

        /// <summary>
        /// ��s���u����
        /// </summary>
        /// <param name="staffdetail"></param>
        public void UpdateStaffDetail(StaffDetail staffdetail)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
               @"  UPDATE ppm99$
                      SET ppm99_stfn = @ppm99_stfn
                        , ppm99_name = @ppm99_name
                        , ppm99_jdate = @ppm99_jdate
                        , ppm99_gender = @ppm99_gender
                        , ppm99_military = @ppm99_military
                        , ppm99_transportList = @ppm99_transportList
                        , ppm99_city = @ppm99_city
                        , ppm99_zone = @ppm99_zone
                        , ppm99_addr = @ppm99_addr
                    WHERE ppm99_stfn = @ppm99_stfn"
               );
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_stfn", (object)staffdetail.ppm99_stfn ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_name", (object)staffdetail.ppm99_name ?? DBNull.Value));
            if (DateTime.TryParse(staffdetail.ppm99_jdate, out DateTime jdate))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ppm99_jdate", jdate));
            }
            else
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ppm99_jdate", DBNull.Value));
            }
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_gender", (object)staffdetail.ppm99_gender ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_military", (object)staffdetail.ppm99_military ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_transportList", (object)staffdetail.ppm99_transportList ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_city", (object)staffdetail.ppm99_city ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_zone", (object)staffdetail.ppm99_zone ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_addr", (object)staffdetail.ppm99_addr ?? DBNull.Value));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
    }
}