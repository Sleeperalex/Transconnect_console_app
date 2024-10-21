namespace Probleme
{
    public abstract class Vehicule: ILibre
    {
        private int idVehicule;
        private int prixVehicule;

        // autonomie en km
        private int autonomie;
        private bool libre;



        public Vehicule(int idVehicule, int prixVehicule, int autonomie)
        {
            this.idVehicule = idVehicule;
            this.prixVehicule = prixVehicule;
            this.autonomie = autonomie;
            this.libre = true;
        }

        public override string ToString()
        {
            return $"Id du vehicule: {idVehicule}, Prix: {prixVehicule}, Autonomie: {autonomie}, Libre: {libre},";
        }

        public int IdVehicule
        {
            get{return idVehicule;}
        }

        public bool Libre
        {
            get{return libre;}
            set{libre = value;}
        }
    }
}