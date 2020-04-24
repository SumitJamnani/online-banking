using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; 
using System.Data;

public partial class frmstate : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewstate();
            binddropdown();
        }

    }
    public void binddropdown()
    {
        gf.fillcombo("select * from country_master", drpcountry, "country_name", "country_id", "--select country--");
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from state_master where state_name='" + txtstatename.Text +"'and country_id="+ drpcountry.SelectedValue ;
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into state_master(state_name,country_id) values ('" + txtstatename.Text + "'," + drpcountry.SelectedValue + ")";
            cn.modify(str);
            Response.Write("<script>alert('inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('duplicate')</script>");
        }
        viewstate();
   }
    public void viewstate()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select state_id,state_name ,country_id  from state_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdstate.DataSource = ds.Tables[0];
                grdstate.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update state_master set  state_name='" + txtstatename.Text + "',country_id=" + drpcountry.SelectedValue + " where state_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('state Updated')</script>");
        viewstate();
        txtstatename.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from state_master where state_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('state Deleted..')</script>");
        viewstate();
        txtstatename.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void grdstate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "state_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from state_master WHERE state_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtstatename.Text = ds.Tables[0].Rows[0]["State_Name"].ToString();
                    drpcountry.SelectedValue = ds.Tables[0].Rows[0]["Country_Id"].ToString();
                }
            }
        }
        catch
        {
        }
    }
}