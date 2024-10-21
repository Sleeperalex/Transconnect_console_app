using System.Diagnostics.Contracts;

namespace Probleme
{
    public class Client : Personne
    {
        private int id;
        private List<Commande> commandes;

        private static int idDernierClient = 1;


        public Client(string nom, string prenom, DateTime naissance, Address address, string mail, string portable)
        : base(nom,prenom,naissance,address,mail,portable)
        {
            this.id = idDernierClient;
            this.commandes = new List<Commande>();
            idDernierClient++;
        }
        public int Id {
            get { return id; }
        }

        public List<Commande> Commandes {
            get { return commandes; }
        }

        public override string ToString()
        {
            double prixAchatCumuler = PrixAchatCumuler();
            return "ID: " + id + ", " + "Prix total payé: " + prixAchatCumuler + ", " +  base.ToString() + "\n---";
            
        }

        /// <summary>
        /// Ajouter une commande
        /// </summary>
        /// <param name="command"></param>
        public void AjouterCommande(Commande command) {
            commandes.Add(command);
        }


        /// <summary>
        /// Supprimer une commande
        /// </summary>
        /// <param name="command"></param>
        public void SupprimerCommande(Commande command) {
            commandes.Remove(command);
        }
        
        /// <summary>
        /// Calculer le prix total d'une commande
        /// </summary>
        public double PrixAchatCumuler() {
            if(commandes != null) {
                double prixCumuler = 0;
                foreach (Commande commande in commandes) {
                    prixCumuler += commande.PrixCommande;
                }
                return prixCumuler;
            }
            else {
                return 0.0;
            }
        }
       
       /// <summary>
       /// Modifier un client
       /// </summary>
        public void ModifierClient() {
            Console.WriteLine("Que voulez-vous modifier pour le client " + prenom + " " + nom.ToUpper() + " ?");
            Console.WriteLine("1. Nom");
            Console.WriteLine("2. Prénom");
            Console.WriteLine("3. Date de naissance");
            Console.WriteLine("4. Adresse postale");
            Console.WriteLine("5. Adresse email");
            Console.WriteLine("6. Numéro de téléphone");

            int choix;
            #pragma warning disable CS8600 
            if (int.TryParse(Console.ReadLine(), out choix))
            {
                switch (choix)
                {
                    case 1:
                        Console.WriteLine("Nouveau nom : ");
                        string nouveauNom = Console.ReadLine();
                        if(nouveauNom != "" && nouveauNom != null) {
                            nom = nouveauNom;
                            Console.WriteLine("Nom modifié avec succès !");
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("Nouveau prénom : ");
                        string nouveauPrenom = Console.ReadLine();
                        if(nouveauPrenom != "" && nouveauPrenom != null) {
                            prenom = nouveauPrenom;
                            Console.WriteLine("Prénom modifié avec succès !");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Nouvelle date de naissance (format JJ/MM/AAAA) : ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime nouvelleNaissance))
                        {
                            naissance = nouvelleNaissance;
                            Console.WriteLine("Date de naissance modifiée avec succès !");
                        }
                        else
                        {
                            Console.WriteLine("Format de date invalide.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Nouvelle addresse : ");
                        Console.WriteLine("Nouvelle ville : ");
                        string ville = Console.ReadLine();
                        Console.WriteLine("Nouveau code postale : ");
                        string code_postale = Console.ReadLine();
    
                        if(ville != "" && ville != null && code_postale != "" && code_postale != null) {
                            address = new Address(ville, code_postale);
                            Console.WriteLine("Addresse modifiée avec succès !");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Nouvelle adresse email : ");
                        string nouveauMail = Console.ReadLine();
                        if(nouveauMail != "" && nouveauMail != null) {
                            mail = nouveauMail;
                            Console.WriteLine("Mail modifié avec succès !");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Nouveau numéro de téléphone : ");
                        string nouveauPortable = Console.ReadLine();
                        if(nouveauPortable != "" && nouveauPortable != null) {
                            portable = nouveauPortable;
                            Console.WriteLine("Numero de téléphone modifié avec succès !");
                        }
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Veuillez entrer un nombre valide.");
            }
            #pragma warning restore CS8600 
        }


    }
}