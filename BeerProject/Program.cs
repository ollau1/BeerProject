using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerProject
{
    internal class Program : Beer
    {
        static void Main(string[] args)
        {
            Beer beer1 = new Beer("Kattesved's Brewery", "tier C Sweat", 0.50, 4.3, Beer._beerType.WIENERDORTMUNDER);
            //Console.WriteLine(beer1);
            Beer beer2 = new Beer("Tuborg", "Grøn Tuborg", 0.50, 6.3, Beer._beerType.LAGER);

            Beer beer3 = new Beer("Carlsberg", "Classic", 0.50, 8.3, Beer._beerType.PILSNER);

            //VIRKER SOM DEN SKAL (TROR JEG) IKKE ÆNDRE NOGET.
            beer1.Add(beer2);
           //Console.WriteLine(beer1);


            //IKKE STATIC MIX VIRKER SOM DEN SKAL IK ÆNDRE NOGET.
            Beer beer4 = new Beer();
            beer4 = beer2.Mix(beer3);
            //Console.WriteLine(beer4);

            //STATIC MIX VIRKER SOM DEN SKAL IK ÆNDRE NOGET.
            Beer beer5 = new Beer("Peeborg", "Yellow Peeborg", 0.50, 1.3, Beer._beerType.PORTER);
            Beer beer6 = new Beer("MarkBerg", "Blå MarkBerg", 0.50, 2.3, Beer._beerType.MÜNCHENER);
            Beer beer7 = new Beer();
            beer7 = Beer.Mix(beer5, beer6);
            //Console.WriteLine(beer7);

            //Sorteret ved brug af IComparable.
            Console.WriteLine("Sorted By Unit (IComparable)");
            Beer[] beers = new Beer[7];
            beers[0] = beer1;
            beers[1] = beer2;
            beers[2] = beer3;
            beers[3] = beer4;
            beers[4] = beer5;
            beers[5] = beer6;
            beers[6] = beer7;
            Array.Sort(beers);
            foreach (var item in beers)
            {
                Console.WriteLine(item);
            }


            //Sorteret ved brug af IComparer.
            Console.WriteLine("Sorted by Unit (IComparer)");
            SortingBeerBy compareByUnit = new SortingBeerBy(SortingBeerBy._sortBy.UNIT);
            Array.Sort(beers, compareByUnit);
            foreach (var item in beers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sortered by Percent:");
            SortingBeerBy compareByPercent = new SortingBeerBy(SortingBeerBy._sortBy.PERCENT);
            Array.Sort(beers, compareByPercent);
            foreach (var item in beers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sorteret by Volume:");
            SortingBeerBy compareByVolume = new SortingBeerBy(SortingBeerBy._sortBy.VOLUME);
            Array.Sort(beers, compareByVolume);
            foreach (var item in beers)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
