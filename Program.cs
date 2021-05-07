using System;
using System.Diagnostics;
using System.Net;

namespace NetSpeedTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("İndirme İşlemi Başlatılıyor Lütfen Bekleyiniz...");
            
            var watch = new Stopwatch();
            byte[] data;

            using (var client = new WebClient())
            {
                watch.Start();
                data = client.DownloadData(
                    "http://ardownload.adobe.com/pub/adobe/reader/win/AcrobatDC/2001220041/AcroRdrDC2001220041_en_US.exe");
                watch.Stop();
            }

            Console.WriteLine("İndirme İşlemi Başarı ile Tamamlandı!");
            Console.WriteLine("Sonuçlar ekranınıza getiriliyor...");


            System.Threading.Thread.Sleep(5000);


            var speed = Math.Round((data.Length / watch.Elapsed.TotalSeconds) / (1000 * 1000), 2);
            Console.WriteLine($"İndirme Süresi: {watch.Elapsed}");
            Console.WriteLine($"İnternet Hızı: {speed} Mbps");
            Console.WriteLine("batuhan.senius Tarafından Yapılmıştır.");
                        

            Console.WriteLine("Devam etmek için hernagi bir tuşa basınız...");
            Console.ReadLine();
        }
    }
}
