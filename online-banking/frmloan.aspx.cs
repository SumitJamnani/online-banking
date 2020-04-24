using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmloan : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            viewloan_master();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select count(*) from loan_master where loan_type='" +txtloan_type.Text + "' and max_loan=" + txtmax_loan.Text + " and min_loan=" + txtmin_loan.Text + " and interest_rate=" + txtinterest_rate.Text + "";
        ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into loan_master (loan_type,max_loan,min_loan,interest_rate) values ('" + txtloan_type.Text + "'," + txtmax_loan.Text + "," + txtmin_loan.Text + "," + txtinterest_rate.Text + ")";
            cn.modify(str);
            Response.Write("<script>alert('Loan inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('Loan duplicate')</script>");
        }
        viewloan_master();
    

    }
    public void viewloan_master()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select loan_id,loan_type,max_loan, min_loan,interest_rate from loan_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdloan.DataSource = ds.Tables[0];
                grdloan.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update loan_master set loan_type='" + txtloan_type.Text + "',max_loan=" + txtmax_loan.Text + ",min_loan=" + txtmin_loan.Text + ",interest_rate=" + txtinterest_rate.Text + " where loan_id='" + hdnid.Value+ "'";
         cn.modify(str);
        Response.Write("<script>alert('loan  Updated')</script>");
        viewloan_master();
        txtloan_type.Text = "";
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
                string str3 = "select * from loan_master WHERE loan_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtloan_type.Text = ds.Tables[0].Rows[0]["Loan_Type"].ToString();
                    txtmax_loan.Text = ds.Tables[0].Rows[0]["Max_Loan"].ToString();
                    txtmin_loan.Text = ds.Tables[0].Rows[0]["Min_Loan"].ToString();
                    txtinterest_rate.Text = ds.Tables[0].Rows[0]["Interest_rate"].ToString();

                 }

            }
        }
        catch
        {
        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from loan_master where loan_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('Loan Deleted..')</script>");
        viewloan_master();
        txtloan_type.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}