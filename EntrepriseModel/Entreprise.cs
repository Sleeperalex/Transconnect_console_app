using System.ComponentModel;

namespace Probleme
{

    public class Entreprise : IAfficheSalaries
    {

        string nom;
        Arbre organigramme;
        List<Salarie> salaries;
        List<Client> clients;
        List<Vehicule> vehicules;


        public Entreprise(string nom)
        {
            this.nom = nom;
            this.salaries = new List<Salarie>();
            this.clients = new List<Client>();
            this.vehicules = new List<Vehicule>();
        }

        public Arbre Organigramme
        { get { return organigramme; } }

        public List<Salarie> Salaries
        {
            get { return salaries; }
            set { salaries = value; }
        }
        public List<Client> Clients
        {
            get { return clients; }
            set { clients = value; }
        }
        public List<Vehicule> Vehicules
        {
            get { return vehicules; }
            set { vehicules = value; }
        }

#pragma warning disable CS8600
        // -------------------------------------- MODULE CLIENT -------------------------------------------------

        /// <summary>
        /// Afficher les clients
        /// </summary>
        public void AfficherClients()
        {
            Console.WriteLine("Liste des clients : ");
            clients.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Méthode pour ajouter un client à partir de ses informations
        /// </summary>
        public void AjouterClient()
        {
            Console.WriteLine("Nom du client : ");
            string nom = Console.ReadLine();

            Console.WriteLine("Prénom du client : ");
            string prenom = Console.ReadLine();

            Console.WriteLine("Date de naissance du client (JJ/MM/AAAA) : ");
            DateTime naissance;
            while (!DateTime.TryParse(Console.ReadLine(), out naissance))
            {
                Console.WriteLine("Format de date invalide. Entrez à nouveau la date de naissance (format JJ/MM/AAAA) : ");
            }

            Console.WriteLine("Addresse du client ----------  ");
            Console.WriteLine("Ville du client : ");
            string ville = Console.ReadLine();
            Console.WriteLine("Code postale du client : ");
            string code_postale = Console.ReadLine();

            Console.WriteLine("Adresse email du client : ");
            string mail = Console.ReadLine();

            Console.WriteLine("Numéro de téléphone du client : ");
            string portable = Console.ReadLine();

            if (nom != null && prenom != null && ville != null && code_postale != null && mail != null && portable != null)
            {
                // Créer un nouveau client avec les informations entrées
                Address address = new Address(ville, code_postale);
                Client nouveauClient = new Client(nom, prenom, naissance, address, mail, portable);

                // Ajouter le nouveau client à la liste existante de clients
                clients.Add(nouveauClient);

                Console.WriteLine("Le client a été ajouté avec succès !");
            }
            else
            {
                Console.WriteLine("Erreur : le client n'a pas pu être ajouté.");
            }

        }

        /// <summary>
        /// Méthode permettant de trouver un client à partir de son NSS.
        /// </summary>
        /// <param name="idRechercher"></param>
        /// <returns> Le client correspondant au NSS saisi</returns>
        public Client? RechercherClient(string idRechercher)
        {

            int id;
            if (int.TryParse(idRechercher, out id))
            {
                Client clientTrouver = clients.Find(client => client.Id == id);

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

        /// <summary>
        /// Méthode permettant de supprimer un client à partir de son NSS.
        /// </summary>
        /// <param name="id_client_a_supprimer"></param>
        public void SupprimerClient(string id_client_a_supprimer)
        {
            Client clientASupprimer = RechercherClient(id_client_a_supprimer);
            if (clientASupprimer != null)
            {
                clients.Remove(clientASupprimer);
            }
            else
            {
                Console.WriteLine("Erreur : Impossible de supprimer le client avec cet ID. Veuillez fournir un ID valide.");
            }
        }

        /// <summary>
        /// Méthode permettant de modifier un client à partir de son NSS
        /// </summary>
        /// <param name="id_client_a_supprimer"></param>
        public void ModifierClientDeLentreprise(string id_client_a_supprimer)
        {

            Client clientAModifier = RechercherClient(id_client_a_supprimer);
            if (clientAModifier != null)
            {
                clientAModifier.ModifierClient();
            }
            else
            {
                Console.WriteLine("Erreur : Impossible de modifier le client avec cet ID. Veuillez fournir un ID valide.");
            }


        }

        /// <summary>
        /// Méthode de gestion des clients
        /// </summary>
        public void ModuleClient()
        {
            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("----------------------------------- Menu Client -----------------------------------");
                Console.WriteLine("1. Ajouter un client");
                Console.WriteLine("2. Supprimer un client");
                Console.WriteLine("3. Modifier un client");
                Console.WriteLine("4. Trier les cliens par ordre alphabétique (nom)");
                Console.WriteLine("5. Trier les cliens par ville");
                Console.WriteLine("6. Trier les cliens par montant des achats cumulé");
                Console.WriteLine("7. Trier les cliens par nom, ville et montant des achats cumulés");
                Console.WriteLine("8. Afficher les clients");
                Console.WriteLine("tapez 'q' pour quitter");

                Console.Write("Choix: ");
                string choix = Console.ReadLine();

                Console.WriteLine();

                switch (choix)
                {
                    case "1":
                        AjouterClient();
                        break;
                    case "2":
                        Console.WriteLine("Entrez l'ID du client à supprimer : ");
                        string idASupprimer = Console.ReadLine();
                        SupprimerClient(idASupprimer);
                        break;
                    case "3":
                        Console.WriteLine("Entrez l'ID du client à modifier : ");
                        string idAModifier = Console.ReadLine();
                        ModifierClientDeLentreprise(idAModifier);

                        break;
                    case "4":
                        Console.WriteLine("Voici les cliens triés par ordre alphabétique sur leur nom -----------------------------------");
                        clients.Sort((client1, client2) => client1.Nom.CompareTo(client2.Nom));
                        clients.ForEach(x => Console.WriteLine(x));
                        break;
                    case "5":
                        Console.WriteLine("Voici les cliens triés par ville -----------------------------------");
                        clients.Sort((client1, client2) => client1.Address.Ville.CompareTo(client2.Address.Ville));
                        clients.ForEach(x => Console.WriteLine(x));
                        break;
                    case "6":
                        Console.WriteLine("Voici les cliens triés par montant des achats cumulés (décroissant) -----------------------------------");
                        clients.Sort((client1, client2) => client2.PrixAchatCumuler().CompareTo(client1.PrixAchatCumuler()));
                        clients.ForEach(x => Console.WriteLine(x));
                        Console.WriteLine("Le client qui a rapporté le + de profit est " + clients[0].Prenom + " " + clients[0].Nom.ToUpper());
                        break;
                    case "7":
                        Console.WriteLine("Voici les cliens triés par nom, ville et montant des achats cumulés (décroissant) -----------------------------------");
                        clients.Sort((client1, client2) => client1.Nom.CompareTo(client2.Nom));
                        clients.Sort((client1, client2) => client1.Address.Ville.CompareTo(client2.Address.Ville));
                        clients.Sort((client1, client2) => client2.PrixAchatCumuler().CompareTo(client1.PrixAchatCumuler()));
                        clients.ForEach(x => Console.WriteLine(x));
                        break;
                    case "8":
                        AfficherClients();
                        break;
                    case "q":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                        break;
                }
            }
        }


        // -------------------------------------- MODULE SALARIE -------------------------------------------------

        /// <summary>
        /// Méthode pour la creation de l'organigramme
        /// </summary>
        /// <param name="salaries"></param>
        public void CreationArbre(List<Salarie> salaries)
        {
            this.organigramme = new Arbre(salaries);
        }

        /// <summary>
        /// Afficher les salariés
        /// </summary>
        public void AfficheSalaries()
        {
            Console.WriteLine("Liste des salariés : ");
            salaries.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Méthode permettant de Supprimer un salarie
        /// </summary>
        /// <param name="nss"></param>
        public void SupprimerSalarie(string nss)
        {
            Salarie salarieASupprimer = RechercherSalarie(nss);
            if (salarieASupprimer != null)
            {
                salaries.Remove(salarieASupprimer);
                organigramme.SupprimerSalarie(salarieASupprimer);
            }
            else
            {
                Console.WriteLine("Erreur : Impossible de supprimer le salarie avec ce nss. Veuillez fournir un nss valide.");
            }
        }

        /// <summary>
        /// Remplacer un salarie par un salarie existant
        /// </summary>
        /// <param name="nss1"></param>
        /// <param name="nss2"></param>
        public void RemplacerSalarie(string nss1, string nss2)
        {
            Salarie s1 = RechercherSalarie(nss1);
            Salarie s2 = RechercherSalarie(nss2);
            if (s1 != null && s2 != null)
            {
                // Remplacer dans l'organigramme
                organigramme.Remplacer(s1, s2);

                // Remplacer le poste
                string poste = s1.Poste;
                s1.Poste = s2.Poste;
                s2.Poste = poste;

                // Remplacer le salaire
                int salaire = s1.Salaire;
                s1.Salaire = s2.Salaire;
                s2.Salaire = salaire;
            }
        }

        /// <summary>
        /// Remplacer un salarie par un salarie entrant
        /// </summary>
        /// <param name="nss"></param>
        public void RemplacerSalarie(string nss)
        {
            Salarie s1 = RechercherSalarie(nss);
            if (s1 != null)
            {
                Salarie s = CreerSalarie(s1);
                organigramme.Remplacer(s1, s);
                salaries.Remove(s1);
                salaries.Add(s);
            }
        }

        /// <summary>
        /// Méthode permettant de trouver un salarie à partir de son NSS.
        /// </summary>
        /// <param name="idRechercher"></param>
        /// <returns></returns>
        public Salarie? RechercherSalarie(string idRechercher)
        {

            Salarie salarieTrouver = salaries.Find(s => s.NSS == idRechercher);

            // Vérifier si le salarie a été trouvé
            if (salarieTrouver != null)
            {
                return salarieTrouver;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creer un salarie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Salarie CreerSalarie(Salarie s)
        {
            Console.WriteLine("Numero de securité sociale du salarie : ");
            string nss = Console.ReadLine();

            Console.WriteLine("Nom du salarie : ");
            string nom = Console.ReadLine();

            Console.WriteLine("Prénom du salarie : ");
            string prenom = Console.ReadLine();

            Console.WriteLine("Date de naissance du salarie (JJ/MM/AAAA) : ");
            DateTime naissance;
            while (!DateTime.TryParse(Console.ReadLine(), out naissance))
            {
                Console.WriteLine("Format de date invalide. Entrez à nouveau la date de naissance (format JJ/MM/AAAA) : ");
            }

            Console.WriteLine("Addresse du salarie ----------  ");
            Console.WriteLine("Ville du salarie : ");
            string ville = Console.ReadLine();
            Console.WriteLine("Code postale du salarie : ");
            string code_postale = Console.ReadLine();

            Console.WriteLine("Adresse email du salarie : ");
            string mail = Console.ReadLine();

            Console.WriteLine("Numéro de téléphone du salarie : ");
            string portable = Console.ReadLine();

            // attribut pour le salarie
            string poste;
            int salaire;
            DateTime entree = DateTime.Now;
            DateTime sortie = DateTime.MaxValue;
            if (s == null)
            {
                Console.WriteLine("Poste du salarie : ");
                poste = Console.ReadLine();
                Console.WriteLine("Salaire du salarie : ");
                salaire = int.Parse(Console.ReadLine());
                Console.WriteLine("Date de fin d'embauche du salarie (JJ/MM/AAAA) tapez 0 si le salarie est en CDI : ");
                string test = Console.ReadLine();
                if (test != "0")
                {
                    while (!DateTime.TryParse(Console.ReadLine(), out sortie) && sortie > entree)
                    {
                        Console.WriteLine("Format de date invalide. Entrez à nouveau la date de fin d'embauche (format JJ/MM/AAAA) : ");
                    }
                }

            }
            else
            {
                poste = s.Poste;
                salaire = s.Salaire;
                entree = s.Entree;
                sortie = s.Sortie;
            }

            if (nss != null && nom != null && prenom != null && ville != null && code_postale != null && mail != null && portable != null && poste != null && salaire > 0)
            {
                // Créer un nouveau salarie avec les informations entrées
                Address address = new Address(ville, code_postale);
                Salarie nouveauSalarie = new Salarie(nss, nom, prenom, naissance, address, mail, portable, poste, salaire, entree, sortie);
                return nouveauSalarie;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Ajouter un salarie
        /// </summary>
        /// <param name="nssPatron"></param>
        public void AjouterSalarie(string nssPatron)
        {
            Salarie s = CreerSalarie(null);
            if (s != null)
            {
                Salarie patron = RechercherSalarie(nssPatron);
                if (patron != null)
                {
                    organigramme.Associer(s, patron);
                    salaries.Add(s);
                }
                else
                {
                    Console.WriteLine("Erreur : Impossible d'ajouter le salarie avec ce NSS. Veuillez fournir un NSS valide.");
                }
            }
            else
            {
                Console.WriteLine("Erreur : Impossible d'ajouter le salarie. Veuillez fournir toutes les informations.");
            }
        }

        /// <summary>
        /// Modifier un salarie avec son NSS
        /// </summary>
        /// <param name="nss"></param>
        public void ModifierSalarieDeLentreprise(string nss)
        {
            Salarie salarieAModifier = RechercherSalarie(nss);
            if (salarieAModifier != null)
            {
                salarieAModifier.ModifierSalarie(organigramme);
            }
            else
            {
                Console.WriteLine("Erreur : Impossible de modifier le salarie avec ce NSS. Veuillez fournir un NSS valide.");
            }
        }

        /// <summary>
        /// Methodes de gestion des salariés
        /// </summary>
        public void ModuleSalarie()
        {
            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("----------------------------------- Menu Salarie -----------------------------------");
                Console.WriteLine("1. Ajouter un salarie en specifiant le NSS de son patron");
                Console.WriteLine("2. Supprimer un salarie");
                Console.WriteLine("3. Modifier les informations d'un salarie");
                Console.WriteLine("4. Remplacer un salarie par un salarie entrant");
                Console.WriteLine("5. Remplacer un salarie par un salarie existant");
                Console.WriteLine("6. Afficher l'organigramme de l'entreprise");
                Console.WriteLine("7. Afficher les salariés");
                Console.WriteLine("tapez 'q' pour quitter");
                Console.Write("Choix: ");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("Entrez le NSS du patron du salarie: ");
                        string nssPatron = Console.ReadLine();
                        AjouterSalarie(nssPatron);
                        break;
                    case "2":
                        Console.WriteLine("Entrez le NSS du salarie à supprimer : ");
                        string NSSASupprimer = Console.ReadLine();
                        SupprimerSalarie(NSSASupprimer);
                        break;
                    case "3":
                        Console.WriteLine("Entrez le NSS du salarie à modifier : ");
                        string NSSAModifier = Console.ReadLine();
                        ModifierSalarieDeLentreprise(NSSAModifier);
                        break;
                    case "4":
                        Console.WriteLine("Entrez le NSS du salarie sortant : ");
                        string NSSSortant = Console.ReadLine();
                        RemplacerSalarie(NSSSortant);
                        break;
                    case "5":
                        Console.WriteLine("Entrez le NSS du 1er salarie : ");
                        string NSSSalarie1 = Console.ReadLine();
                        Console.WriteLine("Entrez le NSS du 2eme salarie : ");
                        string NSSSalarie2 = Console.ReadLine();
                        RemplacerSalarie(NSSSalarie1, NSSSalarie2);
                        break;
                    case "6":
                        organigramme.AfficheSalaries();
                        break;
                    case "7":
                        AfficheSalaries();
                        break;
                    case "q":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                        break;
                }
            }
        }


        // ------------------------------------------- MODULE COMMANDES --------------------------------------------

        /// <summary>
        /// Afficher les commandes
        /// </summary>
        public void AfficheCommandes()
        {
            Console.WriteLine("Liste des commandes : ");
            List<string> chemintemps;
            List<string> chemindistance;
            foreach (Client c in clients)
            {
                foreach (Commande com in c.Commandes)
                {
                    // Affiche la commande du client
                    Console.WriteLine("----------Commnande du client----------");
                    Console.WriteLine(com);
                    // Affiche le chemin le plus court de la commande en temps
                    Console.WriteLine("----------Chemin le plus court de la commande----------");
                    chemintemps = com.Chemin("temps");
                    // Affiche le chemin le plus court de la commande en distance
                    chemindistance = com.Chemin("distance");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Rechercher une commande a partir de son id
        /// </summary>
        /// <param name="idC"></param>
        /// <returns></returns>
        public Commande? RechercherCommande(string idC)
        {
            int id;
            if (int.TryParse(idC, out id))
            {
                foreach (Client c in clients)
                {
                    foreach (Commande com in c.Commandes)
                    {
                        if (com.IdCommande == id)
                        {
                            return com;
                        }
                    }
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Attribuer une commande a un autre client (si l'entreprise c'est trompé de client par exemple)
        /// </summary>
        /// <param name="co"></param>
        /// <param name="cl1"></param>
        /// <param name="cl2"></param>
        public void AttribuerCommande(Commande co, Client cl1, Client cl2)
        {
            co.Clientcommande = cl2;
            cl2.Commandes.Add(co);
            cl1.Commandes.Remove(co);
        }

        /// <summary>
        /// Methode pour creer une commande
        /// </summary>
        /// <returns></returns>
        public Commande? CreerCommande()
        {
            Console.WriteLine("Saisissez les informations de la nouvelle commande :");

            List<Produit> ps = new List<Produit>();

            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("1. ajouter un produit à la commande");
                Console.WriteLine("tapez 'c' pour continuer la creation de la commande");

                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("produit de la commande:");
                        Produit p = Commande.CreerProduit();
                        if (p != null) ps.Add(p);
                        else Console.WriteLine("Format invalide");
                        break;
                    case "c":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
                        break;
                }
            }

            Console.WriteLine("id du client: ");
            Client cc = RechercherClient(Console.ReadLine());

            Console.WriteLine("Point de départ: ");
            string A = Console.ReadLine();

            Console.WriteLine("Point d'arrivée: ");
            string B = Console.ReadLine();

            Console.WriteLine("Véhicule id de la commande: ");
            Vehicule v = RechercherVehicule(Console.ReadLine());

            Console.WriteLine("Chauffeur id de la commande: ");
            Salarie sa = RechercherSalarie(Console.ReadLine());
            Chauffeur ch = null;
            if (sa is Chauffeur)
            {
                ch = (Chauffeur)sa;
            }

            Console.WriteLine("Date de la commande (YYYY-MM-DD HH:MM): ");
            DateTime dc;
            while (!DateTime.TryParse(Console.ReadLine(), out dc))
            {
                Console.WriteLine("Format de date invalide. Entrez à nouveau la date de naissance (format JJ/MM/AAAA) : ");
            }


            if (ps.Count() > 0 && cc != null && A != null && B != null && v != null && ch != null)
            {
                return new Commande(ps, cc, A, B, v, ch, dc);
            }
            return null;

        }

        /// <summary>
        /// Rechercher un vehicule a partir de son id
        /// </summary>
        /// <param name="idV"></param>
        /// <returns></returns>
        public Vehicule? RechercherVehicule(string idV)
        {

            int id;
            if (int.TryParse(idV, out id))
            {
                foreach (Vehicule v in vehicules)
                {
                    if (v.IdVehicule == id)
                    {
                        return v;
                    }
                }
                return null;
            }
            return null;

        }

        /// <summary>
        /// Methode pour modifier une commande
        /// </summary>
        /// <param name="CommandeAModifier"></param>
        public void ModifierCommande(Commande CommandeAModifier)
        {
            Console.WriteLine("Que voulez-vous modifier pour la commande " + CommandeAModifier.IdCommande.ToString() + " ?");
            Console.WriteLine("1. ajouter un produits");
            Console.WriteLine("2. supprimer un produit");
            Console.WriteLine("3. modifier un produit");
            Console.WriteLine("4. modifier le client");
            Console.WriteLine("5. modifier le pointA");
            Console.WriteLine("6. modifier le pointB");
            Console.WriteLine("7. modifier le prix de la commande");
            Console.WriteLine("8. modifier le vehicule");
            Console.WriteLine("9. Changer le chauffeur");
            Console.WriteLine("10. modifier la date");
            Console.WriteLine("tapez 'q' pour quitter");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Creation d'un produit");
                    Produit p = Commande.CreerProduit();
                    if (p != null) CommandeAModifier.Produits.Add(p);
                    else Console.WriteLine("Format invalide.");
                    break;
                case "2":
                    Console.WriteLine("Entrez l'id du produit à supprimer : ");
                    string n = Console.ReadLine();
                    Produit pr = CommandeAModifier.RechercherProduit(n);
                    if (pr != null) CommandeAModifier.Produits.Remove(pr);
                    else Console.WriteLine("Produit non trouvé.");
                    break;
                case "3":
                    Console.WriteLine("Entrez l'id du produit à modifier : ");
                    string m = Console.ReadLine();
                    Produit pro = CommandeAModifier.RechercherProduit(m);
                    if (pro != null) pro.ModifierProduit();
                    else Console.WriteLine("Format invalide.");
                    break;
                case "4":
                    Console.WriteLine("Entrez l'ID du nouveau client : ");
                    string idcli = Console.ReadLine();
                    Client nouveauClient = RechercherClient(idcli);
                    if (CommandeAModifier != null && nouveauClient != null) AttribuerCommande(CommandeAModifier, CommandeAModifier.Clientcommande, nouveauClient);
                    else Console.WriteLine("Erreur : Impossible d'attribuer la commande. Veuillez fournir un identifiant valide.");
                    break;
                case "5":
                    Console.WriteLine("Entrez le point de depart");
                    CommandeAModifier.PointA = Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("Entrez le point d'arrive");
                    CommandeAModifier.PointB = Console.ReadLine();
                    break;
                case "8":
                    Console.WriteLine("Entrez l'id du nouveau vehicule");
                    string id = Console.ReadLine();
                    Vehicule nouveauVehicule = RechercherVehicule(id);
                    if (nouveauVehicule != null) 
                    {   
                        if (nouveauVehicule.Libre==true)
                        {
                            CommandeAModifier.Vehicule = nouveauVehicule;
                            CommandeAModifier.Vehicule.Libre = false;
                        }
                    }
                    else Console.WriteLine("Format invalide.");
                    break;
                case "9":
                    Console.WriteLine("Entrez l'id du nouveau chauffeur");
                    string idch = Console.ReadLine();
                    Salarie ch = salaries.Find(s => s.NSS == idch);
                    Chauffeur cha;
                    if (ch != null)
                    {
                        if (ch is Chauffeur)
                        {
                            cha = (Chauffeur)ch;
                            if (cha.Libre == true) CommandeAModifier.Chauffeur = cha;
                        }
                    }
                    break;
                case "10":
                    Console.WriteLine("Entrez la nouvelle date");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime nouvelleDate))
                    {
                        CommandeAModifier.DateCommande = nouvelleDate;
                        Console.WriteLine("Date modifiée avec succès !");
                    }
                    else Console.WriteLine("Format de date invalide.");

                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }

        }

        /// <summary>
        /// Sauvegarder une commande
        /// </summary>
        /// <param name="CommandeASauvegarder"></param>
        public void SauvegarderCommande(Commande CommandeASauvegarder)
        {
            CommandeASauvegarder.Clientcommande.SupprimerCommande(CommandeASauvegarder);
            // Convertir la commande en une ligne CSV
            string ligneCSV = ConvertirCommandeEnCSV(CommandeASauvegarder);

            // Écrire la ligne CSV dans le fichier
            using (StreamWriter writer = new StreamWriter("commandes.csv", true))
            {
                writer.WriteLine(ligneCSV);
            }
        }

        /// <summary>
        /// Méthode pour convertir une commande en une ligne CSV
        /// </summary>
        /// <param name="commande"></param>
        /// <returns></returns>
        private string ConvertirCommandeEnCSV(Commande commande)
        {
            // Concaténer les attributs de la commande avec des virgules
            string clientID = commande.Clientcommande != null ? commande.Clientcommande.Id.ToString() : "";
            string vehiculeID = commande.Vehicule != null ? commande.Vehicule.IdVehicule.ToString() : "";
            string chauffeurID = commande.Chauffeur != null ? commande.Chauffeur.NSS.ToString() : "";

            return $"{commande.IdCommande},{clientID},{commande.PointA},{commande.PointB},{commande.PrixCommande},{vehiculeID},{chauffeurID},{commande.DateCommande}";
        }

        /// <summary>
        /// Methode de gestion des commandes
        /// </summary>
        public void ModuleCommande()
        {
            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("\n----------------------------------- Menu Commande -----------------------------------");
                Console.WriteLine("1. Modifier une commande");
                Console.WriteLine("2. Supprimer une commande");
                Console.WriteLine("3. Creer une commande");
                Console.WriteLine("4. Afficher les commandes");
                Console.WriteLine("5. Sauvegarder une commande");
                Console.WriteLine("tapez 'q' pour quitter");
                Console.Write("Choix: ");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("Entrez l'ID de la commande à modifier : ");
                        string idC1 = Console.ReadLine();
                        Commande commandeAModifier = RechercherCommande(idC1);
                        if (commandeAModifier != null) ModifierCommande(commandeAModifier);
                        else Console.WriteLine("Erreur : Impossible de modifier la commande. Veuillez fournir un identifiant valide.");
                        break;
                    case "2":
                        Console.WriteLine("Entrez l'ID de la commande à supprimer : ");
                        string idC2 = Console.ReadLine();
                        Commande commandeASupprimer = RechercherCommande(idC2);
                        if (commandeASupprimer != null) commandeASupprimer.Clientcommande.SupprimerCommande(commandeASupprimer);
                        else Console.WriteLine("Erreur : Impossible de supprimer la commande. Veuillez fournir un identifiant valide.");
                        break;
                    case "3":
                        Commande nouvelleCommande = CreerCommande();
                        if (nouvelleCommande != null) nouvelleCommande.Clientcommande.AjouterCommande(nouvelleCommande);
                        else Console.WriteLine("Erreur : Impossible de creer la commande. Veuillez fournir un identifiant valide.");
                        break;
                    case "4":
                        AfficheCommandes();
                        break;
                    case "5":
                        Console.WriteLine("Entrez l'ID de la commande à sauvegarder : ");
                        string idC3 = Console.ReadLine();
                        Commande commandeASauvegarder = RechercherCommande(idC3);
                        if (commandeASauvegarder != null) SauvegarderCommande(commandeASauvegarder);
                        else Console.WriteLine("Erreur : Impossible de sauvegarder la commande. Veuillez fournir un identifiant valide.");
                        break;
                    case "q":
                        continuer = false;
                        break;
                    default:
                        break;
                }
            }
        }


        // -------------------------------------- MODULE VEHICULE -------------------------------------------------

        /// <summary>
        /// Afficher les véhicules selon le filtre spécifié : libres, non libres ou tous.
        /// </summary>
        public void AfficherVehicules()
        {
            Console.WriteLine("Choisissez le type d'affichage des véhicules :");
            Console.WriteLine("1. Véhicules libres");
            Console.WriteLine("2. Véhicules non libres");
            Console.WriteLine("3. Tous les véhicules");
            Console.Write("Entrez votre choix (1, 2 ou 3) : ");
            
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    Console.WriteLine("\nListe des véhicules libres : ");
                    vehicules.Where(v => v.Libre).ToList().ForEach(Console.WriteLine);
                    break;
                case "2":
                    Console.WriteLine("\nListe des véhicules non libres : ");
                    vehicules.Where(v => !v.Libre).ToList().ForEach(Console.WriteLine);
                    break;
                case "3":
                    Console.WriteLine("\nListe de tous les véhicules : ");
                    vehicules.ForEach(Console.WriteLine);
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez entrer un numéro valide (1, 2 ou 3).");
                    break;
            }
        }

        /// <summary>
        /// Méthode pour ajouter un véhicule à la liste
        /// </summary>
        public void AjouterVehicule()
        {
            Console.WriteLine("Entrez l'ID du véhicule : ");
            int idVehicule = int.Parse(Console.ReadLine());

            Console.WriteLine("Entrez le prix du véhicule : ");
            int prixVehicule = int.Parse(Console.ReadLine());

            Console.WriteLine("Entrez l'autonomie du véhicule : ");
            int autonomie = int.Parse(Console.ReadLine());

            // Création d'un véhicule selon le type spécifié
            Console.WriteLine("Entrez le type de véhicule (Voiture, Camionnette) : ");
            string type = Console.ReadLine().ToLower();
            Vehicule vehicule = null;

            switch (type)
            {
                case "voiture":
                    Console.WriteLine("Entrez le nombre de places : ");
                    int places = int.Parse(Console.ReadLine());
                    vehicule = new Voiture(idVehicule, prixVehicule, autonomie, places);
                    break;
                case "camionnette":
                    Console.WriteLine("Entrez l'usage de la camionnette : ");
                    string usage = Console.ReadLine();
                    vehicule = new Camionnette(idVehicule, prixVehicule, autonomie, usage);
                    break;
                default:
                    break;
            }

            if (vehicule != null)
            {
                vehicules.Add(vehicule);
                Console.WriteLine("Véhicule ajouté avec succès !");
            }
            else
            {
                Console.WriteLine("Erreur lors de l'ajout du véhicule.");
            }
        }

        /// <summary>
        /// Méthode pour retirer un véhicule de la liste
        /// </summary>
        public void RetirerVehicule()
        {
            Vehicule vehiculeARetirer;
            Console.WriteLine("Entrez l'ID du véhicule à retirer : ");
            int id;
            if(int.TryParse(Console.ReadLine(),out id))
            {
                vehiculeARetirer = vehicules.FirstOrDefault(v => v.IdVehicule == id);
            }
            else
            {
                vehiculeARetirer = null;
            }

            if (vehiculeARetirer != null)
            {
                vehicules.Remove(vehiculeARetirer);
                Console.WriteLine("Véhicule retiré avec succès !");
            }
            else
            {
                Console.WriteLine("Véhicule non trouvé.");
            }
        }

        /// <summary>
        /// Méthode pour rechercher un véhicule par ID
        /// </summary>
        /// <returns>Le véhicule trouvé ou null</returns>
        public Vehicule? RechercherVehiculeParId()
        {
            Console.WriteLine("Entrez l'ID du véhicule : ");
            int id;
            if(int.TryParse(Console.ReadLine(),out id))
            {
                return vehicules.FirstOrDefault(v => v.IdVehicule == id);
            }
            return null;
        }

        /// <summary>
        /// Méthode de gestion des véhicules
        /// </summary>
        public void ModuleVehicule()
        {
            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("\n----------------------------------- Menu Véhicule -----------------------------------");
                Console.WriteLine("1. Ajouter un véhicule");
                Console.WriteLine("2. Retirer un véhicule");
                Console.WriteLine("3. Afficher les véhicules");
                Console.WriteLine("4. Rechercher un véhicule par ID");
                Console.WriteLine("tapez 'q' pour quitter");
                Console.Write("Choix: ");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        AjouterVehicule();
                        break;
                    case "2":
                        RetirerVehicule();
                        break;
                    case "3":
                        AfficherVehicules();
                        break;
                    case "4":
                        Vehicule vehicule = RechercherVehiculeParId();
                        if (vehicule != null)
                            Console.WriteLine(vehicule);
                        else
                            Console.WriteLine("Aucun véhicule trouvé avec cet ID.");
                        break;
                    case "q":
                        continuer = false;
                        break;
                
                }
            }
        }

    }
}