using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Models;
namespace LibraryMVC.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
       private MemberBookEntity db = new MemberBookEntity();
        public ActionResult ViewMember()
        {
            return View(db.Members.ToList());
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Member studentToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            db.Members.Add(studentToCreate);
            db.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("ViewMember");


        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            var studentToEdit = (from m in db.Members where m.id== id select m).First();
            return View(studentToEdit);
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(Member studentToEdit)
        {
            var orignalRecord = (from m in db.Members where m.id == studentToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            db.Entry(orignalRecord).CurrentValues.SetValues(studentToEdit);

            db.SaveChanges();
            return RedirectToAction("ViewMember");

        }

        // GET: Member/Delete/5
        public ActionResult Delete(Member studentToDelete)
        {
            var d = db.Members.Where(x => x.id == studentToDelete.id).FirstOrDefault();
            db.Members.Remove(d);
            db.SaveChanges();

            return View("ViewMember");
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
