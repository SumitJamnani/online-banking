using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmbranch : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewbranch();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select * from branch_master where branch_name='" + txtbranchname.Text + "' and branch_phone_no=" + txtbranchphoneno.Text + " and branch_address1='" + txtaddress1.Text + "' and branch_address2='" + txtaddress2.Text + "' and branch_address3='" + txtaddress3.Text + "' and pincode=" + txtpincode.Text + "";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into branch_master(branch_name,branch_phone_no,branch_address1,branch_address2,branch_address3,pincode) values ('" + txtbranchname.Text + "'," + txtbranchphoneno.Text + ",'" + txtaddress1.Text + "','" + txtaddress2.Text + "','" + txtaddress3.Text + "'," + txtpincode.Text + ")";
            cn.modify(str);
            Response.Write("<script>alert('Branch Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('Branch Detali duplicate')</script>");
        }
        viewbranch();
    }
    public void viewbranch()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select branch_id,branch_name,branch_phone_no,branch_address1,branch_address2,branch_address3,pincode from branch_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdbranch.DataSource = ds.Tables[0];
                grdbranch.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update branch_master set branch_name='" + txtbranchname.Text + "',branch_phone_no=" + txtbranchphoneno.Text + ",branch_address1='" + txtaddress1.Text + "',branch_address2='" + txtaddress2.Text + "',branch_address3='" + txtaddress3.Text + "',pincode=" + txtpincode.Text + " where branch_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('Branch Detali Updated')</script>");
        viewbranch();
        txtbranchname.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;

    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Branch_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from branch_master WHERE branch_Id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtbranchname.Text = ds.Tables[0].Rows[0]["branch_Name"].ToString();
                    txtbranchphoneno.Text = ds.Tables[0].Rows[0]["branch_phone_no"].ToString();
                    txtaddress1.Text = ds.Tables[0].Rows[0]["branch_address1"].ToString();
                    txtaddress2.Text = ds.Tables[0].Rows[0]["branch_address2"].ToString();
                    txtaddress3.Text = ds.Tables[0].Rows[0]["branch_address3"].ToString();
                    txtpincode.Text = ds.Tables[0].Rows[0]["pincode"].ToString();

                    
                }

            }
        }
        catch
        {
        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from branch_master where branch_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('Branch Detali Deleted..')</script>");
        viewbranch();
        txtbranchname.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}