using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Probleme
{
    // Classe Arc pour l'algorithme de Dijkstra
    public class Arc
    {
        private string villeA;
        private string villeB;
        private int distance;
        private int temps;


        public Arc(string villeA, string villeB, int distance, int temps)
        {
            this.villeA = villeA;
            this.villeB = villeB;
            this.distance = distance;
            this.temps = temps;
        }

        public string VilleA { get { return villeA; } }
        public string VilleB { get { return villeB; } }
        public int Distance { get { return distance; } }
        public int Temps { get { return temps; } }

        public override string ToString()
        {
            return $"Ville A: {villeA}, Ville B: {villeB}, Distance: {distance}, Temps: {temps}";
        }
    }


}