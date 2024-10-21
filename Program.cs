﻿namespace Probleme
{
    class Program
    {
        static void Main()
        {
            InitialisationEntreprise();
        }

        static void InitialisationEntreprise() 
        {
            Console.WriteLine();

            // creation de l'entreprise
            Entreprise entreprise = new Entreprise("TransConnect");

            // Création de salarié
            List<Salarie> salaries = new List<Salarie>
            {
                new Salarie("1", "Dupond", "John", new DateTime(1990, 5, 15),  new Address("Paris", "75001"), "john@example.com", "1234567890", "Directeur general", 10000, new DateTime(2020, 1, 1)),
                new Salarie("2", "Fiesta", "Alice", new DateTime(1985, 8, 25), new Address("Marseille", "13001"), "alice@example.com", "2345678901", "Directrice commerciale", 8000, new DateTime(2019, 6, 15)),
                new Salarie("3", "Fetard", "Michael", new DateTime(1982, 12, 10), new Address("Lyon", "69001"), "michael@example.com", "3456789012", "Directeur des opérations", 8500, new DateTime(2021, 3, 10)),
                new Salarie("4", "Joyeuse", "Emily", new DateTime(1993, 4, 5), new Address("Toulouse", "31000"), "emily@example.com", "4567890123", "Directrice des RH", 3200, new DateTime(2020, 8, 20), new DateTime(2024, 10, 5)),
                new Salarie("5", "Gripsous", "John", new DateTime(1990, 5, 15), new Address("Nice", "06000"), "john@example.com", "1234567890", "Directeur Financier", 3000, new DateTime(2020, 1, 1), new DateTime(2022, 12, 31)),
                new Salarie("6","Royal", "Theo", new DateTime(1982, 9, 15), new Address("Nantes", "44000"), "royal@example.com", "1592634870","Chef Equipe", 85000, new DateTime(2017, 4, 10)),
                new Salarie("7", "Prince", "Ghadi", new DateTime(1989, 8, 8), new Address("Strasbourg", "67000"), "prince@example.com", "9876541230","Chef d'Equipe", 95000, new DateTime(2018, 9, 1)),
                new Salarie("8", "Picsou", "Pascal", new DateTime(1965, 6, 18), new Address("Strasbourg", "67000"), "picsou@example.com", "1234567890","Direction comptable", 115000, new DateTime(2005, 9, 10)),

                new Salarie("9","Forge", "Mr", new DateTime(1985, 7, 20), new Address("Paris", "75001"), "forge@example.com", "2468135790",
                               "Commercial", 80000, new DateTime(2015, 6, 1)),
                new Salarie("10","Fermi", "Mme", new DateTime(1990, 12, 25), new Address("Bordeaux", "33000"), "fermi@example.com", "1357924680",
                                "Commerciale", 75000, new DateTime(2016, 9, 20)),


                new Salarie("16","ToutleMonde", "Mme", new DateTime(1990, 5, 25), new Address("Marseille", "13001"), "toutlemonde@example.com", "1234567890",
                                     "Contrats", 80000, new DateTime(2016, 8, 20)),
                new Salarie("17","Couleur", "Mme", new DateTime(1976, 12, 10), new Address("Grenoble", "38000"), "couleur@example.com", "9876543210",
                                 "Formation", 85000, new DateTime(2014, 5, 1)),

                new Salarie("18","Fournier", "Mme", new DateTime(1982, 10, 30),  new Address("Marseille", "13001"), "fournier@example.com", "9876543210",
                                  "Comptable", 90000, new DateTime(2012, 7, 15)),
                new Salarie("19","Gautier", "Mme", new DateTime(1988, 9, 5), new Address("Marseille", "13001"), "gautier@example.com", "1234567890",
                                 "Comptable", 88000, new DateTime(2013, 10, 1)),

                new Salarie("20","GrosSous", "Mr", new DateTime(1995, 10, 30), new Address("Paris", "75001"), "grosSous@example.com", "3685114860",
                              "Controleur de Gestion", 60000, new DateTime(2020, 1, 5)),

            };

            // Creer les chauffeurs
            Chauffeur c1 = new Chauffeur("11","Rimou", "Mme", new DateTime(1997, 7, 15), new Address("Lille", "59000"), "rimou@example.com", "9876543210",
                                "Chauffeur", 55000, new DateTime(2021, 6, 30));
            Chauffeur c2 = new Chauffeur("12", "Rome", "Mme", new DateTime(1993, 2, 28), new Address("Rennes", "35000"), "rome@example.com", "1234567890",
                              "Chauffeur", 56000, new DateTime(2021, 5, 20));
            Chauffeur c3 = new Chauffeur("13", "Roma", "Mr", new DateTime(1992, 4, 12), new Address("Reims", "51100"), "roma@example.com", "2143658790",
                              "Chauffeur", 57000, new DateTime(2021, 2, 10));
            Chauffeur c4 = new Chauffeur("14", "Romi", "Mme", new DateTime(1998, 10, 20), new Address("Le Havre", "76600"), "romi@example.com", "8642975310",
                               "Chauffeur", 58000, new DateTime(2020, 3, 15));
            Chauffeur c5 = new Chauffeur("15","Romu", "Mr", new DateTime(1995, 6, 30), new Address("Paris", "75001"), "romu@example.com", "7539514860",
                              "Chauffeur", 60000, new DateTime(2020, 1, 5));

            // Ajouter les chauffeurs dans la liste de salaires
            salaries.Add(c1);
            salaries.Add(c2);
            salaries.Add(c3);
            salaries.Add(c4);
            salaries.Add(c5);

            // Création de clients
            List<Client> clients = new List<Client>
            {
                new Client("Dala", "Jane", new DateTime(1995, 3, 20), new Address("Paris", "75001"), "jane@example.com", "9876543210"),
                new Client("Johnson", "David", new DateTime(1978, 6, 30), new Address("Paris", "75001"), "david@example.com", "8765432109"),
                new Client("Garcia", "Maria", new DateTime(1989, 10, 15), new Address("Lyon", "69001"), "maria@example.com", "7654321098"),
                new Client("Martinez", "Carlos", new DateTime(1980, 5, 3), new Address("Bordeaux", "33000"), "carlos@example.com", "6543210987")
            };

            // Création des produits
            List<Produit> produits1 = new List<Produit>
            {
                new Produit("Produit 1", 10,1),
                new Produit("Produit 2", 20,1),
                new Produit("Produit 3", 15,1)
            };
            List<Produit> produits2 = new List<Produit>
            {
                new Produit("Produit 3", 50,1),
                new Produit("Produit 4", 5,1),
                new Produit("Produit 5", 30,1)
            };

            // creation de vehicules
            Voiture v2 = new Voiture(2, 10000, 600, 4);
            Voiture v1 = new Voiture(1, 20000, 500, 5);
            Voiture maVoiture = new Voiture(3, 20000, 500, 5);
            Camionnette maCamionnette = new Camionnette(4, 30000, 400, "Transport de marchandises");

            // ajout des vehicules dans l'entreprise
            entreprise.Vehicules.Add(v1);
            entreprise.Vehicules.Add(v2);
            entreprise.Vehicules.Add(maVoiture);
            entreprise.Vehicules.Add(maCamionnette);



            // Création des commandes
            Commande commande1 = new Commande(
                produits1, 
                clients[0], 
                "Paris", 
                "Marseille", 
                v1,
                c1,
                DateTime.Now // Date de la commande
            );

            Commande commande2 = new Commande(
                produits2, 
                clients[3], 
                "Biarritz", 
                "Marseille", 
                v2,
                c2,
                DateTime.Now // Date de la commande
            );

            clients[0].AjouterCommande(commande1);
            clients[1].AjouterCommande(commande2);
            
            
            // ajout des salariés et clients dans l'entreprise
            salaries.ForEach(x => entreprise.Salaries.Add(x));
            clients.ForEach(x => entreprise.Clients.Add(x));

            // Création de l'organigramme
            entreprise.CreationArbre(salaries);

            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("1. Module Client");
                Console.WriteLine("2. Module Salarie");
                Console.WriteLine("3. Module Commande");
                Console.WriteLine("4. Module Statistiques");
                Console.WriteLine("5. Module Vehicule");
                Console.WriteLine("6. Menu Dijkstra");
                Console.WriteLine("tapez 'q' pour quitter");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        entreprise.ModuleClient();
                        break;
                    case "2":
                        entreprise.ModuleSalarie();
                        break;
                    case "3":
                        entreprise.ModuleCommande();
                        break;
                    case "4":
                        Statistiques stats = new Statistiques(entreprise);
                        stats.ModuleStatistiques();
                        break;
                    case "5":
                        entreprise.ModuleVehicule();
                        break;
                    case "6":
                        MenuDijkstra();
                        break;
                    case "q":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }
            }
           
            Console.WriteLine();
        }

        // -------------------------------------- DEBUT DIJKSTRA MENU -------------------------------------------
        static void MenuDijkstra()
        {
            CSVReader csvReader = new CSVReader("Distances.csv");

            if (csvReader.Arcs != null)
            {
                List<Arc> arcs = csvReader.Arcs;
                Graphe graphe = new Graphe(arcs);

                // Menu utilisateur
                while (true)
                {
                    Console.WriteLine("-------------------- Menu Djikstra -------------------------");
                    Console.WriteLine("1. Trouver le chemin le plus court");
                    Console.WriteLine("Tapez 'q' pour quitter");

                    string choix = Console.ReadLine();
                    switch (choix)
                    {
                        case "q":
                            Environment.Exit(0);
                            break;
                        case "1":
                            TrouverCheminLePlusCourtDjikstra(graphe);
                            break;
                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Erreur lors de la lecture du fichier CSV.");
            }
        }
        static void TrouverCheminLePlusCourtDjikstra(Graphe graphe) {
            #pragma warning disable CS8600, CS8604
            Console.Write("Ville de départ: ");
            string villeDeDepart = "";
            while(villeDeDepart == "") {
                villeDeDepart = Console.ReadLine();
            }

            Console.Write("Ville d'arrivée: ");
            string villeDarrivee = "";
            while(villeDarrivee == "") {
                villeDarrivee = Console.ReadLine();
            }

            Console.Write("Type de l'algorithme Djikstra (distance/temps): ");
            string type = Console.ReadLine();

            graphe.AlgorithmeDijkstra(villeDeDepart, type);

            // Afficher le chemin le plus court entre 2 villes
            List<string> cheminPlusCourt = graphe.CheminPlusCourt(villeDeDepart, villeDarrivee);

            if (cheminPlusCourt != null)
            {
                int indexVilleArrivee = graphe.Sommets.IndexOf(villeDarrivee);

                // Afficher le chemin le plus court
                Console.WriteLine($"\nChemin le plus court de {villeDeDepart} à {villeDarrivee} :");
                Console.WriteLine(string.Join(" -> ", cheminPlusCourt));

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
            
        }
        // -------------------------------------- FIN DIJKSTRA MENU -------------------------------------------
    }
}