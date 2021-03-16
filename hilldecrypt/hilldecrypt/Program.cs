using System;

namespace hilldecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            int o = 0;
            //matris anahtarı girişi
            Console.WriteLine("2x2 lik anahtar matrisi giriniz: ");
            Console.WriteLine("M11 değerini giriniz:");
            int m11 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("M12 değerini giriniz:");
            int m12 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("M21 değerini giriniz:");
            int m21 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("M22 değerini giriniz:");
            int m22 = Convert.ToInt32(Console.ReadLine());

            //anahtarı mod 26 dan geçirme
            int nm11 = m11 % 26;
            int nm12 = m12 % 26;
            int nm21 = m21 % 26;
            int nm22 = m22 % 26;

            //determinantının 0 olmadığını checkleme
            int h1 = nm11 * nm22;
            int h2 = nm21 * nm12;
            int h3 = h1 - h2;
            if (h3 != 0)
            {
                int x = 0;
                while (true)
                {
                    if (h3 * x % 26 == 1)
                        break;
                    x++;
                }
                int nnm1 = nm22;
                int nnm2 = nm11;
                nm12 = -nm12;
                nm21 = -nm21;

                int nnnm1 = nnm1 * x;
                int nnnm2 = nm12 * x;
                int nnnm3 = nm21 * x;
                int nnnm4 = nnm2 * x;

                int k1 = nnnm1 % 26;
                int k2 = nnnm2 % 26;
                int k3 = nnnm3 % 26;
                int k4 = nnnm4 % 26;

                Console.WriteLine("Yazacağınız kelimenin uzunluğunu giriniz:");
                int uzunluk = Convert.ToInt32(Console.ReadLine());
                if (uzunluk % 2 != 0) { uzunluk++; }

                string[] sifre = new string[uzunluk];



                for (int uz = 0; uz < uzunluk / 2; uz++)
                {
                    Console.WriteLine("Deşifrelemek istediğiniz kelimenin ilk iki harfini giriniz(Eğer tek harf kaldıysa ikinci kelimeye 'a' giriniz):");
                    string kelime = Console.ReadLine();
                    int[] index = new int[2];

                    for (int i = 0; i < 2; i++)
                    {
                        int a = kelime[i] - 97;
                        index[i] = a;
                        Console.WriteLine($"Harf: {kelime[i]}; Index: {index[i]}");
                    }

                    int s1 = k1 * index[0];
                    int s2 = k2 * index[1];
                    int s3 = k3 * index[0];
                    int s4 = k4 * index[1];
                    int s5 = s1 + s2;
                    int s6 = s3 + s4;
                    int hh1 = s5 % 26;
                    int hh2 = s6 % 26;
                    if (hh1 < 0){ hh1 = hh1 + 26; }
                    if (hh2 < 0){ hh2 = hh2 + 26; }
                    char ch = Convert.ToChar(hh1 + 97);
                    char ch2 = Convert.ToChar(hh2 + 97);
                    string st1 = Convert.ToString(ch);
                    string st2 = Convert.ToString(ch2);
                    sifre[o] = st1;
                    sifre[o + 1] = st2;
                    o += 2;
                }

                for (int t = 0; t < uzunluk; t++) { Console.Write(sifre[t]); }
            }

            else { Console.WriteLine("Determinantı 0 olmayan matris giriniz."); }

            
        }
    }
}
