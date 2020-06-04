using Avis.Data;
using Avis.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisFormation.Web.UI.Models
{
    public class LaissezUnAvisViewModel
    {
        public Formation Formation { get; set; } = null;
        public AvisManager AvisManager { get; set; } = new AvisManager();
        public LaissezUnAvisViewModel()
        {
            
        }
        public LaissezUnAvisViewModel(string nomseo)
        {
            Formation formation = null;
            if (FormationManager.ObtenirFormation(nomseo, out formation))
                this.Formation = formation;

        }

        public bool EstAutoriserAcommenter(Avis.Data.Avis avisSave)
        {
            using (var context=new AvisEntities())
            {
                return !context.Avis.Any(avis => avis.IdFormation == avisSave.IdFormation && avis.UserId == avisSave.UserId);
            }
            
        }
    }
}