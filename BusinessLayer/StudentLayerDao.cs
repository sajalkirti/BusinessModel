using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace BusinessLayer
{
    public class StudentLayerDao
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public IEnumerable<Students> Studentlist
        {
            get 
            {
                List<Students> students = new List<Students>();
                using (MySqlConnection conn = new MySqlConnection(CS))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "spGetStudentAll";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Students st = new Students()
                        {
                            name = rdr["name"].ToString(),
                            className = rdr["class"].ToString(),
                            sid = Convert.ToInt32(rdr["sid"]),
                            semester = rdr["semester"].ToString()
                        };
                        students.Add(st);
                    }
                    return students;
                }
            }
        }
    }
}
