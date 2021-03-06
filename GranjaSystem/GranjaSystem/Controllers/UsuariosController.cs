﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GranjaSystem.Models;

namespace GranjaSystem.Controllers
{
    public class UsuariosController : Controller
    {
        private DB_A460EB_PruebasNGS2Entities db = new DB_A460EB_PruebasNGS2Entities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(t => t.tblEmpleados).Include(t => t.tblRoles);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado");
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Clave,IdEmpleado,IdRol")] tblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                tblUsuarios.Clave = Encriptar(tblUsuarios.Clave);
                db.Usuarios.Add(tblUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Clave,IdEmpleado,IdRol")] tblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                tblUsuarios.Clave = Encriptar(tblUsuarios.Clave);
                db.Entry(tblUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(tblUsuarios);
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
        public string Encriptar(string Pass)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            Byte[] Hash, InsertarByte;
            InsertarByte = (new UnicodeEncoding()).GetBytes(Pass);
            Hash = sha1.ComputeHash(InsertarByte);
            return Convert.ToBase64String(Hash);
        }
    }

}
