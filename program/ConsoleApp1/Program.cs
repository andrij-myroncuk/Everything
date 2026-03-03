
namespace ConsoleApp13
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
                VypisPole(pexeso, znaky);
            } while (!cykl);
        }
        public static void VypisPole(int[,] pexeso, string[] znaky)
        {
            Console.WriteLine("   1  2  3  4");
            for (int i = 0; i < pexeso.GetLength(0); i++)
            {
                Console.Write(i + 1 + " ");
                for (int j = 0; j < pexeso.GetLength(1); j++)
                {

                    Console.Write(znaky[pexeso[i, j] - 1] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
