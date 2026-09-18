using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine();

        string daoNguoc = "";

        for (int i = s.Length - 1; i >= 0; i--)
        {
            daoNguoc += s[i];
        }

        Console.WriteLine("Chuoi sau khi dao nguoc: " + daoNguoc);
    }
}