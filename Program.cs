using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{

    class Versenyzo
    {
        public string neve;
        public string kategoria;
        public string egyesulet;
        public int[] nyolcfordulo = new int[8];

        public Versenyzo(string neve, string kategoria, string egyesulet, int[] nyolcfordulo)
        {
            this.neve = neve;
            this.kategoria = kategoria;
            this.egyesulet = egyesulet;
            this.nyolcfordulo = nyolcfordulo;
        }
        public override string ToString()
        {
            return "\n\tNév: " + neve + "\n\tEgyesület: " + egyesulet + "\n\tÖsszpont: " + getOsszpont();
        }
       

        public int minimum(int[] nyolc)
        {
            int min = nyolc[0];

            for (int i = 0; i < nyolc.Length; i++)
            {
                if (min < nyolc[i])
                {
                    min = nyolc[i];
                }
            }
        
            return min;
        }

        public int getOsszpont()
        {
            int osszeg = 0;

            for (int i = 0; i < nyolcfordulo.Length; i++)
            {

                    osszeg += nyolcfordulo[i];
              
            }
            return osszeg;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Nemeth Peter;Felnott ferfi;FTC FOOTGOLF;10;0;23;32;0;0;0;0

            List<Versenyzo> versenyzok = new List<Versenyzo>();

            string[] sorok = File.ReadAllLines("fob2016.txt");

            foreach (var item in sorok)
            {
                string[] darabok = item.Split(';');

                int[] nyolcford = {Convert.ToInt32(darabok[3]), Convert.ToInt32(darabok[4]), Convert.ToInt32(darabok[5]), Convert.ToInt32(darabok[6]), Convert.ToInt32(darabok[7]), Convert.ToInt32(darabok[8]), Convert.ToInt32(darabok[9]), Convert.ToInt32(darabok[10]) };

                versenyzok.Add(new Versenyzo(darabok[0],darabok[1],darabok[2],nyolcford));

            }

            //3.feladat
            Console.WriteLine("3. feladat: Versenyzők száma: {0}", versenyzok.Count);

            //4.feladat:
            double noi = 0;
            double ferfi = 0;
            List<Versenyzo> versenyzo_nok = new List<Versenyzo>();
            foreach (var item in versenyzok) 
            {
                if(item.kategoria.Contains("ferfi"))
                {
                    ferfi++;
                } else
                {
                    noi++;
                    versenyzo_nok.Add(item);
                }
            }
            double arany = noi / versenyzok.Count * 100;
            Console.WriteLine("4. feladat:  A női versenyzők aránya: {0}%", Math.Round(arany, 2));

            //6.feladat:
            Versenyzo max = versenyzo_nok[0];
            foreach (var item in versenyzo_nok)
            {
                if(item.getOsszpont() > max.getOsszpont())
                {
                    max = item;
                }
                
            }
            Console.WriteLine("6. feladat: A bajnok női versenyző: {0}", max);

            //7.feladat:


            //8.feladat:
            List<String> egyesuletek = new List<String>();
            foreach (var item in versenyzok)
            {
                if(!egyesuletek.Contains(item.egyesulet))
                {
                    egyesuletek.Add(item.egyesulet);
                }
            }
            //cw +tabtab     
            //Dictionary<string, int> egyesletek = new Dictionary<string, int>();
            Console.WriteLine("8. feladat: Egyesületek statisztika");
            string egyesulet = "";
            int ossz = 0;
            for (int i = 0; i < egyesuletek.Count; i++)
            {
                egyesulet = egyesuletek[i];

                for (int j = 0; j < versenyzok.Count; j++)
                { 
                   if(versenyzok[j].egyesulet == egyesulet)
                    {
                        ossz++;
                    }
                }
                if(ossz > 2)
                {
                    Console.WriteLine("\t{0} - {1}", egyesulet, ossz);
                }
                ossz = 0;
            }



            Console.ReadKey();

        }
    }
}
