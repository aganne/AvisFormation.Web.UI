using AvisFormation.Outils.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avis.Data
{
    public class DetailAvis : Avis
    {
        public string TempsDepuisPublication { get; set; }
       
        public DetailAvis(DateTime value)
        {
            TempsDepuisPublication = value.JourDepuisCetteDate();
        }
    
    }
}
