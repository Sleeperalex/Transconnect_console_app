
namespace Probleme
{
    public class Arbre : IAfficheSalaries
    {
        private Noeud racine;

        // creation de l'arbre a partir d'une liste de salaries
        public Arbre(List<Salarie> liste)
        {
            // recherche du patron
            Salarie patron = liste[0];
            foreach (Salarie s in liste)
            {
                string poste = s.Poste.ToUpper();
                // associer le patron
                if (poste == "DIRECTEUR GENERAL")
                {
                    this.racine = new Noeud(s);
                    patron = s;
                }
            }

            // associer les directeurs
            foreach (Salarie s in liste)
            {
                string poste = s.Poste.ToUpper();
                if ((poste.Contains("DIRECTEUR") || poste.Contains("DIRECTRICE")) && (poste != "DIRECTEUR GENERAL"))
                {
                    Associer(s, patron);
                }
            }

            // associer les chefs
            foreach (Salarie s in liste)
            {
                if (s.Poste.ToUpper().Contains("CHEF"))
                {
                    Salarie p = liste.Where(s => s.Poste.ToUpper().Contains("RATIONS")).FirstOrDefault();
                    Associer(s, p);
                }
            }

            // associer la direction comptable et controleur de gestion
            foreach (Salarie s in liste)
            {
                string poste = s.Poste.ToUpper();
                if (poste == "DIRECTION COMPTABLE" || poste == "CONTROLEUR DE GESTION")
                {
                    Salarie p = liste.Where(s => s.Poste.ToUpper() == "DIRECTEUR FINANCIER").FirstOrDefault();
                    Associer(s, p);
                }
            }

            // associer les employés
            foreach (Salarie s in liste)
            {
                string poste = s.Poste.ToUpper();
                // associer les commerciaux
                if (poste.Contains("COMMERCIAL") && !poste.Contains("DIRECTRICE"))
                {
                    Salarie p = liste.Where(s => s.Poste.ToUpper() == "DIRECTRICE COMMERCIALE").FirstOrDefault();
                    Associer(s, p);
                }
                // associer les comptables
                else if (poste.Contains("COMPTABLE") && !poste.Contains("DIRECTION"))
                {
                    Salarie p = liste.Where(s => s.Poste.ToUpper() == "DIRECTION COMPTABLE").FirstOrDefault();
                    Associer(s, p);
                }
                // associer les RH
                else if (poste.Contains("FORMATION") || poste.Contains("CONTRAT"))
                {
                    Salarie p = liste.Where(s => s.Poste.ToUpper() == "DIRECTRICE DES RH").FirstOrDefault();
                    Associer(s, p);
                }
                // associer les chauffeurs
                else if (s.Nom.ToUpper() == "ROMU" || s.Nom.ToUpper() == "ROMI" || s.Nom.ToUpper() == "ROMA")
                {
                    Salarie p = liste.Where(s => s.Nom.ToUpper() == "ROYAL").FirstOrDefault();
                    Associer(s, p);
                }
                else if (s.Nom.ToUpper() == "ROME" || s.Nom.ToUpper() == "RIMOU")
                {
                    Salarie p = liste.Where(s => s.Nom.ToUpper() == "PRINCE").FirstOrDefault();
                    Associer(s, p);
                }

            }


        }

        public Noeud Racine
        {
            get { return this.racine; }
            set { this.racine = value; }
        }

        //Ajoute un salarie dans l'arbre en specifiant son patron
        public void Associer(Salarie s, Salarie patron)
        {
            // Trouver le nœud correspondant au patron
            Noeud pn = TrouverNoeud(patron, this.racine);
            if (pn != null)
            {
                // Créer le nœud pour le nouveau salarié
                Noeud sn = new Noeud(s);
                // Si le patron n'a pas de successeur, définissez-le comme successeur
                if (pn.Successeur == null)
                {
                    pn.Successeur = sn;
                }
                else
                {
                    Noeud dernierFrere = pn.Successeur;
                    // Trouver le dernier frère
                    while (dernierFrere.Frere != null)
                    {
                        dernierFrere = dernierFrere.Frere;
                    }
                    // Ajouter le nouveau salarié comme frère du dernier enfant
                    dernierFrere.Frere = sn;
                }
            }
            else
            {
                Console.WriteLine("Patron not found.");
            }
        }

