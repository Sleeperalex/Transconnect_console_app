namespace Probleme
{

    public class Commande
    {
        private int idCommande;
        private List<Produit> produits;
        private Client clientCommmande;
        private string pointA;
        private string pointB;
        private double prixCommande;
        private Vehicule vehiculeCommande;
        private Chauffeur chauffeurCommande;
        private DateTime dateCommande;

        private static int idDerniereCommande = 1;

        public Commande(List<Produit> produits, Client clientCommmande, string pointA, string pointB, Vehicule vehiculeCommande, Chauffeur chauffeurCommande, DateTime dateCommande)
        {
            this.idCommande = idDerniereCommande;
            this.produits = produits;
            this.clientCommmande = clientCommmande;
            this.pointA = pointA;
            this.pointB = pointB;

            double prixCommande = 0;
            foreach (Produit p in produits)
            {
                prixCommande += p.PrixTotal();
            }
            this.prixCommande = prixCommande;
            this.vehiculeCommande = vehiculeCommande;
            this.chauffeurCommande = chauffeurCommande;
            this.dateCommande = dateCommande;
            idDerniereCommande++;
        }

        public int IdCommande
        {
            get { return idCommande; }
        }

        public List<Produit> Produits
        {
            get { return produits; }
            set { produits = value; }
        }

        public string PointA
        {
            get { return pointA; }
            set { pointA = value; }
        }

        public string PointB
        {
            get { return pointB; }
            set { pointB = value; }
        }

        public Vehicule Vehicule
        {
            get { return vehiculeCommande; }
            set { vehiculeCommande = value; }
        }

        public Chauffeur Chauffeur
        {
            get { return chauffeurCommande; }
            set { chauffeurCommande = value; }
        }

        public DateTime DateCommande
        {
            get { return dateCommande; }
            set { dateCommande = value; }
        }

        public Client Clientcommande
        {
            get { return clientCommmande; }
            set { clientCommmande = value; }
        }

        public double PrixCommande
        {
            get { return prixCommande; }
        }



        public override string ToString()
        {
            string s = "";
            foreach (Produit p in produits)
            {
                s += p.ToString() + " ";
            }
            string client = $"id client: {clientCommmande.Id}, nom: {clientCommmande.Nom}";
            return $"Id: {idCommande}, Produits: {s}, Client: {client}, Point A: {pointA}, Point B: {pointB}, Prix: {prixCommande}, Vehicule: {vehiculeCommande}, Chauffeur : {chauffeurCommande}, Date: {dateCommande}";
        }

        /// <summary>
        /// Methode pour creer un produit
        /// </summary>
        /// <returns></returns>
        public static Produit? CreerProduit()
        {
            Console.WriteLine("Quel produit voulez-vous ajouter ?");
            string nom = Console.ReadLine();
            Console.WriteLine("Quel est son prix ?");
            string p = Console.ReadLine();
            Console.WriteLine("Quelle est sa quantite ?");
            string q = Console.ReadLine();

            if (double.TryParse(p, out double prix) && int.TryParse(q, out int quantite) && nom != null)
            {
                return new Produit(nom, prix, quantite);
            }

            return null;
        }

        /// <summary>
        /// Methode pour rechercher un produit
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Produit? RechercherProduit(string s)
        {
            int id;
            if (int.TryParse(s, out id))
            {
                foreach (Produit p in produits)
                {
                    if (p.IdProduit == id)
                    {
                        return p;
                    }
                }
                return null;
            }
            return null;
        }


        /// <summary>
        /// Methode pour afficher le chemin le plus court de la commande
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> Chemin(string type)
        {
            CSVReader csvReader = new CSVReader("Distances.csv");
            List<Arc> arcs = csvReader.Arcs;
            Graphe graphe = new Graphe(arcs);
            graphe.AlgorithmeDijkstra(this.pointA,type);
            // Recupere la liste des villes du chemin le plus court entre villeDeDepart et villeDarrivee
            List<string> chemin = graphe.CheminPlusCourt(this.pointA, this.pointB);
            // Recupere la distance (en km) ou le temps (en min)
            if (chemin != null)
            {
                int indexVilleArrivee = graphe.Sommets.IndexOf(this.pointB);

                // Afficher le chemin le plus court
                Console.WriteLine($"\nChemin le plus court de {this.pointA} à {this.pointB} :");
                Console.WriteLine(string.Join(" -> ", chemin));

                // Cas où on fait Djikstra sur les distances (en km)
                if (type == "distance")
                {
                    Console.WriteLine("Parcouru en " + graphe.DistanceMinimal[indexVilleArrivee] + " km");
                }
                // Cas où on fait Djikstra sur le temps (en h)
                else
                {
                    int heures = graphe.DistanceMinimal[indexVilleArrivee] / 60;
                    int minutesRestantes = graphe.DistanceMinimal[indexVilleArrivee] % 60;
                    Console.WriteLine("Parcouru en " + heures + "h" + minutesRestantes);
                }
            }
            else
            {
                Console.WriteLine("Pas de chemin possible entre ces 2 villes");
            }
            return chemin;
        }




    }
}