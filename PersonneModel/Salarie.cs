
namespace Probleme
{
    public class Salarie : Personne
    {
        private string nss;
        string poste;
        private int salaire;
        private DateTime entree;
        private DateTime sortie;

        public Salarie(string nss, string nom, string prenom, DateTime naissance, Address address, string mail, string portable,
        string poste, int salaire, DateTime entree, DateTime sortie):base(nom,prenom,naissance,address,mail,portable)
        {
            this.nss = nss;
            this.poste = poste;
            this.salaire = salaire;
            this.entree = entree;
            this.sortie = sortie;
        }

        // 2e constructeur sans la date de sotrie (si le salarié est en CDI)
        public Salarie(string nss, string nom, string prenom, DateTime naissance, Address address, string mail, string portable,
        string poste, int salaire, DateTime entree):base(nom,prenom,naissance,address,mail,portable)
        {
            this.nss = nss;
            this.poste = poste;
            this.salaire = salaire;
            this.entree = entree;
            this.sortie =  DateTime.MaxValue;
        }

        public override string ToString()
        {
            return base.ToString()+", NSS: "+nss+", Poste: "+poste+", Salaire: "+salaire+", Date d'entrée: "+
            entree.ToShortDateString() + ", Date de sortie: "+sortie.ToShortDateString()+ "\n---";
        }

        public string NSS 
        { 
            get { return nss; }
        }

        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public int Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        public DateTime Entree
        {
            get { return entree; }
            set { entree = value; }
        }

        public DateTime Sortie
        {
            get { return sortie; }
            set { sortie = value; }
        }


        /// <summary>
        /// Modifier un salarie
        /// </summary>
        /// <param name="a"></param>
        public void ModifierSalarie(Arbre a) 
        {
            Console.WriteLine("Que voulez-vous modifier pour le salaire " + prenom + " " + nom.ToUpper() + " ?");
            Console.WriteLine("1. Nom");
            Console.WriteLine("2. Prénom");
            Console.WriteLine("3. Date de naissance");
            Console.WriteLine("4. Adresse postale");
            Console.WriteLine("5. Adresse email");
            Console.WriteLine("6. Numéro de téléphone");
            Console.WriteLine("7. Poste");
            Console.WriteLine("8. Salaire");
            Console.WriteLine("9. Date de sortie");

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
                            Noeud n = a.TrouverNoeud(this, a.Racine);
                            Tuple<string, string> t = new Tuple<string, string>(nouveauNom, n.Valeur.Item2);
                            n.Valeur = t;
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
                    case 7:
                        Console.WriteLine("Nouveau poste : ");
                        string nouveauPoste = Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("Nouveau salaire : ");
                        if (int.TryParse(Console.ReadLine(), out int nouveauSalaire))
                        {
                            salaire = nouveauSalaire;
                            Console.WriteLine("Salaire modifié avec succès !");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Nouvelle date de sortie (format JJ/MM/AAAA) : ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime nouvelleSortie))
                        {
                            sortie = nouvelleSortie;
                            Console.WriteLine("Date de sortie modifiée avec succès !");
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