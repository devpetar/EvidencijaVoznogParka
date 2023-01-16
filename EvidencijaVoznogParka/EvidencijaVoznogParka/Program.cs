using System;
using System.Collections.Generic;

namespace EvidencijaVoznogParka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meni = GetMeni();
            List<Vozilo> listaVozila = new List<Vozilo>();            

            while (true)
            {
                IspisiMeni(meni);
                bool prekiniIzvodenje = false;

                Console.Write("\nOdabrani broj: ");
                if (int.TryParse(Console.ReadLine(), out int brojMeniOpcije))
                {
                    Console.Clear();
                    switch (brojMeniOpcije)
                    {
                        case 0:
                            VoziloController.DodavanjeNovogVozila(listaVozila);
                            break;
                        case 1:
                            VoziloController.AzuriranjePostojecegVozila(listaVozila);
                            break;
                        case 2:
                            VoziloController.IspisSvihVozilaIzMenija(listaVozila);
                            break;
                        case 3:
                            VoziloController.IspisVozilaSaVazecomRegistracijom(listaVozila);
                            break;
                        case 4:
                            VoziloController.IspisVozilaSaIsteklomRegistracijom(listaVozila);
                            break;
                        case 5:
                            Console.WriteLine("Prekinuli ste rad programa.\nPrisitnite Enter za izlazak...");
                            prekiniIzvodenje = true;
                            break;
                        default:
                            Console.WriteLine("Odabrali ste krivi broj ({0}). Broj mora biti od 0 do 5.", brojMeniOpcije);
                            IspisPorukeZaPovratakNaMeni();
                            break;
                    }
                }
                else
                {
                    IspisSeparatorLinije();
                    Console.WriteLine("Krivi unos. Unesite cijeli broj.");
                    continue;
                }

                if(prekiniIzvodenje)
                {
                    break;
                }
            }

            Console.ReadKey();
        }

        static string[] GetMeni()
        {
            return new string[] {
                "Dodavanje novog vozila",
                "Ažuriranje postojećeg vozila",
                "Ispis svih vozila",
                "Ispis vozila sa važećom registacijom",
                "Ispis vozila sa isteklom registracijom",
                "Prekid rada programa"
            }; 
        }

        static void IspisiMeni(string[] meni)
        {
            Console.WriteLine("Odaberite broj opcije s menija:\n");

            for(int i = 0; i < meni.Length; i++)
            {
                Console.WriteLine(i + " - " + meni[i]);
            }
        }

        public static void IspisSeparatorLinije()
        {
            Console.WriteLine("-------------------------------------------");
        }

        public static void IspisPorukeZaPovratakNaMeni()
        {
            Program.IspisSeparatorLinije();
            Console.WriteLine("Pritisnite Enter za povratak na meni...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
