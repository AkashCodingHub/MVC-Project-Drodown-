using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FetchCeudDependices.Models
{
  
        public class BAL
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RRP3MVI\\SQLEXPRESS;Initial Catalog=MVCcrudado;Integrated Security=True;Encrypt=False;");
        private int UserId;

        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Gender { get;  set; }
        public string CountryName { get;  set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }

        public void Save(User obj)
          {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCcrudado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SaveUser");
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Age", obj.Age);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@CountryName", obj.CountryName);
            cmd.Parameters.AddWithValue("@StateIName", obj.StateIName);
            cmd.Parameters.AddWithValue("@CityName", obj.CityName);
            cmd.ExecuteNonQuery();
            con.Close();
           }



        public DataSet Country()
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("MVCcrudado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", "Country");
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                con.Close();
                return ds;
            }

            public DataSet State(User obj)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("MVCcrudado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", "State");
                cmd.Parameters.AddWithValue("@CountryId", obj.CountryId);
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                DataSet ds2 = new DataSet();
                adpt.Fill(ds2);
                con.Close();
                return ds2;


            }
            public DataSet City(User obj)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("MVCcrudado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", "City");
                cmd.Parameters.AddWithValue("@StateId", obj.StateId);
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                DataSet ds2 = new DataSet();
                adpt.Fill(ds2);
                con.Close();
                return ds2;



            }

        public void UpdateUser(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCcrudado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateData");
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Age", obj.Age);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@CountryName", obj.CountryName);
            cmd.Parameters.AddWithValue("@StateIName", obj.StateIName);
            cmd.Parameters.AddWithValue("@CityName", obj.CityName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable Fetch()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCcrudado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SelectData");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }


        public DataTable FetchUserDetails(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCcrudado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "FetchUserDetails");
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }


        //public User GetEmployeeId(int id)
        //{
        //    con.Open();
        //    User obj = null;
        //    SqlCommand cmd = new SqlCommand("MVCcrudado", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@flag", "FetchUserDetails");
        //    cmd.Parameters.AddWithValue("@id", id);
        //    SqlDataReader dr= cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        obj = new User();
        //        {
        //        UserId = Convert.ToInt32(dr["UserId"]);
        //        Name = dr["Name"].ToString();
        //        Email = dr["Email"].ToString();
        //        Gender = dr["Gender"].ToString();
        //        CountryName = dr["CountryName"].ToString();
        //        StateName = dr["StateName"].ToString();
        //        CityName = dr["CityName"].ToString();
        //        Address = dr["Address"].ToString();
        //    };
        //}
        //con.Close();
        //    return obj;
        // }

        public DataTable DeleteUser(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCcrudado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeleteData");
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
    }
}






