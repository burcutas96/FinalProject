using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryID = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product { ProductId = 2, CategoryID = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product { ProductId = 3, CategoryID = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product { ProductId = 4, CategoryID = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product { ProductId = 5, CategoryID = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product);  //Bu kod listedeki elemanı silmez. Çünkü parametre olarak gelen product'ın referans numarası,
                                          //products listesinin içindeki hiçbir elemanla eşleşmez!

            //LINQ kullanmadan silme işlemi:
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if(product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);



            //LINQ kullanarak silme işlemi:
            //p, foreach'te olduğu gibi döngünün içindeki her bir elemana verdiğimiz takma isimdir.
            
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //where metodu, içindeki koşula uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
