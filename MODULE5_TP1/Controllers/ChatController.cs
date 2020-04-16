using MODULE5_TP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MODULE5_TP1.Controllers
{
    public class ChatController : Controller
    {
        static List<Chat> meuteDechats = Models.Data.Instance.ListeChats;

        // GET: Chat
        public ActionResult Index()
        {
            return View(meuteDechats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chatAAfficher = meuteDechats.Where(c => c.Id == id).FirstOrDefault();
            return View(chatAAfficher);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat chatToRemove = meuteDechats.Where(c => c.Id == id).FirstOrDefault();
                meuteDechats.Remove(chatToRemove);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
