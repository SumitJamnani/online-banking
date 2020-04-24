using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmpayback : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewpayback();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from payback_master where vouchar_name='" + txtvoucharname.Text + "' and payback_detail='" + txtpaybackdetail.Text + "' and payback_amount="+txtpaybackamount.Text+"";
        ds = cn.select(str);
        {
            str = "insert into payback_master(vouchar_name,payback_detail,payback_amount) values ('" + txtvoucharname.Text + "','" + txtpaybackdetail.Text + "',"+txtpaybackamount.Text+")";
            cn.modify(str);
            Response.Write("<script>alert('Payback inserted')</script>");
        }
       
        viewpayback();
    }
    public void viewpayback()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select payback_id,vouchar_name,payback_detail,payback_amount from payback_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdpayback.DataSource = ds.Tables[0];
                grdpayback.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update payback_master set vouchar_name='" + txtvoucharname.Text + "',payback_detail='" + txtpaybackdetail.Text + "',payback_amount=" + txtpaybackamount.Text + "where payback_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('payaback  Updated')</script>");
        viewpayback();
        txtvoucharname.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "payback_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from payback_master WHERE payback_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtvoucharname.Text = ds.Tables[0].Rows[0]["Vouchar_Name"].ToString();
                    txtpaybackdetail.Text = ds.Tables[0].Rows[0]["Payback_Detail"].ToString();
                    txtpaybackamount.Text = ds.Tables[0].Rows[0]["Payback_Amount"].ToString();



                }

            }
        }
        catch
        {
        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from payback_master where payback_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('payback Deleted..')</script>");
        viewpayback();
        txtvoucharname.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}