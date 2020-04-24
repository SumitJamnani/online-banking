using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmpassbook : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewpassbook();
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
        string str = "select *from passbook_transaction where account_no=" + drpaccountno.SelectedValue + "and date='"+txtdate.Text+"' and issue_date='" + txtissuedate.Text + "' and apply_date='" + txtapplydate.Text + "' and emp_id=" + drpempid.SelectedValue + "";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into passbook_transaction (account_no,date,issue_date,apply_date,,emp_id) values (" + drpaccountno.SelectedValue + ",'"+txtdate.Text+"','" + txtissuedate.Text + "','" + txtapplydate.Text + "', false," + drpempid.SelectedValue + ")";
            cn.modify(str);
            Response.Write("<script>alert('passbook_transaction Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('passbook_transaction Detali duplicate')</script>");
        }
        viewpassbook();
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from employee_master", drpempid, "f_name", "emp_id", "--select employee Id--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
  
    }
    public void viewpassbook()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,date,issue_date,apply_date,emp_id from passbook_transaction";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdpassbook.DataSource = ds.Tables[0];
                grdpassbook.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {

        string str = "update passbook_transaction set date='"+txtdate.Text+"',issue_date='" + txtissuedate.Text + "',apply_date='" + txtapplydate.Text + "',emp_id=" + drpempid.SelectedValue + " where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('passbook transaction detail is Updated')</script>");
        viewpassbook();
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
                hdnaccountno.Value = ecode.ToString();
                string str3 = "select * from passbook_transaction WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtdate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
                    txtissuedate.Text = ds.Tables[0].Rows[0]["Issue_Date"].ToString();
                    txtapplydate.Text = ds.Tables[0].Rows[0]["Apply_Date"].ToString();
                    drpempid.SelectedValue = ds.Tables[0].Rows[0]["Emp_Id"].ToString();
                }
            }
        }
        catch
        {

        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from passbook_transaction where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('passbook transaction  deatil is Deleted..')</script>");
        viewpassbook();
        txtdate.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}