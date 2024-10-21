using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Probleme
{
    public class Graphe
    {

        private List<string> sommets; // liste des noms des villes
        private List<Arc> arcs;

        // Attribut pour stocker les informations de dijkstra 
        private List<int> distanceMinimal; // Distance minimal de villeDepart vers u (u etant la ville d'arrivée);
        private List<string> parent;
        private List<string> sommetsNonTraiter; // ensemble des sommets qui n'ont pas encore été traités

        public Graphe(List<Arc> arcs)
        {
            this.arcs = arcs;
            // Construire la liste des sommets à partir de la liste des arcs
            sommets = new List<string>(); // Initialisation de la liste des sommets
            foreach (Arc arc in arcs)
            {
                if (!sommets.Contains(arc.VilleA))
                {
                    sommets.Add(arc.VilleA);
                }
                if (!sommets.Contains(arc.VilleB))
                {
                    sommets.Add(arc.VilleB);
                }

            }

        }
        public List<int> DistanceMinimal { get { return distanceMinimal; } }

        public List<string> Sommets { get { return sommets; } }


        /// <summary>
        /// Convertir la liste d'arcs en matrice d'adjacence 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int[,] ConvertirArcsEnMatriceAdjacence(string type)
        {
            int n = sommets.Count;
            int[,] adjacence = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Absence d'arcs : Valeur = infini
                    adjacence[i, j] = 0;
                }
            }

            // Mettre à jour la matrice d'adjacence avec les distances entre les villes
            // Exemple : Paris --- 133 ---> Rouen. Si paris est a la 1ere position et Rouen en 2eme position. adjacence[1, 2] = 133
            foreach (Arc arc in arcs)
            {
                int indexA = sommets.IndexOf(arc.VilleA);
                int indexB = sommets.IndexOf(arc.VilleB);
                // Faire l'algo sur la distence ou le temps
                if (type == "distance")
                {
                    adjacence[indexA, indexB] = arc.Distance;
                }
                else

                {
                    adjacence[indexA, indexB] = arc.Temps;
                }

            }
            return adjacence;

        }

        /// <summary>
        /// Afficher la matrice d'adjacence
        /// </summary>
        /// <param name="adjacence"></param>
        public void AfficherMatriceAdjacence(int[,] adjacence)
        {
            int n = adjacence.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(adjacence[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Méthode pour initialiser l'algorithme de Dijkstra
        /// </summary>
        /// <param name="villeDeDepart"></param>
        public void InitialisationDijkstra(string villeDeDepart)
        {
            distanceMinimal = new List<int>();
            parent = new List<string>();
            sommetsNonTraiter = new List<string>();

            foreach (string sommet in sommets)
            {
                distanceMinimal.Add(int.MaxValue); // infini partout
                parent.Add(null); // se souvenir d'ou l'on vient. au debut, aucun parent.
                sommetsNonTraiter.Add(sommet); // Au debut, tous les sommets ne sont pas traités
            }

            distanceMinimal[sommets.IndexOf(villeDeDepart)] = 0; // distance de la ville de départ à villeDeDepart = 0;

        }


        /// <summary>
        /// Méthode pour relacher un arc 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="matriceAdjacence"></param>
        public void RelacherArc(string u, string v, int[,] matriceAdjacence)
        {
            int indexU = sommets.IndexOf(u);
            int indexV = sommets.IndexOf(v);

            if (distanceMinimal[indexV] > distanceMinimal[indexU] + matriceAdjacence[indexU, indexV])
            {
                distanceMinimal[indexV] = distanceMinimal[indexU] + matriceAdjacence[indexU, indexV];
                parent[indexV] = u;
            }
        }

        /// <summary>
        /// Algorithme de Dijkstra 
        /// </summary>
        /// <param name="villeDeDepart"></param>
        /// <param name="type"></param>
        public void AlgorithmeDijkstra(string villeDeDepart, string type)
        {
            InitialisationDijkstra(villeDeDepart);
            int[,] matriceAdjacence = ConvertirArcsEnMatriceAdjacence(type); // notre matrice des distances ou temps

            // Tant qu'on a pas traité tous les sommets
            while (sommetsNonTraiter.Count > 0)
            {


                // Extraire le sommet u avec la plus petite distance d(.)
                string u = ExtraireSommetMinimumDistance(sommetsNonTraiter);


                // Cas d'un sommet sans arc / cas d'une feuille
                if (u == null) { break; }


                // Pour tous les sommets des arcs sortants de u.
                for (int i = 0; i < sommets.Count; i++)
                {

                    int indexU = sommets.IndexOf(u);

                    // S'il y a un arc entre u et v
                    if (matriceAdjacence[indexU, i] != 0)
                    {
                        string v = sommets[i];
                        // Relacher tous les arcs sortants de u 
                        RelacherArc(u, v, matriceAdjacence);
                    }
                }

                sommetsNonTraiter.Remove(u); // Supprimer u des sommetsNonTraités


            }


        }

        /// <summary>
        /// Extraire des sommetsNonTraités, le sommet u ayant le plus petit d(.)
        /// </summary>
        /// <param name="sommetsNonTraiter"></param>
        /// <returns></returns>
        public string ExtraireSommetMinimumDistance(List<string> sommetsNonTraiter)
        {
            int minDistance = int.MaxValue;
            string sommetMinDistance = null;

            foreach (string sommet in sommetsNonTraiter)
            {

                int index = sommets.IndexOf(sommet);
                if (distanceMinimal[index] < minDistance)
                {
                    minDistance = distanceMinimal[index];
                    sommetMinDistance = sommet;
                }
            }

            return sommetMinDistance;
        }
        /// <summary>
        ///     Après avoir éxécuté Dijkstra, pour trouver les distances minimales depuis la ville de départ jusqu'à toutes les autres villes, 
        ///     on peut utilisé la liste "parent" pour retracer le chemin le + court entre la ville de départ et la ville d'arrivée.
        /// </summary>
        /// <param name="villeDepart"></param>
        /// <param name="villeArriver"></param>
        /// <returns> La liste des villes du chemin parcouru </returns>
        public List<string> CheminPlusCourt(string villeDepart, string villeArriver)
        {

            // Verifier que les villes sont bien dans la liste des sommets
            if (!sommets.Contains(villeDepart) || !sommets.Contains(villeArriver))
            {
                Console.WriteLine("Les villes ne sont pas valides");
                return null;
            }

            List<string> chemin = new List<string>();
            string villeActuelle = villeArriver;
            chemin.Add(villeActuelle);

            // Retracer le chemin à l'envers
            while (villeActuelle != villeDepart)
            {
                int indexVilleActuelle = sommets.IndexOf(villeActuelle);
                string parentVilleActuelle = parent[indexVilleActuelle];

                if (parentVilleActuelle == null)
                {
                    return null;
                }
                // Remonter dans les parents
                chemin.Add(parentVilleActuelle);
                villeActuelle = parentVilleActuelle;
            }

            // Reverse le chemin car on l'a a l'envers. 
            chemin.Reverse();
            return chemin;
        }


        /// <summary>
        /// Méthode qui retourne la distance ou le temps du chemin le plus court
        /// </summary>
        /// <param name="villeDarrivee"></param>
        /// <returns></returns>
        public int RetournerDistanceOuTempsMinimal(string villeDarrivee)
        {
            int indexVilleArrivee = sommets.IndexOf(villeDarrivee);
            return distanceMinimal[indexVilleArrivee];
        }
    }
}