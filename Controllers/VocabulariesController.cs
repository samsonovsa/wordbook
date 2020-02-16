using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordBook.Services.DataServices;
using WordBook.Models;

namespace WordBook.Controllers
{
    public class VocabulariesController : Controller
    {
        IGenericRepository<Vocabulary> _vocabularies;

        public VocabulariesController(IGenericRepository<Vocabulary> repository)
        {
            _vocabularies = repository;
        }
        // GET: Vocabularies
        public ActionResult Index()
        {
            return View(_vocabularies.GetAllAsync());
        }

        // GET: Vocabularies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vocabularies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vocabularies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vocabularies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vocabularies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vocabularies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vocabularies/Delete/5
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
