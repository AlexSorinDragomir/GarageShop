using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel
{
    public string InsertProduct(Product product)
    {
        try
        {
            // TODO SINGLETON 
            GarageDBEntities db = new GarageDBEntities();
            db.Products.Add(product);
            db.SaveChanges();

            return product.Name + " was successfully inserted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string UpdateProduct(int id, Product product)
    {
        try
        {
            GarageDBEntities db = new GarageDBEntities();

            //Fetchobject from db
            Product productFromDb = db.Products.Find(id);

            productFromDb.Name = product.Name;
            productFromDb.Price = product.Price;
            productFromDb.TypeId = product.TypeId;
            productFromDb.Description = product.Description;
            productFromDb.Image = product.Image;

            db.SaveChanges();
            return productFromDb.Name + " was successfully updated";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            GarageDBEntities db = new GarageDBEntities();
            Product productToBeDeleted = db.Products.Find(id);

            db.Products.Attach(productToBeDeleted);
            db.Products.Remove(productToBeDeleted);
            db.SaveChanges();

            return productToBeDeleted.Name + " was successfully deleted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public Product GetProduct(int id)
    {
        try
        {
            using (GarageDBEntities db = new GarageDBEntities())
            {
                Product product = db.Products.Find(id);
                return product;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            using (GarageDBEntities db = new GarageDBEntities())
            {
                List<Product> products = (from x in db.Products
                                          select x).ToList();
                return products;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<Product> GetProductsByType(int typeId)
    {
        try
        {
            using (GarageDBEntities db = new GarageDBEntities())
            {
                List<Product> products = (from x in db.Products
                                          where x.TypeId == typeId
                                          select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}