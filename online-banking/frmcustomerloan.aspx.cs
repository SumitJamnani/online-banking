using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmcustomerloan : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewcustomerloan();
            binddropdown();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from loan_master", drploan_id, "loan_id", "loan_id", "--select loan_master--");
        gf.fillcombo("select * from employee_master", drpemp_id, "emp_id", "emp_id", "--select employee Id--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from customer_loan where account_no=" + drpaccountno.SelectedValue + "and loan_id=" + drploan_id.SelectedValue + " and loanapply_date='" + txtloanapply_date.Text + "'and approval_date='" + txtapproval_date.Text + "'and loan_amount=" + txtloan_amount.Text + "and Durationinmonth='" + txtdurationinmonth.Text + "'and closing_date='" + txtclosing_date.Text + "'and Description='" + txtdescription.Text + "'and emp_id=" + drpemp_id.SelectedValue + "";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into customer_loan (account_no,loan_id,loanapply_date,approval_date,loan_amount,Durationinmonth,closing_date,Description,emp_id,status) values (" + drpaccountno.SelectedValue + "," + drploan_id.SelectedValue + ",'" + txtloanapply_date.Text + "','" + txtapproval_date.Text + "'," + txtloan_amount.Text + ",'" + txtdurationinmonth.Text + "','" + txtclosing_date.Text + "','" + txtdescription.Text + "'," + drpemp_id.SelectedValue + ",false)";
            cn.modify(str);
            Response.Write("<script>alert('customer_loan  Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('customer_loan  Detali duplicate')</script>");
        }
        viewcustomerloan();
    
    }
    public void viewcustomerloan()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,loan_id,loanapply_date,approval_date,loan_amount,Durationinmonth,closing_date,Description,emp_id from customer_loan";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdcustomerloan.DataSource = ds.Tables[0];
                grdcustomerloan.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update customer_loan set account_no=" + drpaccountno.SelectedValue + ", loanapply_date='" + txtloanapply_date.Text + "', approval_date='" + txtapproval_date.Text + "', loan_amount=" + txtloan_amount.Text + ", Durationinmonth='" + txtdurationinmonth.Text + "', closing_date='" + txtclosing_date.Text + "', Description='" + txtdescription.Text + "', emp_id=" +drpemp_id.SelectedValue + "where loan_id ='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('customer_loan Detali Updated')</script>");
        viewcustomerloan();
        drpaccountno.SelectedValue ="";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
   
    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "loan_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from customer_loan WHERE loan_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    drpaccountno.SelectedValue = ds.Tables[0].Rows[0]["account_no"].ToString();
                    txtloanapply_date.Text = ds.Tables[0].Rows[0]["loanapply_date"].ToString();
                    txtapproval_date.Text = ds.Tables[0].Rows[0]["approval_date"].ToString();
                    txtloan_amount.Text = ds.Tables[0].Rows[0]["loan_amount"].ToString();
                    txtdurationinmonth.Text = ds.Tables[0].Rows[0]["durationinmonth"].ToString();
                    txtclosing_date.Text = ds.Tables[0].Rows[0]["closing_date"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                    drpemp_id.SelectedValue = ds.Tables[0].Rows[0]["emp_id"].ToString();




                }

            }
        }
        catch
        {
        }
    }

    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from customer_loan where loan_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('customer loan Detali Deleted..')</script>");
        viewcustomerloan();
        drpaccountno.SelectedValue = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    
    }
}