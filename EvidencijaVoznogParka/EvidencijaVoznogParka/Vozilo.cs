using System;

namespace EvidencijaVoznogParka
{
    internal class Vozilo
    {
        public string markaVozila { get; set; }
        public string modelVozila { get; set; }
        public string registarskaOznaka { get; set; }
        public DateTime datumIzdavanjaRegistarskeOznake { get; set; }
        public DateTime datumIstekaRegistracije { get; set; }

        public Vozilo(string markaVozila, string modelVozila)
        {
            this.markaVozila = markaVozila;
            this.modelVozila = modelVozila;
        }

        public string GetMarkaIModelVozila()
        {
            return String.Format("Marka vozila je {0}, a model {1}.", markaVozila, modelVozila);
        }

        public override string ToString()
        {
            if (registarskaOznaka == null)
            {
                return GetMarkaIModelVozila();
            }
            return GetMarkaIModelVozila() + String.Format(" Registarska oznaka je {0}. Datum izdavanja registarske oznake je {1:d} Datum isteka registracije je {2:d}"
                , registarskaOznaka, datumIzdavanjaRegistarskeOznake, datumIstekaRegistracije);
        }
    }
}
