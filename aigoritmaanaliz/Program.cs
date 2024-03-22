using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Faktöriyelini hesaplamak istediğiniz sayıyı girin: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        long faktoriyel = FaktoriyelHesapla(sayi);
        Console.WriteLine($"{sayi}! = {faktoriyel}");
    }

    static long FaktoriyelHesapla(int sayi)
    {
        if (sayi == 0)
            return 1;

        long faktoriyel = 1;
        for (int i = 1; i <= sayi; i++)
        {
            faktoriyel *= i;
        }
        return faktoriyel;
    }
}
/*Kullanıcıdan bir sayı alındığında, bu işlem sabit bir zaman alır. Faktöriyel hesaplaması için döngü kullanılır. Bu döngü, 1'den n'e kadar 
 * (n kullanıcı tarafından verilen sayı) çalışır. Dolayısıyla, döngünün karmaşıklığı O(n) olur. Ekrana yazdırma kısmıda sabit zaman alır.
 * Bu algoritmanın zaman karmaşıklığı o(n)dir.*/
  