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
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewcity();
            binddropdown();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
    
        }
    }
    protected void btnsave_click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from city_master where city_name='" + txtcityname.Text + "'and state_id=" + drpstate.SelectedValue + "";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into city_master(city_name,state_id) values ('" + txtcityname.Text + "'," + drpstate.SelectedValue + ")";
            cn.modify(str);
            Response.Write("<script>alert('City inserted..')</script>");
        }
        else
        {
            Response.Write("<script>alert('City duplicate')</script>");
        }
        viewcity();
    }
         public void binddropdown()
    {
        gf.fillcombo("select * from state_master", drpstate, "state_name", "state_id", "--select country--");
    }


    public void viewcity()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select city_id  ,city_name,state_id 'Sid' from city_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdcity.DataSource = ds.Tables[0];
                grdcity.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_click(object sender, EventArgs e)
    {
        string str = "update city_master set  city_name='" + txtcityname.Text + "',state_id='" + drpstate.SelectedValue + "' where city_id='"+ hdnid.Value +"'";
        cn.modify(str);
        Response.Write("<script>alert('City Updated')</script>");
        viewcity();
        txtcityname.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_click(object sender, EventArgs e)
    {
        string str = "delete from city_master where city_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('City Deleted..')</script>");
        viewcity();
        txtcityname.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;

    }
protected void  grd2_RowCommand(object sender, GridViewCommandEventArgs e)
{
    try
    {
        if (e.CommandName == "City_Id")
        {
            string ecode = e.CommandArgument.ToString();
            hdnid.Value = ecode.ToString();
            string str3 = "select * from City_master WHERE City_Id ='" + ecode + "' ";
            DataSet ds = new DataSet();
            ds = cn.select(str3);
            if (ds.Tables[0].Rows.Count > 0)
            {
                btncancel.Enabled = true;
                btnsave.Enabled = false;
                btnupdate.Enabled = true;
                btndel.Enabled = true;
                txtcityname.Text = ds.Tables[0].Rows[0]["City_Name"].ToString();
                drpstate.SelectedValue = ds.Tables[0].Rows[0]["State_Id"].ToString();




            }


        }
    }
    catch
    {
    }

}
}