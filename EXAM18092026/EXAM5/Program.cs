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

        bool doiXung = true;

        for (int i = 0; i < n / 2; i++)
        {
            if (a[i] != a[n - 1 - i])
            {
                doiXung = false;
                break;
            }
        }

        if (doiXung)
        {
            Console.WriteLine("Mang doi xung.");
        }
        else
        {
            Console.WriteLine("Mang khong doi xung.");
        }
    }
}