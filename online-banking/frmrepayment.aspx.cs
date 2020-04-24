using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmrepayment : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewloanrepayment();
            binddropdown();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from loan_master", drploanid, "loan_id", "loan_id", "--select loan--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select count(*) from loan_repayment where account_no=" + drpaccountno.SelectedValue+ " and loan_id=" + drploanid.SelectedValue + " and date='" + txtdate.Text + "' and amount=" + txtamount.Text + " and payby='" + txtpayby.Text + "' and cheque_no=" + txtchequeno.Text + " and card_no=" + txtcardno.Text + " and description='" + txtdescription.Text + "' ";
        ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into loan_repayment (account_no,loan_id,date,amount,payby,cheque_no,card_no,description) values (" + drpaccountno.SelectedValue+ "," + drploanid.SelectedValue + ",'" + txtdate.Text + "'," + txtamount.Text + ",'" + txtpayby.Text + "'," + txtchequeno.Text + "," + txtcardno.Text + ",'" + txtdescription.Text + "')";
            cn.modify(str);
            Response.Write("<script>alert('Loanrepayment detail inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('Loanrepayment duplicate')</script>");
        }
        viewloanrepayment();
    }
    public void viewloanrepayment()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,loan_id,date,amount,payby,cheque_no,card_no,description from loan_repayment";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdrepayment.DataSource = ds.Tables[0];
                grdrepayment.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update loan_repayment set loan_id=" + drploanid.SelectedValue + ",date='" + txtdate.Text + "',amount=" + txtamount.Text + ",payby='" + txtpayby.Text + "',cheque_no=" + txtchequeno.Text + ",card_no=" + txtcardno.Text + ",description='" + txtdescription.Text + "' where account_no='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('loan  Updated')</script>");
        viewloanrepayment();
        drpaccountno.SelectedValue = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from loan_repayment where account_no='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('Loanrepayment Deleted..')</script>");
        viewloanrepayment();
        drpaccountno.SelectedValue = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }

    protected void grdrepayment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "account_no")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from loan_repayment WHERE account_no='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    drploanid.SelectedValue = ds.Tables[0].Rows[0]["Loan_Id"].ToString();
                    txtdate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
                    txtamount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                    txtpayby.Text = ds.Tables[0].Rows[0]["Payby"].ToString();
                    txtchequeno.Text = ds.Tables[0].Rows[0]["Cheque_No"].ToString();
                    txtcardno.Text = ds.Tables[0].Rows[0]["Card_No"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                }

            }
        }
        catch
        {
        }
    }
}