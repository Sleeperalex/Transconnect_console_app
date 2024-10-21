namespace Probleme
{
    public class CamionCiterne : Camion
    {
        private string typeCuve;

        public CamionCiterne(int idVehicule, int prixVehicule, int autonomie, int volume, string typeCuve) : base(idVehicule, prixVehicule, autonomie, volume)
        {
            this.typeCuve = typeCuve;
        }

        public override string ToString()
        {
            return base.ToString() + $" Type de cuve: {typeCuve} ";
        }
    }
}