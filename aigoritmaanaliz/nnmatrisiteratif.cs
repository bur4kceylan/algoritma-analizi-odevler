using System;

class Program
{
    static void Main(string[] args)
    {
        int n;
        Console.WriteLine("Matris boyutunu girin:");
        n = Convert.ToInt32(Console.ReadLine());

        int[,] matris1 = new int[n, n];
        int[,] matris2 = new int[n, n];
        int[,] carpimMatrisi = new int[n, n];

        Console.WriteLine("İlk matrisin elemanlarını girin:");
        MatrisGir(matris1);

        Console.WriteLine("İkinci matrisin elemanlarını girin:");
        MatrisGir(matris2);

        MatrisCarp(matris1, matris2, carpimMatrisi);

        Console.WriteLine("Matris Çarpımı:");
        MatrisYazdir(carpimMatrisi);
    }

    static void MatrisGir(int[,] matris)
    {
        for (int i = 0; i < matris.GetLength(0); i++)
        {
            for (int j = 0; j < matris.GetLength(1); j++)
            {
                matris[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }

    static void MatrisCarp(int[,] matris1, int[,] matris2, int[,] carpimMatrisi)
    {
        for (int i = 0; i < matris1.GetLength(0); i++)
        {
            for (int j = 0; j < matris2.GetLength(1); j++)
            {
                carpimMatrisi[i, j] = 0;
                for (int k = 0; k < matris1.GetLength(1); k++)
                {
                    carpimMatrisi[i, j] += matris1[i, k] * matris2[k, j];
                }
            }
        }
    }

    static void MatrisYazdir(int[,] matris)
    {
        for (int i = 0; i < matris.GetLength(0); i++)
        {
            for (int j = 0; j < matris.GetLength(1); j++)
            {
                Console.Write(matris[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
/*Kullanıcıdan n adet girilen matris boyutunu alırız. (Zaman karmaşıklığı: O(1))
 * İki n * n boyutunda matris oluştururuz ve bu matrisleri kullanıcıdan elemanları alırız. (Zaman karmaşıklığı: O(n^2))
 * Matris çarpımı işlemi için üç tane döngü kullanırız. İlk döngü, sonuç matrisinin satırlarını dolaşır. 
 * İkinci döngü, sonuç matrisinin sütunlarını dolaşır. Üçüncü döngü ise iç çarpımı yapar. (Zaman karmaşıklığı: O(n^3)) 
 * çarpım matrisini ekrana yazdırırız. (Zaman karmaşıklığı: O(n^2))
 * toplam zaman kamaşıklığı : O(n^3)*/