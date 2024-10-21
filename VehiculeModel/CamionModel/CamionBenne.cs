namespace Probleme
{
    public class CamionBenne : Camion
    {
        private int nbBennes;
        private int nbGrues;
        private List<string> equipements;

        public CamionBenne(int idVehicule, int prixVehicule, int autonomie, int volume, int nbBennes, int nbGrues, List<string> equipements) : base(idVehicule, prixVehicule, autonomie, volume)
        {
            this.nbBennes = nbBennes;
            this.nbGrues = nbGrues;
            this.equipements = equipements;
        }

        public override string ToString()
        {
            return base.ToString() + $" Nombre de benne(s): {nbBennes}, Nombre de grue(s): {nbGrues}, Equipements: {string.Join(", ", equipements)}";
        }
    }
}