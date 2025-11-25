using System;
using System.Collections;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstEtudiant = new SortedList
            {
                {1, new Etudiant { NO = 1, Nom = "Fall", PréNom = "Racine", NoteCC = 12, NoteDevoir = 13 }},
                {2, new Etudiant { NO = 2, Nom = "Diop", PréNom = "Omar", NoteCC = 15, NoteDevoir = 14 }},
                {3, new Etudiant { NO = 3, Nom = "Ndoye", PréNom = "Amina", NoteCC = 17, NoteDevoir = 18 }},
                {4, new Etudiant { NO = 4, Nom = "Ndoye", PréNom = "Amina2", NoteCC = 17, NoteDevoir = 18 }},
                {5, new Etudiant { NO = 5, Nom = "Ndoye", PréNom = "Amina3", NoteCC = 17, NoteDevoir = 18 }},
                {6, new Etudiant { NO = 6, Nom = "Ndoye", PréNom = "Amina4", NoteCC = 17, NoteDevoir = 18 }},
                {7, new Etudiant { NO = 7, Nom = "Ndoye", PréNom = "Amina5", NoteCC = 17, NoteDevoir = 18 }},
                {8, new Etudiant { NO = 8, Nom = "Ndoye", PréNom = "Amina6", NoteCC = 17, NoteDevoir = 18 }}
            };

            int count = lstEtudiant.Count;

            int nbParPages = 5;
            Console.Write("Entrez le nombre de lignes par page (5 à 15) : ");
            if (int.TryParse(Console.ReadLine(), out int nbLignes) && nbLignes >= 5 && nbLignes <= 15)
            {
                nbParPages = nbLignes;
            }

            int totalPages = (int)Math.Ceiling((double)count / nbParPages);
            int pageActuelle = 1;
            bool quitter = false;

            while (!quitter)
            {
                Console.Clear();
                Console.WriteLine($"Page {pageActuelle} sur {totalPages}\n");

                int debut = (pageActuelle - 1) * nbParPages;
                int fin = Math.Min(debut + nbParPages, count);

                for (int i = debut; i < fin; i++)
                {
                    Etudiant etudiant = (Etudiant)lstEtudiant.GetByIndex(i);
                    double moyenne = etudiant.NoteCC * 0.33 + etudiant.NoteDevoir * 0.67;
                    Console.WriteLine($"No: {etudiant.NO}, Prénom: {etudiant.PréNom}, Nom: {etudiant.Nom}, " +
                                      $"NoteCC: {etudiant.NoteCC}, NoteDevoir: {etudiant.NoteDevoir}, Moyenne: {moyenne:F2}");
                }

                Console.WriteLine("\nN - Page Suivante | P - Page Précédente | Q - Quitter");
                Console.Write("Votre choix : ");
                string commande = Console.ReadLine().ToUpper();

                switch (commande)
                {
                    case "N":
                        if (pageActuelle < totalPages) pageActuelle++;
                        break;
                    case "P":
                        if (pageActuelle > 1) pageActuelle--;
                        break;
                    case "Q":
                        quitter = true;
                        break;
                }
            }

            // Moyenne de la classe
            double totalMoyennes = 0;
            foreach (Etudiant e in lstEtudiant.Values)
            {
                totalMoyennes += e.NoteCC * 0.33 + e.NoteDevoir * 0.67;
            }
            double moyenneClasse = totalMoyennes / count;
            Console.WriteLine($"\nMoyenne de la classe: {moyenneClasse:F2}");
        }
    }

}
