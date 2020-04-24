using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class frmaccountnominee : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {
            viewaccountnominee();
             binddropdown();
             btncancel.Enabled = true;
             btnupdate.Enabled = false;
             btndel.Enabled = false;
              btnsave.Enabled = true;
        }

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from account_nominee where account_no=" +drpaccountno.SelectedValue + " and nominee_id=" + drpnomineeid.SelectedValue+ "and date='" + txtdate.Text + "'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into account_nominee(account_no,nominee_id,date) values (" + drpaccountno.SelectedValue + "," + drpnomineeid.SelectedValue+ ",'"+txtdate.Text+"')";
            cn.modify(str);
            Response.Write("<script>alert('account nominee Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('account nominee Detali duplicate')</script>");
        }
        viewaccountnominee();
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from nominee_master", drpnomineeid, "nominee_f_name", "nominee_id", "--select nominee--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
    }
  
    public void viewaccountnominee()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,nominee_id,date from account_nominee";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdaccountnominee.DataSource = ds.Tables[0];
                grdaccountnominee.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update account_nominee set nominee_id=" + drpnomineeid.SelectedValue + ",date='" + txtdate.Text + "',account_no='" + hdnaccount.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('account nominee Detali Updated')</script>");
        viewaccountnominee();
        txtdate.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from account_nominee where account_no='" + hdnaccount.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('account nominee Detali Deleted..')</script>");
        viewaccountnominee();
        txtdate.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "account_no")
            {
                string ecode = e.CommandArgument.ToString();
                hdnaccount.Value = ecode.ToString();
                string str3 = "select * from account_nominee WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    drpnomineeid.SelectedValue = ds.Tables[0].Rows[0]["Nominee_Id"].ToString();
                    txtdate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
                   

                }

            }
        }
        catch
        {
        }
    }
}