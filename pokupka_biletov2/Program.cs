using System;

namespace pokupka_biletov2
{
    class Program
    {

        static int Saali_suurs()
        {
            Console.WriteLine("Vali saali suurus: 1, 2, 3");
            int suurus = int.Parse(Console.ReadLine());
            return suurus;
        }
        static int[,] saal = new int[,] { };
        static int kohad, read;
        static void Saali_taitmine(int suurus/*int[,] saal, Random rnd*/)
        {
            Random rnd = new Random();
            if (suurus == 1)
            {
                kohad = 20;
                read = 10;
            }
            else if (suurus == 2)
            {
                kohad = 20;
                read = 20;
            }
            else
            {
                kohad = 30;
                read = 20;
            }
            saal = new int[read, kohad];
            for (int rida = 0; rida < read; rida++)
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    saal[rida, koht] = rnd.Next(0, 2);

                }
            }

        }
        static void Saal_ekraanile()
        {
            Console.Write(" ");
            for (int koht = 0; koht < kohad; koht++)
            {
                if (koht.ToString().Length ==2 )
                {

                    Console.Write(" {0}", koht + 1);
                }
                else
                {

                    Console.Write(" {0}", koht + 1); 
                }
            }
            Console.WriteLine();

            for (int rida = 0; rida < read; rida++)
            {
                Console.Write($"{rida + 1} rida ");
                for (int koht = 0; koht < kohad; koht++)
                {
                    Console.Write(saal[rida, koht] + " ");
                }
                Console.WriteLine();

            }

        }
       
        static bool Muuk()
        {
            Console.WriteLine("Sisesta rida");
            int rida = int.Parse(Console.ReadLine());
            Console.WriteLine("Mitu piletid");
            int mitu = int.Parse(Console.ReadLine());
            int p = kohad / 2;




            if (saal[rida, p] == 0)
            {
                Console.WriteLine("koht{0} on vaba", p);
                return true;
            }
            else
            {
                Console.WriteLine("koht {0} on kinni", p);
                return false;
            }

        }
        static void Main(string[] args)
        {
            int suurus = Saali_suurs();
            Saali_taitmine(suurus);
            while (true)
            {
                Saal_ekraanile();
                bool ost = Muuk();
                Console.WriteLine(ost);
            }


            Console.ReadLine();
        }
    }
}
