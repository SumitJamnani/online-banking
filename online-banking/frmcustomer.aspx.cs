using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmcustomer : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewcustomer();
            binddropdown();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }

    }
    public void binddropdown()
    {
        gf.fillcombo("select * from city_master", drpcity_id, "city_name", "city_id", "--select city--");
        gf.fillcombo("select * from branch_master", drpbranch_id, "branch_name", "branch_id", "--select branch--");
    }
  
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select count (*) from customer where f_name='"+txtf_name.Text+"'and m_name='"+txtm_name.Text+"'and l_name='"+txtl_name.Text+"'and email_id='"+txtemail_id.Text+"'and address1='"+txtaddress1.Text+"'and address2='"+txtaddress2.Text+"'and address3='"+txtaddress3.Text+"'and pincode="+txtpincode.Text+"and city_id="+drpcity_id.SelectedValue+" and adhar_no="+txtadhar_no.Text+"and branch_id="+drpbranch_id.SelectedValue+" and gender='"+rblgender.SelectedValue+"'and birth_date='"+txtbirth_date.Text+"'and contact_no="+txtcontact_no.Text+"";
         ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into customer (f_name,m_name,l_name,email_id,address1,address2,address3,pincode,city_id,adhar_no,branch_id,gender,birth_date,contact_no) values ('" + txtf_name.Text + "','" + txtm_name.Text + "','" + txtl_name.Text + "','" + txtemail_id.Text + "','" + txtaddress1.Text + "','" + txtaddress2.Text + "','" + txtaddress3.Text + "'," + txtpincode.Text + "," + drpcity_id.SelectedValue + "," + txtadhar_no.Text + "," + drpbranch_id.SelectedValue + ",'" + rblgender.SelectedValue + "','" + txtbirth_date.Text + "'," + txtcontact_no.Text + ")";
            cn.modify(str);
            Response.Write("<script>alert('Customer Detali inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('Customer Detali Duplicate')</script>");
        }
        viewcustomer();

    }
    public void viewcustomer()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select cust_id,f_name,m_name ,l_name,email_id ,address1 ,address2 ,address3 ,pincode ,city_id,adhar_no,branch_id ,gender,birth_date,contact_no from customer"; 
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdcustomer.DataSource = ds.Tables[0];
                grdcustomer.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update customer set f_name='" + txtf_name.Text + "',m_name='" + txtm_name.Text + "',l_name='" +txtl_name.Text + "',email_id='" +txtemail_id.Text + "',address1='" + txtaddress1.Text + "',address2='" + txtaddress2.Text + "',address3='"+txtaddress3.Text+"',pincode="+txtpincode.Text+",city_id="+drpcity_id.SelectedValue+",adhar_no="+txtadhar_no.Text+",branch_id="+drpbranch_id.SelectedValue+",gender='"+rblgender.SelectedValue+"',birth_date='"+txtbirth_date.Text+"',contact_no="+txtcontact_no.Text+" where cust_id='" +hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('customer Updated')</script>");
        viewcustomer();
        txtf_name.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;

    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cust_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from customer WHERE cust_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtf_name.Text = ds.Tables[0].Rows[0]["F_Name"].ToString();
                    txtm_name.Text = ds.Tables[0].Rows[0]["M_Name"].ToString();
                    txtl_name.Text = ds.Tables[0].Rows[0]["L_Name"].ToString();
                    txtemail_id.Text = ds.Tables[0].Rows[0]["Email_Id"].ToString();
                    txtaddress1.Text = ds.Tables[0].Rows[0]["Address1"].ToString();
                    txtaddress2.Text = ds.Tables[0].Rows[0]["Address2"].ToString();
                    txtaddress3.Text = ds.Tables[0].Rows[0]["Address3"].ToString();
                    txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    drpcity_id.SelectedValue = ds.Tables[0].Rows[0]["City_Id"].ToString();
                    txtadhar_no.Text = ds.Tables[0].Rows[0]["Adhar_No"].ToString();
                    drpbranch_id.SelectedValue = ds.Tables[0].Rows[0]["Branch_Id"].ToString();
                    rblgender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                    txtbirth_date.Text = ds.Tables[0].Rows[0]["Birth_Date"].ToString();
                    txtcontact_no.Text = ds.Tables[0].Rows[0]["contact_no"].ToString();



                }


            }
        }
        catch
        {
        }

    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from customer where cust_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('customer deatil is Deleted..')</script>");
        viewcustomer();
        txtf_name.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}