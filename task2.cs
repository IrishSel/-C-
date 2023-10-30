using System;
 
namespace task2
{
    class Program
    {
        public static int[,] arr;
        public static int[] num;
        public static int n;
 
        public static Boolean CheckRow(int row){
            int j;
            for (j=0; j<n*n; j++)
                num[j] = 0;
             
            for (j=0; j<n*n; j++)
                num[ arr[row, j]-1 ]++;
             
            for (j=0; j<n*n; j++)
                if (num[j] != 1)
                    return false;
             
            return true;
        } 
 
        public static Boolean CheckCol(int col){
            int j;
            for (j=0; j<n*n; j++)
                num[j] = 0;
             
            for (j=0; j<n*n; j++)
                num[ arr[j, col]-1 ]++;
             
            for (j=0; j<n*n; j++)
                if (num[j] != 1)
                    return false;
             
            return true;
        }
 
        public static Boolean CheckSq(int ii, int jj){
            int j,i;
            for (j=0; j<n*n; j++)
                num[j] = 0;
             
            for (i=ii; i<ii+n; i++)
                for (j=jj; j<jj+n; j++)
                    num[ arr[i, j]-1 ]++;
             
            for (j=0; j<n*n; j++)
                if (num[j] != 1)
                    return false;
             
            return true;
        }
 
        static void Main(string[] args)
        {
            int i,j;
            n = Convert.ToInt32(Console.ReadLine());
            arr = new int[n*n,n*n];
            num = new int[n*n];
 
            for (i = 0; i < n*n; i++)
            {
                string[] st = Console.ReadLine().Split(' ');
                for (j = 0; j < n*n; j++)
                {
                    arr[i,j] = Convert.ToInt32(st[j]);
                    if (arr[i,j] > n*n)
                    {
                        Console.WriteLine("Incorrect");
                        return;
                    }
                }
                if (!CheckRow(i))
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
                 
            }
 
            for (j = 0; j < n*n; j++)
            {
                if (!CheckCol(j))
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
            }
 
            for (i = 0; i < n*n; i = i + n)
            {
                for (j = 0; j < n*n; j = j + n)
                {
                    if (!CheckSq(i, j))
                    {
                        Console.WriteLine("Incorrect");
                        return;
                    }
                }
            }
 
            Console.WriteLine("Correct");           
        }
    }
}