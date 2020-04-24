using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmemployee : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewemployee();
            binddropdown();
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
        string str = "select count (*) from employee_master where f_name='" + txtf_name.Text + "'and m_name='" + txtm_name.Text + "'and l_name='" + txtl_name.Text + "'and email_id='" + txtemail_id.Text + "'and address1='" + txtaddress1.Text + "'and address2='" + txtaddress2.Text + "'and address3='" + txtaddress3.Text + "'and pincode=" + txtpincode.Text + "and city_id='" + drpcity_id.SelectedValue + "'and gender='" + rblgender.SelectedValue + "'and birth_date='" + txtbirth_date.Text + "'and contact_no=" + txtcontact_no.Text + "and adhar_no="+txtadhar_no.Text+"and join_date='"+txtjoin_date.Text+"'and branch_id='"+drpbranch_id.SelectedValue+"'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into employee_master (f_name,m_name,l_name,email_id,address1,address2,address3,pincode,city_id,gender,birth_date,contact_no,adhar_no,join_date,branch_id) values ('" + txtf_name.Text + "','" + txtm_name.Text + "','" + txtl_name.Text + "','" + txtemail_id.Text + "','" + txtaddress1.Text + "','" + txtaddress2.Text + "','" + txtaddress3.Text + "'," + txtpincode.Text + ",'" + drpcity_id.SelectedValue + "','" + rblgender.SelectedValue + "','" + txtbirth_date.Text + "'," + txtcontact_no.Text + "," + txtadhar_no.Text + ",'" + txtjoin_date.Text + "','" + drpbranch_id.SelectedValue + "')";
            cn.modify(str);
            Response.Write("<script>alert('Employee Detali inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('Employee Detali duplicate')</script>");
        }
        viewemployee();

    }
    public void viewemployee()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select emp_id ,f_name ,m_name ,l_name ,email_id ,address1 ,address2 ,address3 ,pincode ,city_id ,gender ,birth_date ,contact_no ,adhar_no ,join_date ,branch_id  from employee_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdemployee.DataSource = ds.Tables[0];
                grdemployee.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "emp_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from employee_master WHERE emp_id ='" + ecode + "' ";
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
                    rblgender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                    txtbirth_date.Text = ds.Tables[0].Rows[0]["Birth_Date"].ToString();
                    txtcontact_no.Text = ds.Tables[0].Rows[0]["contact_no"].ToString();
                    txtadhar_no.Text = ds.Tables[0].Rows[0]["Adhar_No"].ToString();
                    txtjoin_date.Text = ds.Tables[0].Rows[0]["join_date"].ToString();
                    drpbranch_id.SelectedValue = ds.Tables[0].Rows[0]["Branch_Id"].ToString();    
                }
            }
        }
        catch
        {
        }

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update employee_master set f_name='" + txtf_name.Text + "',m_name='" + txtm_name.Text + "',l_name='" + txtl_name.Text + "',email_id='" + txtemail_id.Text + "',address1='" + txtaddress1.Text + "',address2='" + txtaddress2.Text + "',address3='" + txtaddress3.Text + "',pincode=" + txtpincode.Text + ",city_id=" + drpcity_id.SelectedValue + ",gender='" + rblgender.SelectedValue + "',birth_date='" + txtbirth_date.Text + "',contact_no=" + txtcontact_no.Text + ",adhar_no=" + txtadhar_no.Text + ",join_date='" + txtjoin_date.Text + "',branch_id=" + drpbranch_id.SelectedValue + " where emp_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('employee Updated')</script>");
        viewemployee();
        txtf_name.Text = "";
        
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }

    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from employee_master where emp_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('employee deatil is Deleted..')</script>");
        viewemployee();
        txtf_name.Text = "";
        

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}