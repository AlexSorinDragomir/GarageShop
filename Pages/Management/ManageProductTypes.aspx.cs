using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageProductTypes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductTypeTypeModel productTypeModel = new ProductTypeTypeModel();
        ProductType productType = CreateProductType();

        lblResult.Text = productTypeModel.InsertProductType(productType);
    }

    private ProductType CreateProductType()
    {
        ProductType productType = new ProductType();
        productType.Name = txtName.Text;

        return productType;
    }
}