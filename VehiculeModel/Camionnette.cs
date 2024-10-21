namespace Probleme
{
    public class Camionnette : Vehicule
    {
        private string usage;

        public Camionnette(int idVehicule, int prixVehicule, int autonomie, string usage) : base(idVehicule, prixVehicule, autonomie)
        {
            this.usage = usage;
        }

        public override string ToString()
        {
            return base.ToString() + $" Usage: {usage}";
        }

        public string Usage
        {
            get { return usage; }
            set { usage = value; }
        }
    }
}