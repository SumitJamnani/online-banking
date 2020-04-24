using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmaccounttype : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewaccount_type();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select count(*) from account_type_master where account_type_name= '"+cblaccounttype.SelectedValue+"'";
        ds = cn.select(str);
        {
            str = "insert into account_type_master(account_type_name) values ('" + cblaccounttype.SelectedValue + "')";
            cn.modify(str);
            Response.Write("<script>alert('inserted')</script>");
        }
        
        viewaccount_type();
    }
    public void viewaccount_type()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_type_id  ,account_type_name from account_type_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdaccounttype.DataSource = ds.Tables[0];
                grdaccounttype.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_click(object sender, EventArgs e)
    {
        string str = "update account_type_master set  account_type_name='" + cblaccounttype.SelectedValue + "' where account_type_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('account Updated')</script>");
        viewaccount_type();
        cblaccounttype.SelectedValue = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }

    protected void btndel_click(object sender, EventArgs e)
    {
        string str = "delete from account_type_master where account_type_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('account Deleted..')</script>");
        viewaccount_type();
        cblaccounttype.SelectedValue = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }

    protected void grdaccounttype_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Account_Type_Id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from account_type_master WHERE account_type_Id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    cblaccounttype.SelectedValue = ds.Tables[0].Rows[0]["Account_Type_Name"].ToString();
                    
                }
            }
        }
        catch
        {
        }
    }
}