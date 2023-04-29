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

        /// <summary>
        /// Prend l'id du nain et les coordonnée et retourne le string qui réalise l'action
        /// </summary>
        /// <param name="numNain"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string DeplacerNain(int numNain, int x, int y)
        {
            return "DEPLACER|" + numNain + "|" + x + "|" + y;
        }

        /// <summary>
        /// Retire le nain donnée en paramètre et retourne le string
        /// </summary>
        /// <param name="numNain"></param>
        /// <returns></returns>
        public string RetirerNain(int numNain)
        {
            return "RETIRER|" + numNain;
        }

        /// <summary>
        /// Retire les deux nains
        /// </summary>
        public void RetirerTout()
        {
            EnvoyerMessage("RETIRER|1");
            EnvoyerMessage("RETIRER|2");
        }

        /// <summary>
        /// Embauche un nain
        /// </summary>
        /// <param name="numNain"></param>
        /// <returns></returns>
        public string Embaucher(int numNain)
        {
            return "EMBAUCHER";
        }

        /// <summary>
        /// Améliore le nain donné en entrée
        /// </summary>
        /// <param name="numNain"></param>
        /// <returns></returns>
        public string Ameliorer(int numNain)
        {
            return "AMELIORER|" + numNain;
        }

        /// <summary>
        /// Sabote le joueur donnée en paramètre
        /// </summary>
        /// <param name="numPlayer"></param>
        /// <returns></returns>
        public string Saboter(int numPlayer)
        {
            return "SABOTER|" + numPlayer;
        }

        /// <summary>
        /// Retourne le string du score
        /// </summary>
        /// <returns></returns>
        public string Scores()
        {
            EnvoyerMessage("SCORES");
            return LectureMessageRecu();
        }

        /// <summary>
        /// Retourne le string du sonare
        /// </summary>
        /// <returns></returns>
        public string Sonar()
        {
            EnvoyerMessage("SONAR");
            return LectureMessageRecu();
        }

        /// <summary>
        /// Termine le tour
        /// </summary>
        public void FinDeTour()
        {
            EnvoyerMessage("FIN_TOUR");
        }

    }
}
