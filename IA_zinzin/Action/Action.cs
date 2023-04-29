using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IA_zinzin.CoucheReseau;
using static IA_zinzin.CoucheReseau.Network;

namespace IA_zinzin.Action
{
    /// <summary>
    /// Genere un string de l'action demandé
    /// </summary>
    public class Action

    {


        //En gros ces fonctions ne font pas les actions mais elle génere le string qui réalise l'action
        //Pour Deplacer un nain par exemple il fait :
        //EnvoyerMessage(DeplacerNain(0,1,2));
        public string Carte()
        {
            EnvoyerMessage("CARTE");
            return LectureMessageRecu();
        }

        public string DeplacerNain(int numNain, int x, int y)
        {
            return "DEPLACER|" + numNain + "|" + x + "|" + y;
        }

        public string RetiterNain(int numNain)
        {
            return "RETIRER|" + numNain;
        }

        public void RetirerTout()
        {
            EnvoyerMessage("RETIRER|1");
            EnvoyerMessage("RETIRER|2");
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
            EnvoyerMessage("SCORES");
            return LectureMessageRecu();
        }

        public string Sonar()
        {
            EnvoyerMessage("SONAR");
            return LectureMessageRecu();
        }

        public void FinDeTour()
        {
            EnvoyerMessage("FIN_TOUR");
        }

    }
}
