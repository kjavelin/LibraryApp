﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Borrow
    {
        public int Id { get; set; }
        
        // ödünç alınma tarihi
        public DateTime BorrowedTime { get; set; }
        // ödünç verilme tarihi
        public DateTime LentTime { get; set; }

        //geri getirildi mi ?
        public bool IsLent { get; set; }


        public virtual User User { get; set; }
        public virtual Book Book { get; set; }




    }
}