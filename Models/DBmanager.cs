using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace WebApplication1.Models
{

    public class Ppm99
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
    public class DBmanager
    {
        private readonly string ConnStr = "Data Source = localhost\\SQLEXPRESS;Initial Catalog = Test; Integrated Security = True";

        public List<Ppm99> GetPpmList()
        {
            List<Ppm99> ppm99s = new List<Ppm99>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ppm99$");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Ppm99 ppm99 = new Ppm99
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
                    ppm99s.Add(ppm99);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return ppm99s;
        }

        public void NewCard(Ppm99 card)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
                @" INSERT INTO ppm99$
                               (ppm99_stfn
                               ,ppm99_name
                               ,ppm99_jdate
                               ,ppm99_gender
                               ,ppm99_military
                               ,ppm99_transportList
                               ,ppm99_city
                               ,ppm99_zone
                               ,ppm99_addr
                               )
                        VALUES (
                               @ppm99_stfn
                               ,@ppm99_name
                               ,@ppm99_jdate
                               ,@ppm99_gender
                               ,@ppm99_military
                               ,@ppm99_transportList
                               ,@ppm99_city
                               ,@ppm99_zone
                               ,@ppm99_addr
                               )");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_stfn", (object)card.ppm99_stfn ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_name", (object)card.ppm99_name ?? DBNull.Value));
            if (DateTime.TryParse(card.ppm99_jdate, out DateTime jdate))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ppm99_jdate", jdate));
            }
            else
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ppm99_jdate", DBNull.Value));
            }
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_gender", (object)card.ppm99_gender ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_military", (object)card.ppm99_military ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_transportList", (object)card.ppm99_transportList ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_city", (object)card.ppm99_city ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_zone", (object)card.ppm99_zone ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_addr", (object)card.ppm99_addr ?? DBNull.Value));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Ppm99 GetPpm99Detail(int stfn)
        {
            Ppm99 ppm99 = new Ppm99();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
               @"  SELECT * 
                      FROM ppm99$
                     WHERE ppm99_stfn = @stfn"
               );
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@stfn", stfn));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ppm99 = new Ppm99
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
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return ppm99;
        }

        public void UpdatePpm99Detail(Ppm99 card) {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
               @"  UPDATE  ppm99$
                      SET 
                           ppm99_stfn = @ppm99_stfn
                          ,ppm99_name = @ppm99_name
                          ,ppm99_jdate = @ppm99_jdate
                          ,ppm99_gender = @ppm99_gender
                          ,ppm99_military = @ppm99_military
                          ,ppm99_transportList = @ppm99_transportList
                          ,ppm99_city = @ppm99_city
                          ,ppm99_zone = @ppm99_zone
                          ,ppm99_addr = @ppm99_addr
                     WHERE ppm99_stfn = @ppm99_stfn"
               );
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_stfn", (object)card.ppm99_stfn ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_name", (object)card.ppm99_name ?? DBNull.Value));
            if (DateTime.TryParse(card.ppm99_jdate, out DateTime jdate))
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ppm99_jdate", jdate));
            }
            else
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ppm99_jdate", DBNull.Value));
            }
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_gender", (object)card.ppm99_gender ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_military", (object)card.ppm99_military ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_transportList", (object)card.ppm99_transportList ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_city", (object)card.ppm99_city ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_zone", (object)card.ppm99_zone ?? DBNull.Value));
            sqlCommand.Parameters.Add(new SqlParameter("@ppm99_addr", (object)card.ppm99_addr ?? DBNull.Value));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

    }

}