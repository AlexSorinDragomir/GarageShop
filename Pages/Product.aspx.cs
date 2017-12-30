using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

//public partial class CarModel
//{
//    public string value { get; set; }
//    public string title { get; set; }
//}

//public partial class CarItem
//{
//    public string value { get; set; }
//    public string title { get; set; }
//    public List<CarModel> models { get; set; }
//}


public partial class Pages_Product : System.Web.UI.Page
{

    //Dictionary<string, string> listOfCars = new Dictionary<string, string>();

    //Dictionary<string, string> carModels = new Dictionary<string, string>();

    //List<CarItem> items = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            string clientId = Context.User.Identity.GetUserId();
            if (clientId != null)
            {

                int id = Convert.ToInt32(Request.QueryString["id"]);
                int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                Cart cart = new Cart
                {
                    Amount = amount,
                    ClientID = clientId,
                    DatePurchased = DateTime.Now,
                    IsInCart = true,
                    ProductID = id
                };

                CartModel model = new CartModel();
                lblResult.Text = model.InsertCart(cart);
            }
            else
            {
                lblResult.Text = "Please log in to order items";
            }
        }
    }

    private void FillPage()
    {
        //if (items == null)
        //{
        //    var fileName = "cars.json";
        //    var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        //    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\", fileName);

        //    var json = File.ReadAllText(path);
        //    items = JsonConvert.DeserializeObject<List<CarItem>>(json);
        //    listOfCars.Clear();

        //    foreach (var item in items)
        //    {
        //        listOfCars.Add(item.value, item.title);
        //    }

        //    if (!IsPostBack)
        //    {
        //        CarDropDownList.DataSource = listOfCars;
        //        CarDropDownList.DataTextField = "Key";
        //        CarDropDownList.DataValueField = "Value";
        //        CarDropDownList.DataBind();

        //        var models = items.First().models;
        //        setCarModeDropDownDataSource(models);
        //    }
        //}
        
        //Get selected product data
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductModel model = new ProductModel();
            Product product = model.GetProduct(id);

            //Fill page with data
            lblTitle.Text = product.Name;
            lblDescription.Text = product.Description;
            lblPrice.Text = "Price per unit:<br/>£ " + product.Price;
            imgProduct.ImageUrl = "~/Images/Products/" + product.Image;
            lblItemNr.Text = product.Id.ToString();

            //Fill amount list with numbers 1-20
            int[] amount = Enumerable.Range(1, 20).ToArray();
            ddlAmount.DataSource = amount;
            ddlAmount.AppendDataBoundItems = true;
            ddlAmount.DataBind();
        }
    }

    //private void setCarModeDropDownDataSource(List<CarModel> models)
    //{
    //    carModels.Clear();
    //    foreach (var model in models)
    //    {
    //        carModels.Add(model.value, model.title);
    //    }

    //    CarModelDropDownList.DataSource = carModels;
    //    CarModelDropDownList.DataTextField = "Value";
    //    CarModelDropDownList.DataValueField = "Key";
    //    CarModelDropDownList.DataBind();
    //}

    //protected void CarDropDownList_TextChanged(object sender, EventArgs e)
    //{
    //    if (IsPostBack)
    //    {
    //        string carDropDownListSelectedVal = CarDropDownList.SelectedValue;
    //        string dropdownText = CarDropDownList.Text;
    //        foreach (var car in items)
    //        {
    //            if (car.title == carDropDownListSelectedVal)
    //            {
    //                setCarModeDropDownDataSource(car.models);
    //                break;
    //            }
    //        }
    //    }
    //}

   
}