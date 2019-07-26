using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Models;
namespace LibraryMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private MemberBookEntity dbtest = new MemberBookEntity();
        public ActionResult ViewBook()
        {
            return View(dbtest.BOoks.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] BOok BookID)
        {

            if (!ModelState.IsValid)
                return View();
            dbtest.BOoks.Add(BookID);
            dbtest.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("ViewBook");

        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var BookToEdit = (from m in dbtest.BOoks where m.id== id select m).First();

            return View(BookToEdit);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BOok BookToEdit)
        {
            var orignalRecord = (from m in dbtest.BOoks where m.id == BookToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            dbtest.Entry(orignalRecord).CurrentValues.SetValues(BookToEdit);

            dbtest.SaveChanges();
            return RedirectToAction("ViewBook");



        }

        // GET: Book/Delete/5
        public ActionResult Delete(BOok BookID)
        {
            var d = dbtest.BOoks.Where(x => x.id == BookID.id).FirstOrDefault();
            dbtest.BOoks.Remove(d);
            dbtest.SaveChanges();
            return RedirectToAction("ViewBook");
        }

        // POST: Book/Delete/5
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
