using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine();

        Console.Write("Nhap ky tu can dem: ");
        char kyTu = char.Parse(Console.ReadLine());

        int dem = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == kyTu)
            {
                dem++;
            }
        }
        Console.WriteLine("Ky tu '" + kyTu + "' xuat hien " + dem + " lan.");
    }
}