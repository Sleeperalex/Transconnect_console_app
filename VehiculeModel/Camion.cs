namespace Probleme
{
    public abstract class Camion : Vehicule
    {
        // volume en L
        private int volume;
        // Liste des matieres que le camion peut transporter
        private List<string> matieres;

        public Camion(int idVehicule, int prixVehicule, int autonomie, int volume) : base(idVehicule, prixVehicule, autonomie)
        {
            this.volume = volume;
            this.matieres = new List<string>();
        }

        public override string ToString()
        {
            return base.ToString() + $"Volume: {volume}";
        }

        public int Volume 
        { 
            get { return volume; } 
            set { volume = value; } 
        }
        public List<string> Matieres
        {
            get { return matieres; }
            set { matieres = value; }
        }
    }
}