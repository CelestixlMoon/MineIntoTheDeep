using IA_zinzin.Metier.Carte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_zinzin.Metier
{
    public class Nain
    {
        /// <summary>
        /// Numero de nain
        /// </summary>
        private int id;

        /// <summary>
        /// Niveau de la pioche (0 à 2)
        /// </summary>
        private int pioche=0;

        /// <summary>
        /// Coordonnées du nain
        /// </summary>
        private Case coordonnees;

        /// <summary>
        /// Numero de nain
        /// </summary>
        public int ID
        { 
            get { return id; } 
            set { id = value; } 
        }

        public int Pioche
        { get { return pioche; } set { pioche = value; } }

        public Case Coordonnees
        { get { return coordonnees; } }

        public Nain() 
        {

            
        }

    }
}
