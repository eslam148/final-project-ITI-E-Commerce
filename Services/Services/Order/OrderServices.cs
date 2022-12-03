﻿using Services;
using E_CommerceDB;

namespace Services
{
    public class OrderServices:Iorder
    {

        private LibraryContext db;
        public OrderServices(LibraryContext _db)
        {
            db = new LibraryContext();
        }
        public List<OrderItems> GetOrders()
        {
            var orders = db.OrderItems.ToList();
            return orders;
        }
        public void Delete(int id)
        {
            var order = db.OrderItems.FirstOrDefault(o=>o.Id== id);
            order.IsDeleted =true;
            db.SaveChanges();
        }

        public List<OrderItems> GetPendingOrders()
        {
            var pending = db.OrderItems.Where(o => o.Order_Details.progress == 0).ToList();
            return pending;
        }

        public List<OrderItems> GetDeliveredOrders()
        {
            var delivered = db.OrderItems.Where(o => o.Order_Details.progress == 1).ToList();
            return delivered;
        }

    }
}
