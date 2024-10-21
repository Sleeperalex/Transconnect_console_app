using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Probleme
{
    public class Statistiques
    {
        private Entreprise entreprise;

        public Statistiques(Entreprise entreprise)
        {
            this.entreprise = entreprise;
        }

        // 1. Afficher par chauffeur le nombre de livraisons effectuées 
        public void AfficherLivraisonsParChauffeur()
        {
            // Extraction des chauffeurs qui ont des commandes assignées 
            var chauffeursAvecCommandes = entreprise.Clients
                                                    .SelectMany(client => client.Commandes)
                                                    .Select(commande => commande.Chauffeur)
                                                    .Distinct();

            foreach (var chauffeur in chauffeursAvecCommandes)
            {
                // Calcul du nombre de livraisons pour chaque chauffeur
                int nombreLivraisons = entreprise.Clients
                                                .SelectMany(client => client.Commandes)
                                                .Count(c => c.Chauffeur == chauffeur);
                Console.WriteLine($"Chauffeur: {chauffeur.Nom} - Nombre de livraisons: {nombreLivraisons}");
            }
        }


        // 2. Récupère toutes les commandes effectuées dans une période donnée.
        public void CommandesParPeriode(DateTime debut, DateTime fin)
        {
            var commandes = entreprise.Clients
                                    .SelectMany(client => client.Commandes)
                                    .Where(commande => commande.DateCommande >= debut && commande.DateCommande <= fin)
                                    .ToList();

            Console.WriteLine("Liste des commandes par période spécifiée:");
            foreach (var commande in commandes)
            {
                Console.WriteLine($"Commande ID: {commande.IdCommande}, Date: {commande.DateCommande}, Prix: {commande.PrixCommande:C}");
            }
        }


        // 3. Afficher la moyenne des prix des commandes
        public void AfficherMoyennePrixCommandes()
        {
            var commandes = entreprise.Clients.SelectMany(client => client.Commandes);
            double moyenne = commandes.Any() ? commandes.Average(c => c.PrixCommande) : 0;
            Console.WriteLine($"Moyenne des prix des commandes: {moyenne:C}");
        }

        // 4. Afficher la moyenne des comptes clients
        public void AfficherMoyenneComptesClients()
        {
            foreach (var client in entreprise.Clients)
            {
                double moyenne = client.Commandes.Any() ? client.Commandes.Average(c => c.PrixCommande) : 0;
                Console.WriteLine($"Client: {client.Nom} (ID: {client.Id}) - Moyenne des commandes: {moyenne:C}");
            }
        }


        /// 5. Afficher la liste des commandes pour un client
        public void CommandesParClient(Client client)
        {
            Console.WriteLine($"Affichage des commandes pour le client: {client.Nom} (ID: {client.Id})");
            foreach (var commande in client.Commandes)
            {
                Console.WriteLine($"Commande ID: {commande.IdCommande}, Date: {commande.DateCommande}, Prix: {commande.PrixCommande:C}");
            }
        }

        // MENU STATISTIQUES
        public void ModuleStatistiques()
        {
            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("----------------------------------- Menu Statistiques -----------------------------------");
                Console.WriteLine("1. Afficher le nombre de livraisons par chauffeur");
                Console.WriteLine("2. Afficher les commandes par période");
                Console.WriteLine("3. Afficher la moyenne des prix des commandes");
                Console.WriteLine("4. Afficher la moyenne des comptes clients");
                Console.WriteLine("5. Afficher les commandes pour un client spécifique");
                Console.WriteLine("q. quitter");

                Console.Write("Entrez votre choix: ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AfficherLivraisonsParChauffeur();
                        break;
                    case "2":
                        Console.Write("Entrez la date de début (yyyy-mm-dd): ");
                        DateTime debut = DateTime.Parse(Console.ReadLine());
                        Console.Write("Entrez la date de fin (yyyy-mm-dd): ");
                        DateTime fin = DateTime.Parse(Console.ReadLine());
                        CommandesParPeriode(debut, fin);
                        break;
                    case "3":
                        AfficherMoyennePrixCommandes();
                        break;
                    case "4":
                        AfficherMoyenneComptesClients();
                        break;
                    case "5":
                        Console.Write("Entrez l'ID du client: ");
                        string idClient = Console.ReadLine();

                        // Boucle pour s'assurer que l'entrée n'est pas vide, nulle ou constituée uniquement d'espaces
                        while (string.IsNullOrWhiteSpace(idClient))
                        {
                            Console.WriteLine("L'ID du client ne peut pas être vide. Veuillez entrer un ID valide.");
                            idClient = Console.ReadLine();
                        }

                        Client client = RechercherClient(idClient);
                        if (client != null)
                        {
                            CommandesParClient(client);
                        }
                        else
                        {
                            Console.WriteLine("Client non trouvé.");
                        }
                        break;
                    case "q":
                        continuer = false;
                        Console.WriteLine("Fermeture du menu...");
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
        }

        // -------------------------- Méthodes secondaires ------------------------------------
        // Méthode permettant de trouver un client à partir de son NSS.
        public Client? RechercherClient(string idRechercher) {

            int id;
            if (int.TryParse(idRechercher, out id))
            {
                
                Client clientTrouver = entreprise.Clients.Find(client => client.Id == id);

                // Vérifier si le client a été trouvé
                if (clientTrouver != null)
                {
                    return clientTrouver;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    
        
    }
}