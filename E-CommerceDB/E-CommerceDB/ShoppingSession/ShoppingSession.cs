﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDB
{
    public class ShoppingSession
    {
        public int Id { get; set; }
        public decimal total { get; set; }
        public String UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual User user { get; set; }

        public ICollection<CartItem> CartItem { get; set; }
    }
}
