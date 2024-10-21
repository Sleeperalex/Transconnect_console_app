namespace Probleme
{
    public class Chauffeur : Salarie,ILibre
    {
        private bool libre;

        public Chauffeur(string nss, string nom, string prenom, DateTime naissance, Address address, string mail, string portable,
        string poste, int salaire, DateTime entree, DateTime sortie):base(nss,nom,prenom,naissance,address,mail,portable,poste,salaire,entree,sortie)
        {
            this.libre = true;
        }

        public Chauffeur(string nss, string nom, string prenom, DateTime naissance, Address address, string mail, string portable,
        string poste, int salaire, DateTime entree):base(nss,nom,prenom,naissance,address,mail,portable,poste,salaire,entree)
        {
            this.libre = true;
        }

        public bool Libre
        {
            get { return libre; }
            set { libre = value; }
        }

        public override string ToString()
        {
            return " libre: " + libre.ToString() +", "+ base.ToString();
        }



    }

}