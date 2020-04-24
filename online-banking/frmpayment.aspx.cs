using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class frmstoppayment : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewpayment();
            binddropdown();
            btncancel.Enabled = true;
            // btnupdate.Enabled = false;
            // btndel.Enabled = false;
            btnsave.Enabled = true;
        }

    }
    public void binddropdown()
    {
        gf.fillcombo("select * from employee_master", drpempid, "f_name", "emp_id", "--select employee Id--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from stop_payment where account_no="+drpaccountno.SelectedValue+" and cheque_no="+txtchequeno.Text+" and stop_date='"+txtstopdate.Text+"' and description='"+txtdescription.Text+"' and emp_id=" +drpempid.SelectedValue+"and request_date='"+txtrequestdate.Text+"'and amount="+txtamount.Text+" and status="+rblstatus.SelectedValue+" and cheque_issue_date='"+txtchequeissuedate.Text+"'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into stop_payment (account_no,cheque_no,stop_date,description,emp_id,request_date,amount,status,cheque_issue_date) values ("+drpaccountno.SelectedValue+","+txtchequeno.Text+",'"+txtstopdate.Text+"','"+txtdescription.Text+"',"+drpempid.SelectedValue+",'"+txtrequestdate.Text+"',"+txtamount.Text+","+rblstatus.SelectedValue+",'"+txtchequeissuedate.Text+"')";
            cn.modify(str);
            Response.Write("<script>alert('stop payment Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('stop payment Detali duplicate')</script>");
        }
    viewpayment();
    }
    public void viewpayment()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,cheque_no,stop_date,description,emp_id,request_date,amount,status,cheque_issue_date from stop_payment"; 
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdpayment.DataSource = ds.Tables[0];
                grdpayment.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update stop_payment set cheque_no=" + txtchequeno.Text + ",stop_date='" + txtstopdate.Text + "',description='" + txtdescription.Text + "',emp_id="+drpempid.SelectedValue+",request_date='"+txtrequestdate.Text+"',amount="+txtamount.Text+",status=" + rblstatus.SelectedValue + ",cheque_issue_Date='" +txtchequeissuedate.Text + "' where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('passbook transaction detail is Updated')</script>");
        viewpayment();
        txtchequeno.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from stop_payment where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('stop payment  deatil is Deleted..')</script>");
        viewpayment();
        txtchequeno.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Account_no")
            {
                string ecode = e.CommandArgument.ToString();
                hdnaccountno.Value = ecode.ToString();
                string str3 = "select * from stop_payment WHERE Account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtchequeno.Text = ds.Tables[0].Rows[0]["Cheque_No"].ToString();
                    txtstopdate.Text = ds.Tables[0].Rows[0]["Stop_Date"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    drpempid.SelectedValue = ds.Tables[0].Rows[0]["Emp_id"].ToString();
                    txtrequestdate .Text = ds.Tables[0].Rows[0]["Request_Date"].ToString();
                    txtamount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                    rblstatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                    txtchequeissuedate.Text = ds.Tables[0].Rows[0]["Cheque_Issue_Date"].ToString();
                    
                }
            }
        }
        catch
        {

        }
    }
}
