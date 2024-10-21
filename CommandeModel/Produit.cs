using System.Reflection.Metadata.Ecma335;

namespace Probleme
{
    public class Produit
    {
        private int idProduit;
        private string nom;
        private double prixUnitaire;
        private int quantite;


        private static int idDernierProduit = 1;

        public Produit(string nom, double prixUnitaire, int quantite)
        {
            this.idProduit = idDernierProduit;
            this.nom = nom;
            this.prixUnitaire = prixUnitaire;
            this.quantite = quantite;
            idDernierProduit++;
        }

        public int IdProduit
        {
            get { return idProduit; }
        }

        public string Nom
        {
            get { return nom; }
        }

        public double PrixUnitaire
        {
            get { return prixUnitaire; }
        }

        public int Quantite
        {
            get { return quantite; }
        }

        public override string ToString()
        {
            return $" ID: {idProduit}, Nom: {nom}, Prix unitaire: {prixUnitaire}, quantite: {quantite}";
        }

        /// <summary>
        /// Calculer le prix total
        /// </summary>
        /// <returns></returns>
        public double PrixTotal()
        {
            return quantite * prixUnitaire;
        }


        /// <summary>
        /// Modifier le produit
        /// </summary>
        public void ModifierProduit()
        {
            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("Modifier le produit");
                Console.WriteLine("1. Nom: ");
                Console.WriteLine("2. Prix unitaire: ");
                Console.WriteLine("3. Quantite: ");
                Console.WriteLine("tapez 'q' pour quitter");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("Nouveau nom: ");
                        nom = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Nouveau prix unitaire: ");
                        if (int.TryParse(Console.ReadLine(), out int x)) prixUnitaire = x;
                        else Console.WriteLine("Veuillez entrer un entier");
                        break;
                    case "3":
                        Console.WriteLine("Nouvelle quantite: ");
                        if (int.TryParse(Console.ReadLine(), out int y)) quantite = y;
                        else Console.WriteLine("Veuillez entrer un entier");
                        break;
                    case "q":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide");
                        break;
                }
            }
        }
    }
}