using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvisFormation.Outils.Extension;

namespace Avis.Data
{
    public class AvisSave : Avis
    {
        public AvisSave()
        {

        }
        public AvisSave(string idFormation, string note)
        {
            _idFormationStr = idFormation;
            _noteStr = note;
        }
        public string NomSeo { get; set; }
        public string Commentaire { get; set; }
        private string _idFormationStr;
        private string _noteStr;
        public string IdFormationStr
        {
            get { return _idFormationStr; }

            set
            {
                int id = value.IntParseString();
                if (id > 0)
                    base.IdFormation = id;

                _idFormationStr = value;

            }
        }
        public string NoteStr
        {
            get { return _noteStr; }

            set
            {
                double id = value.DoubleParseString();
                if (id > 0)
                    base.Note = id;
                _noteStr = value;

            }
        }

    }
}
