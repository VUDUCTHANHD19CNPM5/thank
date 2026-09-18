using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap so luong phan tu n: ");
        int n = int.Parse(Console.ReadLine());

        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhap a[{0}]: ", i);
            a[i] = int.Parse(Console.ReadLine());
        }

        int max = a[0];

        for (int i = 1; i < n; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
            }
        }

        Console.WriteLine("Phan tu lon nhat trong mang = " + max);
    }
}