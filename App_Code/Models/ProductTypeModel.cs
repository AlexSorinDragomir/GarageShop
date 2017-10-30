using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeTypeModel
/// </summary>
public class ProductTypeTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            // TODO SINGLETON 
            GarageDBEntities db = new GarageDBEntities();
            db.ProductTypes.Add(productType);
            db.SaveChanges();

            return productType.Name + " was successfully inserted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            GarageDBEntities db = new GarageDBEntities();

            //Fetchobject from db
            ProductType productTypeFromDb = db.ProductTypes.Find(id);

            productTypeFromDb.Name = productType.Name;

            db.SaveChanges();
            return productTypeFromDb.Name + " was successfully updated";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            GarageDBEntities db = new GarageDBEntities();
            ProductType productTypeToBeDeleted = db.ProductTypes.Find(id);

            db.ProductTypes.Attach(productTypeToBeDeleted);
            db.ProductTypes.Remove(productTypeToBeDeleted);
            db.SaveChanges();

            return productTypeToBeDeleted.Name + " was successfully deleted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }
}