using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmfeedback : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewfeedback();
            binddropdown();
            btnCancle.Enabled = true;
            btnUpdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from feedback_master where  account_no=" + drpaccountno.SelectedValue + " and datetime='" + txtdatetime.Text+ "' and feedback='"+txtfeedback.Text+"'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into feedback_master(account_no,datetime,feedback) values (" + drpaccountno.SelectedValue + ",'" + txtdatetime.Text + "','"+txtfeedback.Text+"')";
            cn.modify(str);
            Response.Write("<script>alert('Feedback inserted..')</script>");
        }
        
        viewfeedback();
    }
    public void binddropdown()
    {
        
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
    }
    public void viewfeedback()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,datetime,feedback from feedback_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdfeedback.DataSource = ds.Tables[0];
                grdfeedback.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string str = "update feedback_master set datetime='" + txtdatetime.Text + "',feedback='" + txtfeedback.Text + "' where account_no='" + hdnaccount.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('feedback detail is  Updated')</script>");
        viewfeedback();
        txtdatetime.Text = "";
        btnCancle.Enabled = true;
        btnUpdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from feedback_master where account_no='" + hdnaccount.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('feedback is Deleted..')</script>");
        viewfeedback();
        txtdatetime.Text = "";

        btnCancle.Enabled = true;
        btnUpdate.Enabled = false;
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
                string str3 = "select * from feedback_master WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnCancle.Enabled = true;
                    btnsave.Enabled = false;
                    btnUpdate.Enabled = true;
                    btndel.Enabled = true;
                    txtdatetime.Text = ds.Tables[0].Rows[0]["datetime"].ToString();
                    txtfeedback.Text = ds.Tables[0].Rows[0]["feedback"].ToString();
                   

                }

            }
        }
        catch
        {
        }
    }
}