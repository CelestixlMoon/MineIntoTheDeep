using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace IA_zinzin.CoucheReseau
{   
    public class Network
    {
        private TcpClient client; //canal de discussion entre le client et le serveur 
        private StreamReader fluxEntrant; //objet en charge d’écouter ce que le serveur dit (écouter)
        private StreamWriter fluxSortant; //objet en charge de transmettre les messages au serveur (parler)

        /// <summary>
        /// initialiser l’attribut ”client” en appelant le constructeur de la classe TcpClient
        /// </summary>
        private void Connexion()
        {
            client = new TcpClient("127.0.0.1", 1234);
        }

        /// <summary>
        /// initialiser successivement les deux attributs ”fluxEntrant” et ”fluxSortant” en appelant respectivement les constructeurs des classes StreamReader(pour fluxEntrant) et StreamWriter(pour fluxSortant)
        /// </summary>
        private void CreationFlux()
        {
            fluxEntrant = new StreamReader(client.GetStream());
            fluxSortant = new StreamWriter(client.GetStream());
            fluxSortant.AutoFlush = true;
        }

        /// <summary>
        /// Permet de lire le message du serveur et le renvoie et l'écrit dans la console
        /// </summary>
        /// <returns>message du serveur</returns>
        public string LectureMessageRecu()
        {
            string messageRecu = "";
            // Attendre jusqu'à ce que le serveur envoie un message initial
            messageRecu = this.fluxEntrant.ReadLine();
            Console.WriteLine("<< " + messageRecu);

            return messageRecu;
        }

        /// <summary>
        /// Envoie un message au serveur et l'écrit dans la console
        /// </summary>
        /// <param name="messageAEnvoyer">message à envoyer au serveur</param>
        public void EnvoyerMessage(string messageAEnvoyer)
        {
            //Envoie du message de réponse
            this.fluxSortant.WriteLine(messageAEnvoyer);
            Console.WriteLine(">> " + messageAEnvoyer);
        }

        private bool estConnecte=false;
        /// <summary>
        /// Connecte au serv et indique qu'on est connecté
        /// </summary>
        private void ConnexionServ()
        {

            //Mise en place de la connexion avec le serveur
            this.Connexion();
            this.CreationFlux();
            estConnecte = true;
        }

        private bool nomEnvoyé = false;

        /// <summary>
        /// Méthode du départ qui envoie le nom de l'équipe
        /// </summary>
        /// <param name="messageRecu">Message du serveur</param>
        public void Start()
        {
            //Connexion au serv si pas déja connecté
            if (!estConnecte) { ConnexionServ(); }


            string messageAEnvoyer = "";

            //Lecture du message du serveur
            String messageRecu = LectureMessageRecu();

            //Verification que la partie a commencé et qu'on n'aie pas déja envoyé le nom de l'équipe
            if (messageRecu == "DEBUT_PARTIE" && !nomEnvoyé)
            {
                //Envoie le nom de l'équipe
                messageAEnvoyer = "Zinzin";
                Console.WriteLine("-- Début de la transmission, nom transmis --");

                //Envoie du message de réponse
                EnvoyerMessage(messageAEnvoyer);

                //Lecture de réponse
                LectureMessageRecu();

                //Le nom de l'équipe est donc envoyé
                nomEnvoyé=true;

                //Rappel de la méthode pour passer au tour suivant
                Start();
            }

            //Si le tour a commencé
            else if (messageRecu.StartsWith("DEBUT_TOUR"))
            {
                //Lancement du programme des tours
                GestionTour(messageRecu);
            }

            //Si on a deja envoyé le nom de l'équipe alors on passe a la gestion des tours
            else
            {
                string messageRecu2 = LectureMessageRecu();
                while (messageRecu2 != "DEBUT_TOUR")
                {
                    LectureMessageRecu();
                    Start();
                }
                //Le tour a commencé donc on peut appeler la méthode qui gère les actions de tour
                GestionTour(LectureMessageRecu());
            }
        }

        /// <summary>
        /// Va gérer les différentes actions à chaque tour
        /// </summary>
        /// <param name="messageRecu">Message recu du serv pour récuperer numéro du tour</param>
        public void GestionTour(string messageRecu)
        {
            //Deplace et passe le tour
            EnvoyerMessage("DEPLACER|0|1|1");
            EnvoyerMessage("FIN_TOUR");

            //Lecture de réponse
            string NouveauMessageRecu =LectureMessageRecu();

            GestionTour(NouveauMessageRecu);

        }

        public void Stop() 
        {
            //Fermeture de la connexion
            this.client.Close();
        }
    }
}
