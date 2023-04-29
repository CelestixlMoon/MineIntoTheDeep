using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_zinzin.Action
{
    /// <summary>
    /// Genere un string de l'action demandé
    /// </summary>
    public class Action
    {
        public string Carte()
        {
            return messageaEnvoye;
        }

        public string DeplacerNain(int numNain, int x, int y)
        {
            return "DEPLACER|" + numNain + "|" + x + "|" + y;
        }

        public string RetiterNaim(int numNain)
        {
            return "RETIRER|" + numNain;
        }

        public string Embaucher(int numNain)
        {
            return "EMBAUCHER";
        }

        public string Ameliorer(int numNain)
        {
            return "AMELIORER|" + numNain;
        }

        public string Saboter(int numPlayer)
        {
            return "SABOTER|" + numPlayer;
        }

        public string Scores()
        {
            return messageaEnvoye;
        }

        public string Sonar()
        {
            return messageaEnvoye;
        }


    }
}
