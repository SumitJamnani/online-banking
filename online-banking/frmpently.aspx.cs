using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class frmpently : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewpenalty();
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
        string str = "select count (*) from loan_penalty where account_no="+drpaccountno.SelectedValue+" and loan_id="+drploanid.SelectedValue+" and amount="+txtamount.Text+" and description='"+txtdescription.Text+"' and date='"+txtdate.Text+"'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into loan_penalty (account_no,loan_id,amount,description,date) values ("+drpaccountno.SelectedValue+","+drploanid.SelectedValue+","+txtamount.Text+",'"+txtdescription.Text+"','"+txtdate.Text+"')";
            cn.modify(str);
            Response.Write("<script>alert('loan_penalty Detali inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('loan_penalty Detali Duplicate')</script>");
        }
        viewpenalty();
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from loan_master", drploanid, "loan_type", "loan_id", "--select loan--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
  
    }
    public void viewpenalty()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,loan_id,amount,description,date from loan_penalty";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdpently.DataSource = ds.Tables[0];
                grdpently.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update loan_penalty set loan_id="+drploanid.SelectedValue+",amount="+drpaccountno.SelectedValue+",description='"+txtdescription.Text+"',date='"+txtdate.Text+"',account_no='"+hdnaccountno.Value+"'";
        cn.modify(str);
        Response.Write("<script>alert('loan penalty Updated')</script>");
        viewpenalty();
        txtamount.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }

    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from loan_penalty where account_no='"+hdnaccountno.Value+"'";
        cn.modify(str);
        Response.Write("<script>alert('loan penalty deatil is Deleted..')</script>");
        viewpenalty();
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
                string str3 = "select * from loan_penalty WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    drploanid.SelectedValue = ds.Tables[0].Rows[0]["loan_id"].ToString();
                    txtamount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                    txtdate.Text = ds.Tables[0].Rows[0]["date"].ToString();
                   
                }

            }
        }
        catch
        {
        }
    }
}