using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmcharges : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            viewcharges();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select count (*) from charges where charge_type='" + txtchargestype.Text + "' and charge_amount=" + txtchargesamount.Text + " and description ='" + txtdescription.Text + "'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString()== "0")
        {
            str = "insert into charges (charge_type,charge_amount,description) values ('" + txtchargestype.Text + "'," + txtchargesamount.Text + ",'" + txtdescription.Text + "')";
            cn.modify(str);
            Response.Write("<script>alert('Charges inserted')</script>");

        }
        else
        {
            Response.Write("<script>alert('Charges duplicate')</script>");
        }
        viewcharges();
    
    }
    public void viewcharges()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select charges_id ,charge_type,charge_amount,description from charges";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdcharges.DataSource = ds.Tables[0];
                grdcharges.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string str = "update charges set  charge_type='" + txtchargestype.Text + "',charge_amount="+txtchargesamount.Text+",description='"+txtdescription.Text+"'where charges_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('Charges  Updated')</script>");
        viewcharges();
        txtchargestype.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;

    }
    protected void grd2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "charges_id")
            {
                string ecode = e.CommandArgument.ToString();
                hdnid.Value = ecode.ToString();
                string str3 = "select * from charges WHERE charges_id ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtchargestype.Text = ds.Tables[0].Rows[0]["Charge_Type"].ToString();
                    txtchargesamount.Text = ds.Tables[0].Rows[0]["Charge_Amount"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                   


                }

            }
        }
        catch
        {
        }
    }

    protected void btndel_Click(object sender, EventArgs e)
    {
        string str = "delete from charges where charges_id='" + hdnid.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('charges Deleted..')</script>");
        viewcharges();
        txtchargestype.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}