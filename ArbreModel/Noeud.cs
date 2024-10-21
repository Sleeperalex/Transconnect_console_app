namespace Probleme
{
    public class Noeud
    {

        private Tuple<string, string> valeur;
        private Noeud successeur;
        private Noeud frere;

        public Noeud(Salarie s)
        {
            this.valeur = new Tuple<string, string>(s.Nom, s.Poste);
            this.successeur = null;
            this.frere = null;
        }

        public Tuple<string, string> Valeur
        {
            get { return this.valeur; }
            set { this.valeur = value; }
        }

        public Noeud Successeur
        {
            get { return this.successeur; }
            set { this.successeur = value; }
        }

        public Noeud Frere
        {
            get { return this.frere; }
            set { this.frere = value; }
        }

        public void Affiche(string prefix = "", bool dernier = true)
        {
            if (valeur != null)
            {
                Console.WriteLine(prefix + "└── " + valeur.Item1 + " (" + valeur.Item2 + ")");
                var newPrefix = prefix + (dernier ? "    " : "│   ");
                if (successeur != null)
                {
                    successeur.Affiche(newPrefix, frere == null);
                }
                if (frere != null)
                {
                    frere.Affiche(prefix, true);
                }
            }
        }

        public bool EstFeuille()
        {
            bool ok = true;
            // Un noeud est une feuille si son successeur est null et aucun de ses frères n'a de successeur
            if (Successeur != null)
            {
                ok = false;
            }
            if (frere != null)
            {
                Noeud frereCourant = frere;
                while (frereCourant != null)
                {
                    if (frereCourant.successeur != null)
                    {
                        ok = false;
                    }
                    frereCourant = frereCourant.frere;
                }
            }
            return ok;
        }




    }
}