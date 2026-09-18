using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine();

        int dem = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsWhiteSpace(s[i]) && !char.IsPunctuation(s[i]))
            {
                dem++;
            }
        }
        Console.WriteLine("So luong ky tu: " + dem);
    }
}