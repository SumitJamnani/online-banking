using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmcity : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            viewcountry();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
    
 
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        
        DataSet ds = new DataSet();
       string  str="select * from  country_master where country_name ='" + txtcountryname.Text+"'";
       ds =cn.select(str);
     if(ds.Tables[0].Rows.Count == 0)
     {
        str = "insert into country_master(country_name) values('" + txtcountryname.Text + "')";
        cn.modify(str);
        Response.Write("<script>alert('Country Record inserted')</script>");     
    
     }
     else
     {
         Response.Write("<script>alert('Country Record duplicate')</script>");     
     }
        viewcountry();
    }

    public void viewcountry()
    {
        DataSet ds = new DataSet();
        string str = "select country_id , country_name   from  country_master";
        ds = cn.select(str);
        grdcountry.DataSource = ds.Tables[0];
        grdcountry.DataBind();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update country_master set  country_name='" + txtcountryname.Text + "' where country_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('Country Record  Updated')</script>");
        viewcountry();
        txtcountryname.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;

    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "country_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from country_master WHERE country_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtcountryname.Text = ds.Tables[0].Rows[0]["country_name"].ToString();
                    




                }


            }
        }
        catch
        {
        }

    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from country_master where country_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('Country Record  Deleted..')</script>");
        viewcountry();
        txtcountryname.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}