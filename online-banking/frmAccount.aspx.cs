using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class frmAccount : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            viewcaccount();
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
        string str = "select count (*) from account_master where account_no="+txtaccountno.Text+"and account_type_id="+drpaccounttypeid.SelectedValue+"and cust_id="+drpcustid.SelectedValue+"and open_date='"+txtopendate.Text+"'and balance="+txtbalance.Text+"and status='"+rblstatus.SelectedValue+"'and branch_id="+drpbranchid.SelectedValue+"";
        ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into account_master (account_no,account_type_id,cust_id,open_date,balance,status,branch_id) values ("+txtaccountno.Text+","+drpaccounttypeid.SelectedValue+","+drpcustid.SelectedValue+",'"+txtopendate.Text+"',"+txtbalance.Text+",'"+rblstatus.SelectedValue+"',"+drpbranchid.SelectedValue+")";
            cn.modify(str);
            Response.Write("<script>alert('account Detali inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('account Detali Duplicate')</script>");
        }
        viewcaccount();

    }
    public void binddropdown()
    {
        gf.fillcombo("select * from customer", drpcustid, "f_name", "cust_id", "--select id--");
        gf.fillcombo("select * from branch_master", drpbranchid, "branch_name", "branch_id", "--select branch--");
        gf.fillcombo("select * from account_type_master", drpaccounttypeid, "account_type_name", "account_type_id", "--select account_type--");
        //gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select customer--");
      //  gf.fillcombo("select * from account_master", , "account_no", "account_no", "--select no--");
    }

    public void viewcaccount()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,account_type_id,cust_id,open_date,balance,status,branch_id from account_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdaccount.DataSource = ds.Tables[0];
                grdaccount.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {

        string str = "update account_master set account_type_id="+drpaccounttypeid.SelectedValue+",cust_id="+drpcustid.SelectedValue+",open_date='"+txtopendate.Text+"',balance="+txtbalance.Text+",status='"+rblstatus.SelectedValue+"',branch_id="+drpbranchid.SelectedValue+" where account_no='"+hdnaccount.Value+"'";
        cn.modify(str);
        Response.Write("<script>alert('account master Detali Updated')</script>");
        viewcaccount();
        txtopendate.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
   
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from account_master where account_no='" + hdnaccount.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('account master Detali Deleted..')</script>");
        viewcaccount();
        txtopendate.Text = "";

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
                string str3 = "select * from account_master WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    drpaccounttypeid.SelectedValue = ds.Tables[0].Rows[0]["Account_Type_Id"].ToString();
                    drpcustid.SelectedValue = ds.Tables[0].Rows[0]["Cust_Id"].ToString();
                    txtopendate.Text = ds.Tables[0].Rows[0]["Open_Date"].ToString();
                    txtbalance.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                    rblstatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                    drpbranchid.SelectedValue = ds.Tables[0].Rows[0]["Branch_Id"].ToString();



                }

            }
        }
        catch
        {
        }
    }
  
}