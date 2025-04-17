using System;
using System.Collections.Generic;
using System.IO;

namespace tp3_chronologique
{
    class FctUtiles
    {

        /// <summary>
        /// Permet de lire un fichier texte (exemple : .cvs) et de retournerun
        /// tableau des lignes qu'il contient
        /// </summary>
        /// <param name="chemin">Chemin vers le fichier local à lire</param>
        /// <returns>Un tableau de chaînes contenant les lignes du fichier</returns>
        public static string[] LireLignesFichier(string chemin)
        {
            StreamReader fichier = new StreamReader(chemin);

            // Lecture de l'ensemble du fichier en une seule instruction.
            string contenuFichier = fichier.ReadToEnd();
            fichier.Close();

            // Retrait des "carriage return" ('\r'), s'il y en a.
            contenuFichier = contenuFichier.Replace("\r", "");

            // Création d'un vecteur de chaînes de caractères contenant chaque ligne individuellement.
            // On effectue le Split à l'aide du caractère de retours de ligne '\n'
            string[] tabLignes = contenuFichier.Split('\n'); 

            return tabLignes;
        }

        /// <summary>
        /// Permet de charger la liste complète des faits du jeu
        /// </summary>
        /// <returns>Tableau contenant tous les faits (Fait[])</returns>
        public static Fait[] ChargerFaits()
        {
            const string CHEMIN_FAITS = "C:\\data-420-04A-FX\\tp3-faits.csv";
            string[] lignesFaits = LireLignesFichier(CHEMIN_FAITS);

            Fait[] tabFaits = new Fait[lignesFaits.Length];

            for (int i = 0; i < lignesFaits.Length; i++)
            {
                string[] splitFaits = lignesFaits[i].Split(';');
                tabFaits[i].Annee = Convert.ToInt32(splitFaits[0]);
                tabFaits[i].Mois = Convert.ToInt32(splitFaits[1]);
                tabFaits[i].Nom = splitFaits[2];
                tabFaits[i].Description = splitFaits[3];
            }

            return tabFaits;
        }

        /// <summary>
        /// Permet de charger la liste des 10 joueurs ayant le plus haut score
        /// </summary>
        /// <returns>Tableau contenant le nom et le score de tous les joueurs</returns>
        public static Joueur[] ChargerJoueurs()
        {
            const string CHEMIN_JOUEURS = "C:\\data-420-04A-FX\\tp3-top-10.csv";
            string[] lignesJoueurs = LireLignesFichier(CHEMIN_JOUEURS);

            Joueur[] tabJoueurs = new Joueur[10];

            for (int i = 0; i < tabJoueurs.Length; i++)
            {
                string[] splitJoueurs = lignesJoueurs[i].Split(';');
                tabJoueurs[i].Nom = splitJoueurs[0];
                tabJoueurs[i].Score = Convert.ToInt32(splitJoueurs[1]);
            }

            return tabJoueurs;
        }

        /// <summary>
        /// Permet de créer un tableau de faits sélectionnés aléatoirement
        /// </summary>
        /// <param name="tabFaits">Tableau complet des faits</param>
        /// <param name="nbFaits">Nombre de faits </param>
        /// <returns></returns>
        public static Fait[] ChoisirFaitsAleatoires(Fait[] tabFaits, int nbFaits)
        {
            Random nbAleatoire = new Random();
            HashSet<int> nombresUniques = new HashSet<int>();
            Fait[] tabFaitsJeu = new Fait[nbFaits];

            int i = 0;
            while (nombresUniques.Count < tabFaitsJeu.Length)
            {
                int iAleatoire = nbAleatoire.Next(0, tabFaits.Length - 1);
                if (nombresUniques.Add(iAleatoire))
                {
                    tabFaitsJeu[i] = tabFaits[iAleatoire];
                    i++;
                }
            }

            return tabFaitsJeu;
        }

        /// <summary>
        /// Converti en texte un mois sous forme de nombre 
        /// </summary>
        /// <param name="noMois">Le numéro du mois</param>
        /// <returns>Le mois sous forme de texte. Ex: "Janvier"</returns>
        public static string ConvertirMois(int noMois)
        {

            string[] tabMois = new string[] { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin",
            "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décemebre" };

            return tabMois[noMois - 1];
        }


        // -----------------------------------------------------
        // Fonction EstChronologique à développer (voir TODO 08)
        // -----------------------------------------------------


        // --------------------------------------------------
        // Fonction ModifierTop10 à développer (voir TODO 12)
        // --------------------------------------------------

    }
}
