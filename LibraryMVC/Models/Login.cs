using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryMVC.Models
{
    public class Login
    {

        // database connection with user name or password to validate the user name or password 
        public String SName { get; set; }
        public String SPassword { get; set; }


        //global declaration of the variable 
        SqlConnection connection;
        String connection_String = "Data Source=LAPTOP-TUCRR34F\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
        SqlCommand command;
        SqlDataReader Datareader;

        // implemtneting the method of the interface
        //using the concept of oops define a single method that is used to insert delete and update the record in the table 
        public void InsDelUpdt(String qry)
        {

            connection = new SqlConnection(connection_String);
            connection.Open();
            command = new SqlCommand(qry, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        // user define method that is used to get the record from the table
        public DataTable Srch(String qry)
        {
            DataTable tbl = new DataTable();


            connection = new SqlConnection(connection_String);

            connection.Open();
            command = new SqlCommand(qry, connection);

            Datareader = command.ExecuteReader();

            tbl.Load(Datareader);

            connection.Close();

            return tbl;
        }



    }
}