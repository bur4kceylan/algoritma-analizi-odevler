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

        CarpimMatrisiHesapla(matris1, matris2, carpimMatrisi, n);

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

    static void CarpimMatrisiHesapla(int[,] matris1, int[,] matris2, int[,] carpimMatrisi, int n)
    {
        if (n == 1)
        {
            carpimMatrisi[0, 0] = matris1[0, 0] * matris2[0, 0];
            return;
        }

        int[,] a11 = new int[n / 2, n / 2];
        int[,] a12 = new int[n / 2, n / 2];
        int[,] a21 = new int[n / 2, n / 2];
        int[,] a22 = new int[n / 2, n / 2];
        int[,] b11 = new int[n / 2, n / 2];
        int[,] b12 = new int[n / 2, n / 2];
        int[,] b21 = new int[n / 2, n / 2];
        int[,] b22 = new int[n / 2, n / 2];

        int[,] c11 = new int[n / 2, n / 2];
        int[,] c12 = new int[n / 2, n / 2];
        int[,] c21 = new int[n / 2, n / 2];
        int[,] c22 = new int[n / 2, n / 2];

        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                a11[i, j] = matris1[i, j];
                a12[i, j] = matris1[i, j + n / 2];
                a21[i, j] = matris1[i + n / 2, j];
                a22[i, j] = matris1[i + n / 2, j + n / 2];

                b11[i, j] = matris2[i, j];
                b12[i, j] = matris2[i, j + n / 2];
                b21[i, j] = matris2[i + n / 2, j];
                b22[i, j] = matris2[i + n / 2, j + n / 2];
            }
        }

        CarpimMatrisiHesapla(MatrisTopla(a11, a22, n / 2), MatrisTopla(b11, b22, n / 2), c11, n / 2);
        CarpimMatrisiHesapla(MatrisTopla(a21, a22, n / 2), b11, c12, n / 2);
        CarpimMatrisiHesapla(a11, MatrisCikar(b12, b22, n / 2), c21, n / 2);
        CarpimMatrisiHesapla(a22, MatrisCikar(b21, b11, n / 2), c22, n / 2);

        MatrisKopyala(c11, carpimMatrisi, 0, 0, n / 2);
        MatrisKopyala(c12, carpimMatrisi, 0, n / 2, n / 2);
        MatrisKopyala(c21, carpimMatrisi, n / 2, 0, n / 2);
        MatrisKopyala(c22, carpimMatrisi, n / 2, n / 2, n / 2);
    }

    static int[,] MatrisTopla(int[,] matris1, int[,] matris2, int n)
    {
        int[,] sonuc = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sonuc[i, j] = matris1[i, j] + matris2[i, j];
            }
        }
        return sonuc;
    }

    static int[,] MatrisCikar(int[,] matris1, int[,] matris2, int n)
    {
        int[,] sonuc = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sonuc[i, j] = matris1[i, j] - matris2[i, j];
            }
        }
        return sonuc;
    }

    static void MatrisKopyala(int[,] kaynak, int[,] hedef, int satirBaslangic, int sutunBaslangic, int boyut)
    {
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                hedef[satirBaslangic + i, sutunBaslangic + j] = kaynak[i, j];
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
 * Matris çarpımı işlemi için rekürsif bir algoritma kullanırız. Matrisler, boyutları yarıya indirilene kadar
 * dört parçaya bölünür. Her bir parçada çarpma işlemi tekrarlanır. (Zaman karmaşıklığı: O(n^3))
 * Son olarak, çarpım matrisini ekrana yazdırırız. (Zaman karmaşıklığı: O(n^2))
 * Toplam zaman karmaşıklığı: O(n^3)*/