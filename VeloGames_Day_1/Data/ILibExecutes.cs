using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloGames_Day_1.Models;

namespace VeloGames_Day_1.Data;

public interface ILibExecutes
{
    void Add(Book book); //Kitap ekleme
    void Borrow(); //Ödünç alma
    void ToReturn(); //İade etme
    void Search(); //Kitap arama
    void GetAllBooks(); //Tüm kitapları listeleme
    void GetByExpired(); //Süresi geçmiş kitapları listeleme
    
}
