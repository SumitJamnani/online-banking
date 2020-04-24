using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmlog_master : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewlog_master();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select count (*) from log_master where email_id='"+txtemail_id.Text+"' and datetime='"+txtdatetime.Text+"' and ip_address='"+txtip_address.Text+"' and logout_time='"+txtlogout_time.Text+"' and login_time='"+txtlogin_time.Text+"'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into log_master(email_id,datetime,ip_address,logout_time,login_time) values ('" + txtemail_id.Text + "','" + txtdatetime.Text + "','" + txtip_address.Text + "','" + txtlogout_time.Text + "','" + txtlogin_time.Text + "')";
            cn.modify(str);
            Response.Write("<script>alert('inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('duplicate')</script>");
        }
        viewlog_master();

    }
    public void viewlog_master()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select email_id,datetime,ip_address,logout_time,login_time from log_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
               grdlog_master.DataSource = ds.Tables[0];
               grdlog_master.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update log_master set datetime='" + txtdatetime.Text + "',ip_address='" + txtip_address.Text + "',logout_time='" + txtlogout_time.Text + "', login_time='"+txtlogin_time.Text+"' where email_id='" + hdnemailid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('log_master  Updated')</script>");
        viewlog_master();
        txtdatetime.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from log_master where email_id='" + hdnemailid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('log master Deleted..')</script>");
        viewlog_master();
        txtdatetime.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "email_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnemailid.Value = ecode.ToString();
                string str3 = "select * from log_master WHERE email_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtdatetime.Text = ds.Tables[0].Rows[0]["datetime"].ToString();
                    txtip_address.Text = ds.Tables[0].Rows[0]["ip_address"].ToString();
                    txtlogout_time.Text = ds.Tables[0].Rows[0]["logout_time"].ToString();
                    txtlogin_time.Text = ds.Tables[0].Rows[0]["login_time"].ToString();




                }

            }
        }
        catch
        {
        }
    }
}