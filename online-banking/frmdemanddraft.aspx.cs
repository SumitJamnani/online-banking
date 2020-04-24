using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmdemanddraft : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();

    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select *from demanddraft_transaction where account_no=" +drpaccountno.SelectedValue + " and amount=" + txtamount.Text + " and apply_date='" + txtapply_date.Text + "' and approve_date='" + txtapprove_date.Text + "' and emp_id=" + drpemp_id.SelectedValue + "status='"+rblstatus.SelectedValue+"'";
        ds = cn.select(str);
        
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into demanddraft_transaction (account_no,amount,apply_date,approve_date,emp_id) values (" + drpaccountno.SelectedValue + "," + txtamount.Text + ",'" + txtapply_date.Text + "','" + txtapprove_date.Text + "'," + drpemp_id.SelectedValue + ",'"+rblstatus.SelectedValue+"')";
            cn.modify(str);
            Response.Write("<script>alert('demand_draft_transaction Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('demanddraft_transaction Detali duplicate')</script>");
        }
        viewdemanddraft();
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from employee_master", drpemp_id, "f_name", "emp_id", "--select employee Id--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
    }

    public void viewdemanddraft()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,amount,apply_date,approve_date,emp_id,status from demanddraft_transaction";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grddemanddraft.DataSource = ds.Tables[0];
                grddemanddraft.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            viewdemanddraft();
            binddropdown();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update demanddraft_transaction set amount=" + txtamount.Text + ",apply_date='" + txtapply_date.Text + "',approve_date='" + txtapprove_date.Text + "',emp_id=" + drpemp_id.SelectedValue + ", where  account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('demanddraf transaction detail is Updated')</script>");
        viewdemanddraft();
        txtamount.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;

    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from demanddraft_transaction where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('demanddraf transaction  deatil is Deleted..')</script>");
        viewdemanddraft();
        txtamount.Text = "";

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
                string str3 = "select * from demanddraft_transaction WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtamount.Text = ds.Tables[0].Rows[0]["Account_no"].ToString();
                    txtapply_date.Text = ds.Tables[0].Rows[0]["Apply_Date"].ToString();
                    txtapprove_date.Text = ds.Tables[0].Rows[0]["Approve_Date"].ToString();
                    drpemp_id.SelectedValue = ds.Tables[0].Rows[0]["Emp_Id"].ToString();
                    rblstatus.SelectedValue = ds.Tables[0].Rows[0]["status"].ToString();
                }
            }
        }
        catch
        {

        }
    }
  
}
           