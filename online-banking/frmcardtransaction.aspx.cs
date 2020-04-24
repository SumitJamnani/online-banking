using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmcardtransaction : System.Web.UI.Page
{
    db_conn cn = new db_conn();
    General_Function gf = new General_Function();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            viewcardtransaction();
            binddropdown();
            btncancel.Enabled = true;
           // btnupdate.Enabled = false;
            //btndel.Enabled = false;
            btnsave.Enabled = true;
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select count (*) from card_transaction where account_no=" + txtaccountno.Text + "and card_type='" + rblcardtype.SelectedValue + "'and card_no=" + txtcardno.Text + "and apply_date='" + txtapplydate.Text + "'and issue_date='" + txtissuedate.Text + "'and status=" + rblstatus.SelectedValue + "and emp_id=" + drpempid.SelectedValue + "";
        ds = cn.select(str);
        if (ds.Tables[0].Rows[0][0].ToString() == "0")
        {
            str = "insert into card_transaction (account_no,card_type,card_no,apply_date,issue_date,status,emp_id) values (" + txtaccountno.Text + ",'" + rblcardtype.SelectedValue + "'," + txtcardno.Text+ ",'" + txtapplydate.Text + "','" + txtissuedate.Text + "','" + rblstatus.SelectedValue + "'," +drpempid.SelectedValue + ")";
            cn.modify(str);
            Response.Write("<script>alert('card transaction Detali inserted')</script>");

        }
       
        viewcardtransaction();


    }
    public void binddropdown()
    {
        gf.fillcombo("select * from employee_master", drpempid, "f_name", "emp_id", "--select employee Id--");
    }
    public void viewcardtransaction()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select account_no,card_type,card_no,apply_date,issue_date,status,emp_id from card_transaction";
            ds = cn.select(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdcardtransaction.DataSource = ds.Tables[0];
                grdcardtransaction.DataBind();
            }
        }
        catch (Exception ex)
        {
        }
    }
}