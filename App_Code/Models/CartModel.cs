using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            // TODO SINGLETON 
            GarageDBEntities db = new GarageDBEntities();
            db.Carts.Add(cart);
            db.SaveChanges();

            return cart.DatePurchased + " was successfully inserted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            GarageDBEntities db = new GarageDBEntities();

            //Fetchobject from db
            Cart CartFromDb = db.Carts.Find(id);

            CartFromDb.DatePurchased = cart.DatePurchased;
            CartFromDb.ClientID = cart.ClientID;
            CartFromDb.Amount = cart.Amount;
            CartFromDb.IsInCart = cart.IsInCart;
            CartFromDb.ProductID = cart.ProductID;

            db.SaveChanges();
            return CartFromDb.DatePurchased + " was successfully updated";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string DeleteCart(int id)
    {
        try
        {
            GarageDBEntities db = new GarageDBEntities();
            Cart CartToBeDeleted = db.Carts.Find(id);

            db.Carts.Attach(CartToBeDeleted);
            db.Carts.Remove(CartToBeDeleted);
            db.SaveChanges();

            return CartToBeDeleted.DatePurchased + " was successfully deleted";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }
}