using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class frmnominee : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewnominee();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select count (*) from nominee_master where nominee_f_name='"+ txtfname.Text+"'and nominee_m_name='"+txtmname.Text+"'and nominee_l_name='"+txtlname.Text+"'and account_no="+txtaccountno.Text+" and address1='"+txtaddress1.Text+"' and address2='" + txtaddress2.Text + "' and address3='"+txtaddress3.Text+"'and relationshipwith='"+txtrelationshipwith.Text+"'and nominee_dateofbirth='"+txtdateofbirth.Text+"'";
         ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into nominee_master (nominee_f_name,nominee_m_name,nominee_l_name,account_no,address1,address2,address3,relationshipwith,nominee_dateofbirth) values ('"+txtfname.Text+"','"+txtmname.Text+"','"+txtlname.Text+"',"+txtaccountno.Text+",'"+txtaddress1.Text+"','"+txtaddress2.Text+"','"+txtaddress3.Text+"','"+txtrelationshipwith.Text+"','"+txtdateofbirth.Text+"')";
            cn.modify(str);
            Response.Write("<script>alert('nominee Detali inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('nominee Detali Duplicate')</script>");
        }
        viewnominee();

    }
    public void viewnominee()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select nominee_id,nominee_f_name,nominee_m_name ,nominee_l_name,account_no ,address1 ,address2 ,address3 ,relationshipwith,nominee_dateofbirth from nominee_master";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdnominee.DataSource = ds.Tables[0];
                grdnominee.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update nominee_master set nominee_f_name='" + txtfname.Text + "',nominee_m_name='" + txtmname.Text + "',nominee_l_name='" + txtlname.Text + "',account_no='" + txtaccountno.Text + "',address1='" + txtaddress1.Text + "',address2='" + txtaddress2.Text + "',address3='" + txtaddress3.Text + "',relationshipwith='"+txtrelationshipwith.Text+"',nominee_dateofbirth='"+txtdateofbirth.Text+"' where nominee_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('nominee Updated')</script>");
        viewnominee();
        txtfname.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from nominee_master where nominee_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('customer deatil is Deleted..')</script>");
        viewnominee();
        txtfname.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "nominee_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from nominee_master WHERE nominee_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtfname.Text = ds.Tables[0].Rows[0]["Nominee_f_Name"].ToString();
                    txtmname.Text = ds.Tables[0].Rows[0]["Nominee_m_Name"].ToString();
                    txtlname.Text = ds.Tables[0].Rows[0]["Nominee_L_Name"].ToString();
                    txtaccountno.Text = ds.Tables[0].Rows[0]["Account_No"].ToString();
                    txtaddress1.Text = ds.Tables[0].Rows[0]["Address1"].ToString();
                    txtaddress2.Text = ds.Tables[0].Rows[0]["Address2"].ToString();
                    txtaddress3.Text = ds.Tables[0].Rows[0]["Address3"].ToString();
                    txtrelationshipwith.Text = ds.Tables[0].Rows[0]["Relationshipwith"].ToString();
                     txtdateofbirth.Text = ds.Tables[0].Rows[0]["Nominee_Dateofbirth"].ToString();
                    
                    }


            }
        }
        catch
        {
        }
    }
}