using System;
 
namespace task1
{
    class task
    {
        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split(' ');
            int w = Convert.ToInt32(st[0]);
            int h = Convert.ToInt32(st[1]);
            int fullSize = w * h;
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[100, 100];
            int total = 0;
 
            for (int i = 0; i < h; ++i){  
                for(int j = 0; j < w; ++j){  
                        arr[i, j] = 0;
                }  
            }
             
            for (int i = 0; i < n; i++)
            {
                string[] sti = Console.ReadLine().Split(' ');
                int x1 = Convert.ToInt32(sti[0]);
                int y1 = Convert.ToInt32(sti[1]);
                int x2 = Convert.ToInt32(sti[2]);
                int y2 = Convert.ToInt32(sti[3]);
 
                for (int j = y1; j < y2; j++)
                {
                    for (int k = x1; k < x2; k++)
                    {
                        arr[j, k] = 1;
                    }
                }
            }
 
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        total++;
                    }
                }
            }
            Console.Write(total);
        }
    }
}
