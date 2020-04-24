using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmlogin : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewlogin();
            binddropdown();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnSave.Enabled = true;
    
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from login where email_id='" + txtemail_id.Text + "' and password='" + txtpassword.Text + "' and sec_q_id=" +drpaecqid.SelectedValue + " and sec_q_ans='" + txtsec_q_ans.Text + "' and user_type='" + rbluser_type.SelectedValue + "'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into login (email_id,password,sec_q_id,sec_q_ans,user_type) values ('" + txtemail_id.Text + "','" + txtpassword.Text + "',"+drpaecqid.SelectedValue+",'"+txtsec_q_ans.Text+"','"+rbluser_type.SelectedValue+"')";
            cn.modify(str);
            Response.Write("<script>alert('Welcome :)')</script>");

        }
       
        viewlogin();

    }
    public void binddropdown()
    {
        gf.fillcombo("select * from security_master", drpaecqid, "s_q_que", "s_q_id", "--select question--");
        
    }

    public void viewlogin()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select email_id ,password ,sec_q_id , sec_q_ans  ,user_type from login";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdlogin.DataSource = ds.Tables[0];
                grdlogin.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update login set password='" + txtpassword.Text + "',sec_q_id=" + drpaecqid.SelectedValue + ",sec_q_ans='" + txtsec_q_ans.Text + "', user_type='" + rbluser_type.SelectedValue + "' where email_id='" + hdnemailid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('login detail  Updated')</script>");
        viewlogin();
        txtpassword.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnSave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from login where email_id='" + hdnemailid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('login master Deleted..')</script>");
        viewlogin();
        txtpassword.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnSave.Enabled = true;
    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        try
        {
            if (e.CommandName == "email_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnemailid.Value = ecode.ToString();
                string str3 = "select * from login WHERE email_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnSave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtpassword.Text = ds.Tables[0].Rows[0]["password"].ToString();
                    drpaecqid.SelectedValue = ds.Tables[0].Rows[0]["sec_q_id"].ToString();
                    txtsec_q_ans.Text = ds.Tables[0].Rows[0]["sec_q_ans"].ToString();
                    rbluser_type.SelectedValue = ds.Tables[0].Rows[0]["user_type"].ToString();




                }

            }
        }
        catch
        {
        }
    }
  }
