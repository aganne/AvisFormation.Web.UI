using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avis.Data;
using Microsoft.SqlServer.Server;

namespace Avis.Logic
{
    public class AvisManager
    {
        public void AjouterAvis(Avis.Data.Avis avis)
        {
            using (var context = new AvisEntities())
            {
                context.Avis.Add(avis);
                context.SaveChanges();
            }
        }

        public List<Avis.Data.Avis> ObtenirAvis(int trainingId)
        {
            List<Avis.Data.Avis> TousAvis = null;
            using (var context = new AvisEntities())
            {

                if (context.Avis.Any(a => a.IdFormation == trainingId))
                {
                    TousAvis = new List<Avis.Data.Avis>();
                    TousAvis = context.Avis.Where(a => a.IdFormation == trainingId).ToList();
                }

            }
            return TousAvis;
        }

        public List<DetailAvis> ObtenirTousLesAvis()
        {
            List<DetailAvis> derniersAvisListe = null;
            using (var context = new AvisEntities())
            {

                if (context.Avis.Any())
                {
                    derniersAvisListe = new List<DetailAvis>();
                    var derniersAvis = context.Avis.OrderByDescending(a=>a.DateAvis).Take(10).ToList();
                    if (derniersAvis!=null)
                    {
                        foreach (Avis.Data.Avis item in derniersAvis)
                        {
                            DetailAvis da = new DetailAvis(item.DateAvis);
                            da.Formation = new Formation();
                            da.Formation.Nom = item.Formation.Nom;
                            da.Description = item.Description;
                            da.Nom = item.Nom;
                            derniersAvisListe.Add(da);
                        }
                    }
                   
                }

            }
            return derniersAvisListe;
        }
    }
}
