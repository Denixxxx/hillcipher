using System;

namespace hill
{
    class Program
    {
        static void Main(string[] args)
        {
            int o = 0;
            //şifrelenecek kelimeyi alma
            Console.WriteLine("Yazacağınız kelimenin uzunluğunu giriniz:");
            int uzunluk = Convert.ToInt32(Console.ReadLine());
            if (uzunluk % 2 != 0){uzunluk++;}

            string[] sifre = new string[uzunluk];

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
            for (int uz = 0; uz < uzunluk/2; uz++) {
                Console.WriteLine("Şifrelemek istediğiniz kelimenin ilk iki harfini giriniz(Eğer tek harf kaldıysa ikinci kelimeye'a' giriniz):");
                string kelime = Console.ReadLine();
                int[] index = new int[2];
              


                for (int i = 0; i < 2; i++)
                {
                    int a = kelime[i] - 97;
                    index[i] = a;
                    Console.WriteLine($"Harf: {kelime[i]}; Index: {index[i]}");
                }

                int s1 = nm11 * index[0];
                int s2 = nm12 * index[1];
                int s3 = nm21 * index[0];
                int s4 = nm22 * index[1];
                int s5 = s1 + s2;
                int s6 = s3 + s4;
                int k1 = s5 % 26;
                int k2 = s6 % 26;
                char ch = Convert.ToChar(k1 + 97);
                char ch2 = Convert.ToChar(k2 + 97);
                string st1 = Convert.ToString(ch);
                string st2 = Convert.ToString(ch2);
                sifre[o] = st1;
                sifre[o + 1] = st2;
                o += 2;

            }
            
            for (int t = 0; t < uzunluk; t++) { Console.Write(sifre[t]); }
           
        }
    }
}
