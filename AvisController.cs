using Avis.Data;
using AvisFormation.Web.UI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.Web.UI.Controllers
{
    public class AvisController : Controller
    {
        [Authorize] // GET: Avis
        public ActionResult LaisserUnAvis(string nomSeo)
        {
            if (!string.IsNullOrWhiteSpace(nomSeo))
            {
                var avis = new LaissezUnAvisViewModel(nomSeo);
                if (avis.Formation != null)
                {
                    return View(avis);
                }
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");


        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveComment(AvisSave avis)
        {

            Avis.Data.Avis nouvelAvis = new Avis.Data.Avis();
            nouvelAvis.IdFormation = avis.IdFormation;
            nouvelAvis.DateAvis = DateTime.Now;
            nouvelAvis.Description = avis.Description;
            nouvelAvis.Nom = User.Identity.GetUserName();
            nouvelAvis.Note = avis.Note;
            nouvelAvis.UserId = User.Identity.GetUserId();

            if (!EstAutoriseACommenter(nouvelAvis))
            {
                TempData["Message"] = "Désolé, un seul avis par formation par compte utilisateur !";
                return RedirectToAction("Error", "Erreur");
            }

            using (var context = new AvisEntities())
            {
                
                context.Avis.Add(nouvelAvis);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home", null);
        }

        private bool EstAutoriseACommenter(Avis.Data.Avis avisSave)
        {  
            var avisManager = new LaissezUnAvisViewModel();
            return avisManager.EstAutoriserAcommenter(avisSave);
           
        }
        // GET: Avis
        public ActionResult AfficherAvis()
        {
            AfficherAvisViewModels vm = new AfficherAvisViewModels();
            return View(vm);


        }

    }
}