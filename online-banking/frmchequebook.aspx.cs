using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmchequebook : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewcheque();
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
        string str = "select *from chequebook_transaction where account_no=" + drpaccount.SelectedValue + " and issue_date='" + txtissuedate.Text + "' and start_number=" + txtstartnumber.Text + " and end_number=" + txtendnumber.Text + " and apply_date='" + txtapplydate.Text + "'and emp_id=" + drpempid.SelectedValue + "";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into chequebook_transaction (account_no,issue_date,start_number,end_number,apply_date,emp_id) values (" + drpaccount.SelectedValue + ",'"+txtissuedate.Text+"',"+txtstartnumber.Text+","+txtendnumber.Text+",'"+txtapplydate.Text+"',"+drpempid.SelectedValue+")";
            cn.modify(str);
            Response.Write("<script>alert('chequebook_transaction Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('chequebook_transaction Detali duplicate')</script>");
        }
        viewcheque();
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from employee_master", drpempid, "f_name", "emp_id", "--select employee Id--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccount, "name", "account_no", "--select employee Id--");
    }
    public void viewcheque()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,issue_date,start_number,end_number,apply_date,emp_id,status from chequebook_transaction";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdcheque.DataSource = ds.Tables[0];
                grdcheque.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update chequebook_transaction set issue_date='"+txtissuedate.Text+"',start_number="+txtstartnumber.Text+",end_number="+txtendnumber.Text+",apply_date='"+txtapplydate.Text+"',emp_id="+drpempid.SelectedValue+" where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('chequebook transaction detail is Updated')</script>");
        viewcheque();
        txtissuedate.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from chequebook_transaction where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('chequebook transaction  deatil is Deleted..')</script>");
        viewcheque();
        txtissuedate.Text = "";

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
                string str3 = "select * from chequebook_transaction WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtissuedate.Text = ds.Tables[0].Rows[0]["Issue_Date"].ToString();
                    txtstartnumber.Text = ds.Tables[0].Rows[0]["Start_Number"].ToString();
                    txtendnumber.Text = ds.Tables[0].Rows[0]["End_Number"].ToString();
                    txtapplydate.Text = ds.Tables[0].Rows[0]["Apply_Date"].ToString();
                    drpempid.SelectedValue = ds.Tables[0].Rows[0]["Emp_Id"].ToString();
                  //  rblstatus.SelectedValue= ds.Tables[0].Rows[0]["Emp_Id"].ToString();
                }
            }
        }
        catch
        {

        }
    }
}