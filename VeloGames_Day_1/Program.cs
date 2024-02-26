using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using VeloGames_Day_1.Data;

LibExecutes libExec = new LibExecutes();

int secim;
bool durum = true;
while(durum)
{
    Console.Clear();
    Console.WriteLine("-------------------------------");
    Console.WriteLine("[1] Yeni bir kitap ekle");
    Console.WriteLine("[2] Kitapları listele");
    Console.WriteLine("[3] Yazar veya Kitap arayın");
    Console.WriteLine("[4] Kitap ödünç al");
    Console.WriteLine("[5] Kitap iade et");
    Console.WriteLine("[6] Süresi geçmiş kitapları görüntüle");
    Console.WriteLine("[0] Uygulamadan çıkış yap");
    Console.WriteLine("-------------------------------");

    Console.WriteLine("Seçiminiz : ");
    secim = Convert.ToInt32(Console.ReadLine());

    switch (secim)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(" Kitap adı en az 2 karakter olmalıdır");
            Console.WriteLine(" ISBN numarası en az 13 karakter olmalıdır");
            Console.WriteLine("-------------------------------------------------\n");
            libExec.Add();
            ReturnMenu();
            break;
        case 2:
            Console.Clear();
            libExec.GetAllBooks();
            ReturnMenu();
            break;
        case 3:
            Console.Clear();
            libExec.Search();
            ReturnMenu();
            break;
        case 4:
            Console.Clear();
            libExec.Borrow();
            ReturnMenu();
            break;
        case 5:
            Console.Clear();
            libExec.ToReturn();
            ReturnMenu();
            break;
        case 6:
            Console.Clear();
            libExec.GetByExpired();
            ReturnMenu();
            break;
        case 0:
            Console.Clear();
            Console.WriteLine("Sistem kapatılıyor...");
            Thread.Sleep(1500);
            durum = false;
            break;

        default:
            Console.WriteLine("Yanlış işlem uyguladınız ana menüye dönüyorsunuz..");
            break;
    }
}

void ReturnMenu()
{
    Console.WriteLine("Menüye dönmek için herhangi bir tuşa basınız.");
    Console.ReadKey();
}
