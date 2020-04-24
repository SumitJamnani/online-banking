using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmpayback_transaction : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewpaybacktransaction();
            binddropdown();
             btncancel.Enabled = true;
             btnupdate.Enabled = false;
             btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from payback_master", drppayback_id, "payback_id", "payback_id", "--select payback--");
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from payback_transaction where payback_id="+drppayback_id.SelectedValue+"and account_no=" + txtaccountno.Text + " and datetime='" + txtdatetime.Text + "'and payback_amount="+txtpaybackamount.Text+"";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into payback_transaction(payback_id,account_no,datetime,payback_amount) values (" + drppayback_id.SelectedValue + "," + txtaccountno.Text + ",'" + txtdatetime.Text + "'," + txtpaybackamount.Text + ")";
            cn.modify(str);
            Response.Write("<script>alert('payback transaction Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('payback transaction Detali duplicate')</script>");
        }
        viewpaybacktransaction();
    }
   
    public void viewpaybacktransaction()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select payback_id,account_no,datetime,payback_amount from payback_transaction";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdtransaction.DataSource = ds.Tables[0];
                grdtransaction.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update payback_transaction set payback_id=" + drppayback_id.SelectedValue + ",  datetime='" + txtdatetime.Text + "', payback_amount=" + txtpaybackamount.Text + "where account_no ='" + hdnaccount.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('payback_transaction Detali Updated')</script>");
        viewpaybacktransaction();
        txtaccountno.Text = "";
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
                string str3 = "select * from payback_transaction WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    drppayback_id.SelectedValue = ds.Tables[0].Rows[0]["Payback_Id"].ToString();
                    txtdatetime.Text = ds.Tables[0].Rows[0]["Datetime"].ToString();
                    txtpaybackamount.Text = ds.Tables[0].Rows[0]["Payback_Amount"].ToString();



                }

            }
        }
        catch
        {
        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from payback_transaction where account_no='" + hdnaccount.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('payback_transaction Detali Deleted..')</script>");
        viewpaybacktransaction();
        txtaccountno.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    
    }
}