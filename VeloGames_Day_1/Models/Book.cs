﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloGames_Day_1.Models;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int? CopyCount { get; set; }
    public int? BorrowedCount { get; set; }
    public DateTime? Date { get; set; }


}
