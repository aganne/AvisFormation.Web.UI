using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avis.Data
{
    public class DetailFormation : Formation
    {
        public DetailFormation()
        {

        }
        public DetailFormation(Formation formation)
        {
            base.Nom = formation.Nom;
            base.Id = formation.Id;
            base.Url = formation.Url;
            base.Description = formation.Description;
            base.NomSeo = formation.NomSeo;
            base.Avis = new List<Avis>();
        }
        public double MoyenneDesVotes { get; set; } = 0;
        public int NombreVotant { get; set; } = 0;

    }
}
