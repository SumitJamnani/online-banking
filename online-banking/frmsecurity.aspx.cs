using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmsecurity : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewsecurity();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from security_master where s_q_que='"+ txtsecurityquestion.Text +"'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into security_master(s_q_que) values ('" + txtsecurityquestion.Text+ "')";
            cn.modify(str);
            Response.Write("<script>alert('Security Question inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('Security Question duplicate')</script>");
        }
        viewsecurity();
    }
    public void viewsecurity()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select s_q_id ,S_q_que from Security_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdsecurity.DataSource = ds.Tables[0];
                grdsecurity.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update security_master set s_q_que='"+txtsecurityquestion.Text+"' where s_q_id='"+hdnid.Value+"'";
        cn.modify(str);
        Response.Write("<script>alert('security question Updated')</script>");
        viewsecurity();
        txtsecurityquestion.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "s_q_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from security_master WHERE s_q_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtsecurityquestion.Text = ds.Tables[0].Rows[0]["s_q_que"].ToString();
                }


            }
        }
        catch
        {
        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from security_master where s_q_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('security question is Deleted..')</script>");
        viewsecurity();
        txtsecurityquestion.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}