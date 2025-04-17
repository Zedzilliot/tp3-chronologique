using System;

namespace tp3_chronologique
{
    class Program
    {
        const int QTE_FAITS = 3;

        static void Main(string[] args)
        {

            #region Écran d'accueil et chargement des données

            Fait[] tabFaits = FctUtiles.ChargerFaits();

            Joueur[] tabJoueurs = FctUtiles.ChargerJoueurs();
             
            AfficherEntete();

            AfficherJoueurs(tabJoueurs);

            Console.WriteLine("\nInscrivez votre nom de joueur pour débuter une partie");
            Console.Write("\nJoueur : ");
            string nomJoueur = Console.ReadLine();

            #endregion

            #region Déroulement du jeu

            bool quitter = false;
            do
            {

                #region Déroulement des manches d'une partie

                Console.Clear();
                AfficherTitre("Manche ");

                Fait[] tabFaitsRandom = FctUtiles.ChoisirFaitsAleatoires(tabFaits, QTE_FAITS);

                // TODO 06 : Compléter la fonction JouerManche
                bool mancheReussie = JouerManche(tabFaitsRandom);

                // TODO 10 : Créer la dynamique de boucle des manches

                #endregion

                #region Fin de la partie 

                // TODO 11 : Affichage du résultat de la partie

                // TODO 12 : Mise à jour et affichage du Top 10 

                #endregion

                Console.WriteLine("Appuyez sur une touche pour continuer");
                Console.ReadKey();
                Console.Clear();

                char choix = ChoisirOptionMenu();
                
                // TODO 14 : Compléter l'option pour quitter

            } while (!quitter);

            #endregion
        }

        /// <summary>
        /// Jouer une manche du jeu
        /// </summary>
        /// <param name="tabFaits">Tableau de faits pour la manche</param>
        /// <returns>Vrai si la manche est réussie, faux sinon</returns>
        static bool JouerManche(Fait[] tabFaits)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            AfficherFaits(tabFaits);
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("\nEntrez le numéro des faits dans l'ordre chronologique : \n");

            bool mancheReussie = true;
            Fait[] tabFaitsResponse = new Fait[QTE_FAITS];

            for (int i = 0; i < QTE_FAITS; i++)
            {
                Console.Write(" -> ");
                int nbrEntre = Convert.ToInt32(Console.ReadLine());
                tabFaitsResponse[i] = tabFaits[nbrEntre - 1];     
            }

            // TODO 08  : Vérification si l'ordre est chronologique

            // TODO 09 : Affichage du résultat de la manche et retour

            // À modifier pour une valeur en fonction du résultat de la manche
            // - true : si la manche est réussie (les faits ont été classé dans l’ordre chronologique)
            // - false : si la manche n’est pas réussie.
            return mancheReussie;
        }

        #region Fonctions d'affichage 
        
        /// <summary>
        /// Affichage du logo d'entête
        /// </summary>
        static void AfficherEntete()
        {
            string logo = "";

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;

            logo += "=============================\n";
            logo += "=================================\n";
            logo += "---C-h-r-o-n-o-L-o-g-i-q-u-e -----> \n";
            logo += "=================================\n";
            logo += "=============================\n";

            Console.WriteLine(logo);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("Travail réalisé par : ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            
            Console.WriteLine("Elliot Tremblay\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;

        }

        /// <summary>
        /// Affichage graphique d'un titre 
        /// </summary>
        /// <param name="titre">Le titre à afficher</param>
        static void AfficherTitre(string titre)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            string texteTitre = "|";
            for (int i = 0; i < titre.Length + 12; i++)
                texteTitre += "=";

            texteTitre += "|\n|-->   " + titre + "   <--|\n|";

            for (int i = 0; i < titre.Length + 12; i++)
                texteTitre += "=";

            texteTitre += "|\n";

            Console.WriteLine(texteTitre);
            Console.BackgroundColor = ConsoleColor.Black; ;
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        /// <summary>
        /// Permet d'afficher le menu d'option et de faire un choix
        /// </summary>
        /// <returns>Le caractère correspondant au choix</returns>
        static char ChoisirOptionMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nQue souhaitez-vous faire?\n" +
                "a - Rejouer une partie\n" +
                "b - Quitter\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Votre choix : ");
            char choix = Convert.ToChar(Console.ReadLine());

            //TODO 13 : Ajouter une validation du choix  

            Console.ForegroundColor = ConsoleColor.White;
            return choix;
        }


        /// <summary>
        /// Afficher un tableau de faits sous forme de liste
        /// </summary>
        /// <param name="tabFaits">Tableau de faits</param>
        /// <param name="avecDates">
        ///     true = afficher les dates.
        ///     false = cacher les dates (valeur par défaut)
        /// </param>
        static void AfficherFaits(Fait[] tabFaits, bool avecDates = false)
        {
            for (int i = 0; i < tabFaits.Length; i++)
            {
                string fait = "-----------------------\n";

                fait += String.Format("| {0} |  {1}", i + 1, tabFaits[i].Nom);

                if (avecDates)
                {
                    fait += String.Format(" ({0}...)", tabFaits[i].Description.Substring(0, 8));
                    fait += String.Format(" - {0}-{1}", tabFaits[i].Annee, FctUtiles.ConvertirMois(tabFaits[i].Mois));
                }
                else
                    fait += String.Format(" ({0})", tabFaits[i].Description);

                Console.WriteLine(fait); 
            }
        }

        static void AfficherJoueurs(Joueur[] tabJoueurs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TOP 10 DES MEILLEURS JOUEURS");
            Console.WriteLine("============================");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0, -15} | {1} pts",tabJoueurs[i].Nom, tabJoueurs[i].Score);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        #endregion
    }
}
