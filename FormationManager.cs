using Avis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avis.Logic
{
    public class FormationManager
    {

        public List<Formation> ObtenirFormations()
        {
            List<Formation> ToutesFormations = null;
            using (var context = new AvisEntities())
            {

                if (context.Formation.Any())
                {
                    ToutesFormations = new List<Formation>();
                    ToutesFormations = context.Formation.ToList();
                }

            }
            return ToutesFormations;
        }


        /// <summary>
        /// Affichage de 4 formations au hazard sur la page d'accueil
        /// </summary>
        public List<DetailFormation> ObtenirDetailFormations()
        {
            var detailFormationListe = new List<DetailFormation>();
            using (var context = new AvisEntities())
            {
                List<Formation> formation = context.Formation.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
                foreach (Formation formationdetail in formation)
                {
                    DetailFormation detailsFormations = ObtenirDetailsFormation(formationdetail.NomSeo);
                    if (detailsFormations != null)
                        detailFormationListe.Add(detailsFormations);
                }
            }
            return detailFormationListe;

        }

        public DetailFormation ObtenirDetailsFormation(string nomSeo)
        {
            DetailFormation detailFormationEntity = null;
            using (var context = new AvisEntities())
            {

                Formation detailEntity = context.Formation.SingleOrDefault(f => f.NomSeo == nomSeo);

                if (detailEntity != null)
                {
                    detailFormationEntity = new DetailFormation(detailEntity) { MoyenneDesVotes = 0, NombreVotant = 0 };

                    if (detailEntity.Avis.Any())
                    {
                        detailFormationEntity.MoyenneDesVotes = Math.Round(detailEntity.Avis.Average(a => a.Note),1);
                        detailFormationEntity.NombreVotant = detailEntity.Avis.Count();
                        detailFormationEntity.Avis = detailEntity.Avis.ToList();
                    }

                }

            }
            return detailFormationEntity;
        }

        public static bool ObtenirFormation(string nomSeo, out Formation formation)
        {
            formation = null;
            using (var context = new AvisEntities())
            {
                var formationContext = context.Formation.SingleOrDefault(f => string.Compare(f.NomSeo, nomSeo, true) == 0);
                if (formationContext != null)
                {
                    formation = formationContext;
                    return true;
                }
                return false;

            }

        }
    }
}
