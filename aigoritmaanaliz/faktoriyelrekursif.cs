using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Faktöriyelini hesaplamak istediğiniz sayıyı girin: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        
        long faktoriyel = faktoriyelHesapla(sayi);

        
        Console.WriteLine($"{sayi}! = {faktoriyel}");
    }

    static long faktoriyelHesapla(int sayi)
    {
        if (sayi == 0)
            return 1;

        return sayi * faktoriyelHesapla(sayi - 1);
    }
}
/*tekrar tekrar çağırdığı için zaman karmaşıklığı açısından O(n) 'dir, 
 * n kullanıcı tarafından girilen sayıdır. Her bir rekürsif çağrı bir işlem anlamına gelir,
 * n adet rekürsif çağrı n işlem anlamına gelir. Bu kodun zaman karmaşıklığı o(n)dir.Bu
 * algoritmanın performansı girilen sayı ile doğru orantılıdır.*/
