﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GranjaSystem.Models;

namespace GranjaSystem.Controllers
{
    public class VacunasLotesController : Controller
    {
        private DB_A460EB_PruebasNGS2Entities db = new DB_A460EB_PruebasNGS2Entities();

        // GET: VacunasLotes
        public ActionResult Index(int? id)
        {
            
            var vacunasLote = db.VacunasLotes.Include(t => t.tblLotes);
            return View(vacunasLote.ToList());
        }

        // GET: VacunasLotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVacunasLotes tblVacunasLote = db.VacunasLotes.Find(id);
            if (tblVacunasLote == null)
            {
                return HttpNotFound();
            }
            

            return View(tblVacunasLote);
        }

        // GET: VacunasLotes/Create
        public ActionResult Create(int? id)
        {
            ViewBag.idL = id;
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote");
            return View();
        }

        // POST: VacunasLotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVacunaLote,IdLote,FechaVacuna,Vacuna,Descripcion")] tblVacunasLotes tblVacunasLote,int IdLotes)
        {
            if (ModelState.IsValid)
            {
                tblVacunasLote.IdLote = IdLotes;
                db.VacunasLotes.Add(tblVacunasLote);
                db.SaveChanges();
                return RedirectToAction("Index", "DetalleLotes", new { id = tblVacunasLote.IdLote });
            }

            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
            return RedirectToAction("Index", "DetalleLotes", new { id = tblVacunasLote.IdLote });
        }

        // GET: VacunasLotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVacunasLotes tblVacunasLote = db.VacunasLotes.Find(id);
            if (tblVacunasLote == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
            return View(tblVacunasLote);
        }

        // POST: VacunasLotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVacunaLote,IdLote,FechaVacuna,Vacuna,Descripcion")] tblVacunasLotes tblVacunasLote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVacunasLote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
            return View(tblVacunasLote);
        }

        // GET: VacunasLotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVacunasLotes tblVacunasLote = db.VacunasLotes.Find(id);
            if (tblVacunasLote == null)
            {
                return HttpNotFound();
            }
            return View(tblVacunasLote);
        }

        // POST: VacunasLotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVacunasLotes tblVacunasLote = db.VacunasLotes.Find(id);
            db.VacunasLotes.Remove(tblVacunasLote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
