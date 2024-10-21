namespace Probleme
{
    public abstract class Personne
    {
        
        protected string nom;
        protected string prenom;
        protected DateTime naissance;
        protected Address address;
        protected string mail;
        protected string portable;

       
        public Personne(string nom, string prenom, DateTime naissance, Address address, string mail, string portable)
        {
            
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance; 
            this.address = address;
            this.mail = mail;
            this.portable = portable;
           
        }

        public override string ToString()
        {
            return  "Nom: " + nom + ", Prénom: " + prenom + ", Date de naissance: " 
                + naissance.ToShortDateString() + ", Adresse postale: " + address.ToString() + ", Email: " 
                + mail + ", Portable: " + portable;
        }
        
        
        public string Nom 
        { 
            get { return nom; }
            set { nom = value; } 
        }
        public string Prenom 
        { 
            get { return prenom; }
            set { prenom = value; } 
        }
        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string Portable
        {
            get { return portable; }
            set { portable = value; }
        }
    }
}