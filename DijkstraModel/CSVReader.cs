using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Probleme
{
    // Class CSV Reader pour lire le fichier Distances.csv
    public class CSVReader
    {
        public List<Arc> arcs;

        public CSVReader(string filePath)
        {
            arcs = ReadCSV(filePath);
        }

        public List<Arc> Arcs { get { return arcs; } }
        public List<Arc> ReadCSV(string filePath)
        {
            List<Arc> arcs = new List<Arc>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        if (fields.Length == 4)
                        {
                            string villeA = fields[0].Trim();
                            string villeB = fields[1].Trim();
                            int distance = int.Parse(fields[2].Trim());
                            int temps = ConvertirStringEnMinutes(fields[3].Trim());
                            Arc arc = new Arc(villeA, villeB, distance, temps);
                            arcs.Add(arc);
                        }
                        else
                        {
                            Console.WriteLine("Erreur : format du CSV invalide.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur en lisant le fichier CSV : {ex.Message}");
            }

            return arcs;
        }

        /// <summary>
        /// Méthode permetant de convertir la colonne temps en minutes
        /// </summary>
        /// <param name="tempsString"></param>
        /// <returns></returns>
        public int ConvertirStringEnMinutes(string tempsString)
        {
            int heures = 0;
            int minutes = 0;

            // Cas où il y a heure et minutes (ex: 1h30)
            if (tempsString.Contains("h"))
            {
                // Divise le string en 2 (heures ET minutes)
                string[] parties = tempsString.Split('h');
                heures = int.Parse(parties[0]);

                if (parties.Length > 1 && parties[1].Length > 0)
                {
                    minutes = int.Parse(parties[1]);
                }
                // Cas où il y a heures 
                else if (parties[1].Length > 0)
                {
                    minutes = int.Parse(parties[1]);
                }
            }
            // Cas où il y a que minutes (ex: 35mn)
            else if (tempsString.Contains("mn"))
            {
                string[] parties = tempsString.Split('m');
                minutes = int.Parse(parties[0]);
            }


            return heures * 60 + minutes;
        }

    }
}