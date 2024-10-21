namespace Probleme
{
    public class CamionFrigorifique : Camion
    {
        private int nbGroupesElectrogene;
        public CamionFrigorifique(int idVehicule, int prixVehicule, int autonomie, int volume, int nbGroupesElectrogene) : base(idVehicule, prixVehicule, autonomie, volume)
        {
            this.nbGroupesElectrogene = nbGroupesElectrogene;
        }

        public override string ToString()
        {
            return base.ToString() + $"Nombre de groupes d'electrogene: {nbGroupesElectrogene}";
        }
    }
}