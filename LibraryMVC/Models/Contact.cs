using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace LibraryMVC.Models
{
    public class Contact
    {
        //global declaration of the variable 
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader Datareader;

        String connection_String = "Data Source=LAPTOP-TUCRR34F\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";


        // database connection with user name or password to validate the user name or password 
        public String SName { get; set; }
        public String SEmail { get; set; }
        public String Subject { get; set; }
        public String Msg { get; set; }

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



    }
}