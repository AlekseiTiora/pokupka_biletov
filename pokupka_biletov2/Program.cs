using System;

namespace pokupka_biletov2
{
    class Program
    {
        //справшивает какой хотите выбрать зал 1-маленький, 2-средний, 3-большой.
        static int Saali_suurus()
        {
            Console.WriteLine("Vali saali suurus: 1, 2, 3");
            int suurus = int.Parse(Console.ReadLine());
            return suurus;
        }
        static int[,] saal = new int[,] { };//создает двухмерный массив, для заполнения, 1 либо 0
        static int kohad, read;
        //выводит на экран кинозал с количеством мест. У каждой цифры своё количество рядов и мест
        static void Saali_taitmine(int suurus)
        {
            Random rnd = new Random();//рандомное число выберается
            //под цифрой 1 будет 20 мест и 10 рядов
            if (suurus == 1)
            {
                kohad = 20;
                read = 10;
            }
            //под цифрой 2 будет 20 мест и 20 рядов
            else if (suurus == 2)
            {
                kohad = 20;
                read = 20;
            }
            else
            {
                //под цифрой 3 будет 30 мест и 20 рядов
                kohad = 30;
                read = 20;
            }
            saal = new int[read, kohad];//
            for (int rida = 0; rida < read; rida++)
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    saal[rida, koht] = rnd.Next(0, 2);

                }
            }

        }

        //выводит количество рядов(слева) а количество мест (вверху)
        static void Saal_ekraanile()
        {

            Console.Write("      ");
            for (int koht = 0; koht < kohad; koht++)
            {
                if (koht.ToString().Length == 2)
                {
                    Console.Write(" {0}", koht + 1);
                }
                else
                {
                    Console.Write("  {0}", koht + 1);
                }
            }
            Console.WriteLine("\n");
            for (int rida = 0; rida < read; rida++)
            {
                Console.Write($"{rida + 1} rida: ");
                for (int koht = 0; koht < kohad; koht++)
                {
                    Console.Write(saal[rida, koht] + "  ");
                }

                Console.WriteLine("");
            }
        }

        static bool Ise()//функция для выбора одного человека,каторый пишет сам пользователь
        {
            Console.WriteLine("Rida:");
            int rida1 = int.Parse(Console.ReadLine());//пишет ряд
            Console.WriteLine("koht:");
            int koht1 = int.Parse(Console.ReadLine());//пишет место
            if (saal[rida1-1, koht1-1] == 0)
            {
                saal[rida1-1, koht1-1] = 1;
                Console.WriteLine("koht broneeritud");
                return true;

            }
            else// если в кинозале место стоит под номером 1 то она занято и его занять невозможно
            {
                Console.WriteLine("Koht on kinni");
                return false;

            }
        }
        //здесь мы выбираем какой ряд и место хотим занять тем самым свободное место станец цифрой 1
        static bool Muuk()//функция каторая сама покупает билеты при том что пользователь выбирает ряд
        {
            Console.WriteLine("Sisesta rida:");
            int rida = int.Parse(Console.ReadLine());
            Console.WriteLine("Mitu piletid:");
            int mitu = int.Parse(Console.ReadLine());

            int[] ost = new int[mitu];//массив для заполнения mitu 
            int p = (kohad - mitu) / 2;//вычисление середины
            bool t = false;
            int k = 0;
            do
            {
                //если мы ввели ряд и место он пищет свободны они или нет, если свободны то он их занимает
                if (saal[rida, p] == 0)
                {
                    ost[k] = p;
                    Console.WriteLine("koht {0} on vaba", p);
                    t = true;
                }
                else
                {
                    Console.WriteLine("koht {0} kinni", p);
                    t = false;
                    ost = new int[mitu];
                    k = 0;
                    p = (kohad - mitu) / 2;
                    break;
                }
                p = p - 1;
                k++;
            } while (mitu != k);
            if (t == true)
            {
                //выписывает ваши места в определеном ряду
                Console.WriteLine("Sinu kohad on:");
                foreach (var koh in ost)
                {
                    Console.WriteLine("{0}\n", koh);
                }
            }
            else
            {
                Console.WriteLine("Selles reas ei ole vabu kohti. Kas tahad teises reas otsida?");

            }
            return t;
        }


        // static void main выводит это все на экран выше перечисленное 
        public static void Main(string[] args)
        {
            int suurus = Saali_suurus();
            Saali_taitmine(suurus);
            while (true)
            {
                Saal_ekraanile();
                Console.WriteLine("1-ise valik, 2-masina valik");
                int valik = int.Parse(Console.ReadLine());
                if (valik == 1)//если пользователь выбирает 1 то он сам решает сколько билетов купить и какой он хочет ряд и место, если 2 то выберается все автоматически кроме ряда
                {
                    int koh = 0;
                    Console.WriteLine("Mitu pileteid tahad osta?");
                    int kogus = int.Parse(Console.ReadLine());
                    for (int i = 0; i < (kohad-1)*(read-1); i++)//когда выбираем 0-д
                    {
                        if(Ise())
                        {
                            koh++;
                        }
                        if(koh==kogus)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    bool muuk = false;
                    while (Muuk() != true)
                    {
                        muuk=Muuk();
                    }
                }
            }
            Console.ReadLine();
        }
    }
}