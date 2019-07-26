using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Models;
namespace LibraryMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //this method is used to validte the user name or password of the user after verfiying the both the control will  transfer to another page 
        public ActionResult validate(Login log)
        {

            Login objConnection = new Login();
            String query = "select * from Admin where SName='" + log.SName + "' and SPassword='" + log.SPassword + "'";
            DataTable tbl = new DataTable();
            tbl = objConnection.Srch(query);

            if (tbl.Rows.Count > 0)
            {

                return View("AdminZone");
            }
            else
            {
                return View("WrongPassword");
            }

        }
    }
}