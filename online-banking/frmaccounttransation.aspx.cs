using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmaccounttransation : System.Web.UI.Page
{
    db_conn cn = new db_conn(); 
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewaccount();
            binddropdown();
            btncancel.Enabled = true;
            btnupdate.Enabled = false;
            btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select *from account_transaction where account_no=" + drpaccountno.SelectedValue + "and amount=" + txtamount.Text + " and transaction_datetime='" + txttransaction_datetime.Text + "' and description='" + txtdescription.Text + "' and charges_id='" + drpcharges_id.SelectedValue + "' and transaction_type='" + rbltransaction_type.SelectedValue + "'";
        ds = cn.select(str);
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "insert into account_transaction (account_no,amount,transaction_datetime,description,charges_id,transaction_type) values (" + drpaccountno.SelectedValue + "," + txtamount.Text + ",'" + txttransaction_datetime.Text + "' ,'" + txtdescription.Text + "','" + drpcharges_id.SelectedValue + "','" + rbltransaction_type.SelectedValue + "')";
            cn.modify(str);
            Response.Write("<script>alert('account_transaction Detali inserted')</script>");
        }
        else
        {
            Response.Write("<script>alert('account_transaction Detali duplicate')</script>");
        }
        viewaccount();
    }
    public void binddropdown()
    {
        gf.fillcombo("select * from charges", drpcharges_id, "charge_type", "charges_id", "--select charges Id--");
        gf.fillcombo("select  f_name+ ' '+m_name+' '+l_name 'name' ,account_no from account_master,customer where customer.cust_id=account_master.cust_id", drpaccountno, "name", "account_no", "--select employee Id--");
    }
    public void viewaccount()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,amount,transaction_datetime,description,charges_id,transaction_type from account_transaction";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdaccount.DataSource = ds.Tables[0];
                grdaccount.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
   
    protected void btndel_Click(object sender, EventArgs e)
    {

        string str = "delete from account_transaction where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert(' account transaction  deatil is Deleted..')</script>");
        viewaccount();
        txtamount.Text = "";

        btncancel.Enabled = true;
        btnupdate.Enabled = false;
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
                hdnaccountno.Value = ecode.ToString();
                string str3 = "select * from account_transaction WHERE account_no ='" + ecode + "' ";
                DataSet ds = new DataSet();
                ds = cn.select(str3);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btncancel.Enabled = true;
                    btnsave.Enabled = false;
                    btnupdate.Enabled = true;
                    btndel.Enabled = true;
                    txtamount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                    txttransaction_datetime.Text = ds.Tables[0].Rows[0]["Transaction_Datetime"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    drpcharges_id.SelectedValue = ds.Tables[0].Rows[0]["Charges_Id"].ToString();
                    rbltransaction_type.SelectedValue = ds.Tables[0].Rows[0]["Transaction_Type"].ToString();
                }
            }
        }
        catch
        {

        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {

        string str = "update account_transaction set amount=" + txtamount.Text + " , transaction_datetime='" + txttransaction_datetime.Text + "' , description='" + txtdescription.Text + "' , charges_id='" + drpcharges_id.SelectedValue + "' , transaction_type='" + rbltransaction_type.SelectedValue + "' where account_no='" + hdnaccountno.Value + "'";
        cn.modify(str);
        Response.Write("<script>alert('accopunt transaction detail is Updated')</script>");
        viewaccount();
        txtamount.Text = "";
        btncancel.Enabled = true;
        btnupdate.Enabled = false;
        btndel.Enabled = false;
        btnsave.Enabled = true;
    }
}