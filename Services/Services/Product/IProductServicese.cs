﻿using Services;

namespace Services
{
    public interface IProductServices
    {
        public IEnumerable<ProductsVM> GetAllSold();
        public IEnumerable<ProductsVM> GetAllExisting();
        public IEnumerable<ProductsVM> GetAllAdminProduct();
        public void DeleteProduct(int Id);
        public ProductsVM GetProductById(int Id);
        public void AddProdcut(ProductsVM product);
        public void Edit(ProductsVM product);
        public IEnumerable<DiscountProductVM> GitALlDiscount();

    }
}

