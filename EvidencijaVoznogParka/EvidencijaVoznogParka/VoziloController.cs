using System;
using System.Collections.Generic;

namespace EvidencijaVoznogParka
{
    internal class VoziloController
    {

        public static void DodavanjeNovogVozila(List<Vozilo> vozila)
        {
            Console.WriteLine("--- Dodavanje novog vozila:");
            Vozilo vozilo = UpisPodatakaZaVozilo(null);
            vozila.Add(vozilo);

            Program.IspisSeparatorLinije();
            Console.WriteLine("Dodali ste novo vozilo. " + vozilo.ToString());
            Program.IspisPorukeZaPovratakNaMeni();
        }
        
        public static void AzuriranjePostojecegVozila(List<Vozilo> vozila)
        {
            if(vozila.Count == 0)
            {
                Console.WriteLine("Ne možete ažurirati vozila jer nije uneseno niti jedno vozilo.");
                Program.IspisPorukeZaPovratakNaMeni();
                return;
            }
            while (true)
            {
                Console.WriteLine("--- Ažuriranje vozila:\n");
                IspisVozila(vozila);
                Console.Write("\nRedni broj vozila koje želite ažurirati: ");
                if(int.TryParse(Console.ReadLine(), out int redniBrojVozila))
                {
                    try
                    {
                        Vozilo vozilo = vozila[redniBrojVozila];
                        Console.WriteLine();
                        UpisPodatakaZaVozilo(vozilo);

                        Program.IspisSeparatorLinije();
                        Console.WriteLine("Ažurirali ste vozilo. " + vozilo.ToString());
                        Program.IspisSeparatorLinije();
                        Console.WriteLine("Pritisnite Enter za povratak na meni...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    } catch (ArgumentOutOfRangeException e)
                    {
                        Console.Clear();
                        Console.WriteLine("Ne postoji vozilo za redni broj {0}. Unsite broj između 0 i {1}.", redniBrojVozila, vozila.Count - 1);
                        Program.IspisSeparatorLinije();
                        Console.WriteLine("Pritisnite Enter za nastavak...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                } else
                {
                    Console.WriteLine("Krivi unos. Unesite cijeli broj.");
                }
            }
        }

        private static Vozilo UpisPodatakaZaVozilo(Vozilo vozilo)
        {
            Console.Write("Marka vozila: ");
            string markaVozila = Console.ReadLine();
            Console.Write("Model vozila: ");
            string modelVozila = Console.ReadLine();
            if(vozilo == null)
            {
                vozilo = new Vozilo(markaVozila, modelVozila);
            } else
            {
                vozilo.markaVozila = markaVozila;
                vozilo.modelVozila = modelVozila;
            }
            Console.Write("Registarska oznaka: ");
            vozilo.registarskaOznaka = Console.ReadLine();
            Console.WriteLine("--- Datum izdavanja registarske oznake");
            vozilo.datumIzdavanjaRegistarskeOznake = GetDatumIzKonzole();
            Console.WriteLine("--- Datum isteka registracije");
            vozilo.datumIstekaRegistracije = GetDatumIzKonzole();

            return vozilo;
        }

        private static DateTime GetDatumIzKonzole()
        {
            int dan;
            int mjesec;
            int godina;
            Console.Write("Dan u mjesecu: ");
            while(true)
            {
                if (!int.TryParse(Console.ReadLine(), out dan) || dan < 1 || dan > 31)
                {
                    Console.Write("Krivi unos. Dan mora biti broj između 1 i 31. Ponovo unesite dan: ");
                    continue;
                }
                break;
            }

            Console.Write("Mjesec: ");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out mjesec) || mjesec < 1 || mjesec > 12)
                {
                    Console.Write("Krivi unos. Mjesec mora biti broj između 1 i 12. Ponovo unesite mjesec: ");
                    continue;
                }
                break;
            }

            Console.Write("Godina: ");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out godina) || godina < 1970 || godina > 2100)
                {
                    Console.Write("Krivi unos. Godina mora biti između 1970 i 2100. Ponovo unesite godinu: ");
                    continue;
                }
                break;
            }

            try
            {
                DateTime datum = new DateTime(godina, mjesec, dan);
                return datum;
            } catch (ArgumentOutOfRangeException e)
            {
                Program.IspisSeparatorLinije();
                Console.WriteLine("Unesena je kriva vrijednost {0}.{1}.{2}. Pokušajte ponovno.", dan, mjesec, godina);
                Program.IspisSeparatorLinije();
                return GetDatumIzKonzole();
            }
        }

        public static void IspisSvihVozilaIzMenija(List<Vozilo> vozila)
        {
            Console.WriteLine("--- Ispis svih vozila:");
            IspisVozila(vozila);
            Program.IspisPorukeZaPovratakNaMeni();
        }

        public static void IspisVozilaSaVazecomRegistracijom(List<Vozilo> vozila)
        {
            Console.WriteLine("--- Ispis vozila sa važećom registacijom:");
            List<Vozilo> vozilaSVazecomRegistracijom = new List<Vozilo>();
            foreach (Vozilo vozilo in vozila)
            {
                if(vozilo.datumIstekaRegistracije != null && DateTime.Today <= vozilo.datumIstekaRegistracije)
                {
                    vozilaSVazecomRegistracijom.Add(vozilo);
                }
            }

            IspisVozila(vozilaSVazecomRegistracijom);
            Program.IspisPorukeZaPovratakNaMeni();
        }

        public static void IspisVozilaSaIsteklomRegistracijom(List<Vozilo> vozila)
        {
            Console.WriteLine("--- Ispis vozila sa isteklom registracijom:");
            List<Vozilo> vozilaSVazecomRegistracijom = new List<Vozilo>();
            foreach (Vozilo vozilo in vozila)
            {
                if (vozilo.datumIstekaRegistracije == null || DateTime.Today > vozilo.datumIstekaRegistracije)
                {
                    vozilaSVazecomRegistracijom.Add(vozilo);
                }
            }

            IspisVozila(vozilaSVazecomRegistracijom);
            Program.IspisPorukeZaPovratakNaMeni();
        }

        public static void IspisVozila(List<Vozilo> vozila)
        {
            for (int i = 0; i < vozila.Count; i++)
            {
                Console.WriteLine(i + " - " + vozila[i].ToString());
            }
        }


    }
}
