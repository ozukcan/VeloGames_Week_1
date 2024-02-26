using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using VeloGames_Day_1.Models;

namespace VeloGames_Day_1.Data;

public class LibExecutes : ILibExecutes
{
    private readonly List<Book> _books;

    public LibExecutes()
    {
        _books = new List<Book>()
        {
            new Book()
            {
                Title = "Beyaz Diş",
                Author = "Jack London",
                ISBN = "1234567823123",
                CopyCount = 40,
                BorrowedCount = 0,
            },
            new Book()
            {
                Title = "Pempe Diş",
                Author = "Jack London",
                ISBN = "123456782313",
                CopyCount = 40,
                BorrowedCount = 0,
            }
        };
    }

    public void Add(Book book) //Adminler için IDE'den ekleme 
    {
        _books.Add(book);
    }

    public void Add() //Kullanıcılar için programdan kitap ekleme
    {
        Console.WriteLine("Eklemek istediğiniz kitabın bilgilerini giriniz.\nKitabın Adı : ");
        string title = Console.ReadLine();
        Console.WriteLine("Yazarı : ");
        string author = Console.ReadLine();
        Console.WriteLine("ISBN No : ");
        string isbn = Console.ReadLine();
        Console.WriteLine("Kaç adet : ");
        int copyCount = Convert.ToInt32(Console.ReadLine());
        Book createdBook = new Book()
        {
            Title = title,
            Author = author,
            ISBN = isbn,
            CopyCount = copyCount,
            BorrowedCount = 0,
            Date = null
        };

        if (RuleCheck(createdBook))
        {
            Console.WriteLine("Kitabınız başarıyla eklendi");
            _books.Add(createdBook);
        }
        else
        {
            Console.WriteLine("Kitabınız adı en az 2 karakter ve isbn numarası en az 13 karakter olmalıdır.");
        }


        
           
    }

    public void Borrow()
    {
        Console.Write("Ödünç almak istediğiniz kitabın ISBN numarasını giriniz : ");
        string no = Console.ReadLine();
        Book? book = _books.Where(x => x.ISBN == no).SingleOrDefault();
        if (book is null)
        {
            Console.WriteLine("Aradığınız ISBN numarasına ait kitap bulunamadı");
        }
        else
        {
            book.CopyCount--;
            book.BorrowedCount++;
            book.Date = DateTime.Now.AddDays(21);
            Console.WriteLine("Ödünç alma işleminiz başarılı");
            Console.WriteLine($"{book.Date} tarihinde iade etmeyi unutmayın.");
        }
        
    }

    public void Search()
    {
        Console.WriteLine("Aramak istediğiniz kitabın adını veya yazarını giriniz");
        string text = Console.ReadLine();
        foreach (Book book in _books) 
        {
            if (book.Author == text || book.Title == text)
            {
                Console.WriteLine($"Kitap adı : {book.Title}, Yazarı : {book.Author}, ISBN : {book.ISBN}, Stok : {book.CopyCount}, Ödünç alınan kitap sayısı : {book.BorrowedCount}");
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun sonuçlar bulunamadı");
            }
        }

    }

    public void GetAllBooks()
    {
        foreach (Book book in _books)
        {
            Console.WriteLine($"Kitap adı : {book.Title}, Yazarı : {book.Author}, ISBN : {book.ISBN}, Stok : {book.CopyCount}, Ödünç alınan kitap sayısı : {book.BorrowedCount}");
        }
    }

    public void GetByExpired()
    {
        foreach (Book book in _books) 
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("-SÜRESİ GEÇMİŞ KİTAPLAR-");
            Console.WriteLine("------------------------\n");
            if ( book.Date is not null)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Kitap adı : {book.Title}, Yazarı : {book.Author}, ISBN : {book.ISBN}, İade edilmesi gereken tarih : {book.Date}");
            }
            
        }

    }

    public void ToReturn()
    {
        Console.Write("iade etmek istediğiniz kitabın isbn no giriniz : ");
        string no = Console.ReadLine();
        Book? book = _books.Where(x => x.ISBN == no).SingleOrDefault();
        if (book.Date is null)
        {
            Console.WriteLine("Aradığınız ISBN numarasına ait ödünç alınan kitap bulunamadı");
        }
        else
        {
            book.CopyCount++;
            book.BorrowedCount--;
            book.Date = null;
            Console.WriteLine("İade etme işleminiz başarılı");
        }

    }

    public bool RuleCheck(Book book)
    {
        Console.WriteLine("Girilen kitap bilgileri kontrol ediliyor...");
        Thread.Sleep(1500);
        if (book.Title.LongCount() >= 2 && book.ISBN.LongCount() == 13)
        {
            return true;
        }

        return false;


    }

    


}
