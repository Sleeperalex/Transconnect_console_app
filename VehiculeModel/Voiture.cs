namespace Probleme
{
    public class Voiture : Vehicule
    {

        private int places;
        public Voiture(int idVehicule, int prixVehicule, int autonomie, int places) : base(idVehicule, prixVehicule, autonomie) 
        { 
            this.places = places;
        } 

        public override string ToString()
        {
            return base.ToString() + $" Places: {places}";
        }

        public int Places
        {
            get { return places; }
            set { places = value; }
        }
    }
}