        // Méthode récursive pour trouver le noeud sur le salarié
        public Noeud TrouverNoeud(Salarie s, Noeud n)
        {
            if (n.Valeur.Item1 == s.Nom && n.Valeur.Item2 == s.Poste)
            {
                return n; // Si le nœud correspond au salarié, le retourner
            }
            if (n.Successeur != null)
            {
                Noeud trouver = TrouverNoeud(s, n.Successeur); // Recherche récursive dans les successeurs
                if (trouver != null)
                {
                    return trouver; // Si trouvé dans les successeurs, le retourner
                }
            }
            if (n.Frere != null)
            {
                Noeud found = TrouverNoeud(s, n.Frere); // Recherche récursive dans les frères
                if (found != null)
                {
                    return found; // Si trouvé parmi les frères, le retourner
                }
            }
            return null; // Pas trouvé
        }

        // Remplace un salarié par un autre
        public void Remplacer(Salarie ancien, Salarie nouveau)
        {
            if (nouveau != null && ancien != null)
            {
                Noeud ancienNoeud = TrouverNoeud(ancien, this.racine);
                Noeud nouveauNoeud = TrouverNoeud(nouveau, this.racine);
                // Si l'ancien salarié est dans l'arbre mais pas le nouveau
                if (ancienNoeud != null && nouveauNoeud == null)
                {
                    ancienNoeud.Valeur = new Tuple<string, string>(nouveau.Nom, ancien.Poste);
                }
                // Si l'ancien et le nouveau salarié sont dans l'arbre
                else if (ancienNoeud != null && nouveauNoeud != null)
                {
                    // Échange des valeurs entre les anciens et les nouveaux nœuds
                    string ancienNom = ancienNoeud.Valeur.Item1;
                    string ancienPoste = ancienNoeud.Valeur.Item2;
                    string nouveauNom = nouveauNoeud.Valeur.Item1;
                    string nouveauPoste = nouveauNoeud.Valeur.Item2;
                    ancienNoeud.Valeur = new Tuple<string, string>(nouveauNom, ancienPoste);
                    nouveauNoeud.Valeur = new Tuple<string, string>(ancienNom, nouveauPoste);
                }
                // Si l'ancien salarié n'est pas dans l'arbre
                else
                {
                    Console.WriteLine("erreur :Le salarié à remplacer n'est pas dans l'arbre");
                }
            }
            else
            {
                Console.WriteLine("errueur : le nouveau et/ou l'ancien salarié est de type null");
            }
        }

        // Supprime un salarié de l'arbre
        public void SupprimerSalarie(Salarie s)
        {
            Noeud sup = TrouverNoeud(s, this.racine);
            Deplacer(sup);
        }

        // Méthode récursive pour modifier la structure de l'arbre lorsque l'on souhaite supprimer salarié
        // Si le salarié a un successeur alors c'est un patron et il faur promouvoir un son salarié successeur
        // Si le salarié a un frère et pas de successeur son frere prend sa place dans l'arbre
        private void Deplacer(Noeud sup)
        {
            if (sup.Successeur == null && sup.Frere == null)
            {
                sup.Valeur = null;
            }
            else if (sup.Successeur != null)
            {
                Tuple<string, string> tmp1 = sup.Valeur;
                Tuple<string, string> tmp2 = sup.Successeur.Valeur;
                sup.Valeur = new Tuple<string, string>(tmp2.Item1, tmp1.Item2);
                Deplacer(sup.Successeur);
            }
            else if (sup.Frere != null)
            {
                Tuple<string, string> tmp1 = sup.Valeur;
                Tuple<string, string> tmp2 = sup.Frere.Valeur;
                sup.Valeur = new Tuple<string, string>(tmp2.Item1, tmp1.Item2);
                Deplacer(sup.Frere);
            }
        }

        // Affiche l'arbre
        public void AfficheSalaries()
        {
            racine.Affiche();
        }

    }

}