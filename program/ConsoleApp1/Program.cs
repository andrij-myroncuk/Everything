namespace pexeso2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool cykl = true;
            do
            {
                string[] znaky = { ":)", ":3", ":/", ":>", ":<", ":P" };
                int[,] pexeso = new int[3, 4];
                bool[,] odkryte = new bool[3, 4];
                int[] kontrola = { 0, 0, 0, 0, 0, 0 };
                bool loop = true;
                int R;
                Random random = new Random();
                for (int i = 0; i < pexeso.GetLength(0); i++)
                {
                    for (int j = 0; j < pexeso.GetLength(1); j++)
                    {
                        do
                        {
                            R = random.Next(1, 7);
                            if (kontrola[R - 1] != 2)
                            {
                                kontrola[R - 1]++;
                                pexeso[i, j] = R;
                                loop = false;
                            }
                            else
                            {
                                loop = true;
                            }
                        } while (loop);
                    }
                }

                int nalezeno = 0;
                do
                {
                    Console.Clear();
                    VypisPole(pexeso, znaky, odkryte);

                    Console.WriteLine("První políčko - řádek:");
                    int row1 = int.Parse(Console.ReadLine()) - 1;

                    if (row1 > 4 || row1 < 0)
                    {
                        break;
                    }

                    Console.WriteLine("První políčko - sloupec:");
                    int col1 = int.Parse(Console.ReadLine()) - 1;

                    if (col1 > 3 || col1 < 0)
                    {
                        break;
                    }

                    if (odkryte[row1, col1] == true)
                    {
                        continue;
                    }

                    odkryte[row1, col1] = true;
                    //string znak1 = znaky[pexeso[row1, col1]];

                    Console.Clear();
                    VypisPole(pexeso, znaky, odkryte);

                    Console.WriteLine("Druhé políčko - řádek:");
                    int row2 = int.Parse(Console.ReadLine()) - 1;

                    if (row2 > 4 || row2 < 0)
                    {
                        odkryte[row1, col1] = false;
                        break;
                    }

                    Console.WriteLine("Druhé políčko - sloupec:");
                    int col2 = int.Parse(Console.ReadLine()) - 1;

                    if (col2 > 3 || row2 < 0)
                    {
                        odkryte[row1, col1] = false;
                        break;
                    }

                    if (odkryte[row2, col2] == true)
                    {
                        continue;
                    }
                    odkryte[row2, col2] = true;

                    Console.Clear();
                    VypisPole(pexeso, znaky, odkryte);

                    if (pexeso[row1, col1] == pexeso[row2, col2] && !((row1) == (row2) && (col1) == (col2)))
                    {
                        Console.WriteLine("Shoda");
                        Thread.Sleep(2000);

                    }
                    else
                    {
                        Console.WriteLine("Neshoda");
                        Thread.Sleep(2000);
                        odkryte[row1, col1] = false;
                        odkryte[row2, col2] = false;
                    }


                } while (nalezeno < 6);

            } while (cykl);
        }
        public static void VypisPole(int[,] pexeso, string[] znaky, bool[,] odkryte)
        {
            Console.WriteLine("   1  2  3  4");
            for (int i = 0; i < pexeso.GetLength(0); i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < pexeso.GetLength(1); j++)
                {
                    if (odkryte[i, j] == false)
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write(znaky[pexeso[i, j] - 1] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}