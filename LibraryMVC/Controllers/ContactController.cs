using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Models;
namespace LibraryMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Msg(Contact log)
        {

            Contact objConnection = new Contact();
            String query= "insert into Contact(Name,Email,Subject,Message) values('" + log.SName + "','" + log.SEmail + "','" + log.Subject + "','"+log.Msg+"')";
            objConnection.InsDelUpdt(query);
            return View("Message");


        }


    }
}