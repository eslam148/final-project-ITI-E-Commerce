﻿using E_Commerce_Back_End;
using E_CommerceDB;

namespace E_Commerce_Back_End
{
    public class OrderServices:Iorder
    {

        private LibraryContext db;
        public OrderServices(LibraryContext _db)
        {
            db = _db;
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
 
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
     
        public async Task AddOrder(OrderItemsCreateModel[] orderModel)
        {
            List<OrderItems> items = new List<OrderItems>();
            foreach (var item in orderModel)
            {
                OrderItems order = new OrderItems()
                {
                    Order_Details_id = item.Order_Details_id,
                    Product_id = item.Product_id,
                    Quantity = item.Quantity,
                    created_at = item.created_at,
                    modified_at = item.modified_at,
                    IsDeleted = false
                };
                items.Add(order);
            }

            await db.OrderItems.AddRangeAsync(items);
            await db.SaveChangesAsync();
        }

        public Order_Details AddOrderDetails(OrderDetailsCreateModel orderDetailsModel)
        {
            Order_Details orderDetails = new Order_Details()
            {
                User_id = orderDetailsModel.User_id,
                Total = orderDetailsModel.Total,
                Payment_id = orderDetailsModel.Payment_id,
                Created_at = orderDetailsModel.Created_at,
                Modified_at = orderDetailsModel.Created_at,
                IsDeleted = false,
                progress = 0
            };
            db.Order_Details.Add(orderDetails);
            db.SaveChanges();
            return db.Order_Details.Last();
        }
    }
}
