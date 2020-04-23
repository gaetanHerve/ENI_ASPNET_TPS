using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MODULE6_TP1.Data;
using MODULE6_TP1.Models;
using MODULE6_TP1_BO;

namespace MODULE6_TP1.Controllers
{
    public class SamouraisController : Controller
    {
        private MODULE6_TP1Context db = new MODULE6_TP1Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiVM samouraiVm = new SamouraiVM()
            {
                Samourai = new Samourai(),
                ArmesDisponibles = db.Armes.Where(a => a.Samourai == null).ToList(),
                ArtsDisponibles = db.ArtMartials.ToList()
            };
            return View(samouraiVm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM samouraiVm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = new Samourai()
                {
                    Nom = samouraiVm.Samourai.Nom,
                    Force = samouraiVm.Samourai.Force,
                    Arme = db.Armes.SingleOrDefault(a => a.Id == samouraiVm.IdArme)
                };
                if (samouraiVm.IdsSelectedArts.Count > 0)
                {
                    samourai.ArtsMartiaux = db.ArtMartials.Where(adb => samouraiVm.IdsSelectedArts.Any(avm => avm == adb.Id)).ToList();
                }
                db.Samourais.Add(samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samouraiVm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*Samourai samourai = db.Samourais.Find(id);*/
            Samourai samourai = db.Samourais.Include(x => x.Arme).FirstOrDefault(x => x.Id == id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            SamouraiVM samouraiVm = new SamouraiVM()
            {
                Samourai = samourai,
                ArmesDisponibles = db.Armes.Where(a => (a.Samourai == null || a.Samourai.Id == samourai.Id)).ToList(),
                ArtsDisponibles = db.ArtMartials.ToList(),
                // Ajout preselect artsmartiaux
                IdsSelectedArts = samourai.ArtsMartiaux.Select(a => a.Id).ToList()
            };
            if (samourai.Arme != null)
            {
                samouraiVm.IdArme = samourai.Arme.Id;
            }
            return View(samouraiVm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM samouraiVm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.Include(s => s.Arme).Include(s => s.ArtsMartiaux).FirstOrDefault(x => x.Id == samouraiVm.Samourai.Id);
                
                /*db.Samourais.Attach(samourai);*/

                samourai.Nom = samouraiVm.Samourai.Nom;
                samourai.Force = samouraiVm.Samourai.Force;
                if (samouraiVm.IdArme != 0)
                {
                    samourai.Arme = db.Armes.SingleOrDefault(a => a.Id == samouraiVm.IdArme);
                } else
                {
                    samourai.Arme = null;
                }
                if (samouraiVm.IdsSelectedArts.Count > 0)
                {
                    samourai.ArtsMartiaux = db.ArtMartials.Where(adb => samouraiVm.IdsSelectedArts.Any(avm => avm == adb.Id)).ToList();
                }
                
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samouraiVm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
