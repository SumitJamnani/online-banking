using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class frmadmin : System.Web.UI.Page
{
    General_Function gf = new General_Function();
    db_conn cn = new db_conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

        }
    }


    public void binddropdown()
    {
        drprequest.Items.Clear();
       
        if(drpcheque.SelectedValue.ToString().ToLower()=="c")
            gf.fillcombo("Select * from chequebook_transaction where status=0", drprequest, "account_no", "account_no", "select chequebook_transaction");
        else if(drpcheque.SelectedValue.ToString().ToLower()=="p")
            gf.fillcombo("Select * from passbook_transaction where status=0", drprequest, "account_no", "account_no", "select passbook_transaction");
        else if(drpcheque.SelectedValue.ToString().ToLower()=="D")
            gf.fillcombo("Select * from demanddraft_transaction where status=0", drprequest, "account_no", "account_no", "select demanddraft_transaction");
        else if (drpcheque.SelectedValue.ToString().ToLower() == "CL")
            gf.fillcombo("Select * from customer_loan where status=0", drprequest, "account_no", "account_no", "select customer_loan");
       
    }
   

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        if (drpcheque.SelectedValue.ToString().ToLower() == "c")
        {
            string str = "update chequebook_transaction set status=1 where account_no='" + drprequest.SelectedValue + "'";

            cn.modify(str);
            Response.Write("<script>alert('chequebook issued')</script>");
        }
        else if (drpcheque.SelectedValue.ToString().ToLower() == "p")
        {
            string str = "update passbook_transaction set status=1 where account_no='" + drprequest.SelectedValue + "'";

            cn.modify(str);
            Response.Write("<script>alert('passbook issued')</script>");
          }
        else if (drpcheque.SelectedValue.ToString().ToLower() == "D")
        {
            string str = "update demanddraft_transaction set status=1 where account_no='" + drprequest.SelectedValue + "'";

            cn.modify(str);
            Response.Write("<script>alert('demanddraft issued')</script>");
        }
        else if (drpcheque.SelectedValue.ToString().ToLower() == "CL")
        {
            string str = "update customer_loan set status=1 where account_no='" + drprequest.SelectedValue + "'";

            cn.modify(str);
            Response.Write("<script>alert('customere_loan issued')</script>");
        }

        
    }
    protected void changed1(object sender, EventArgs e)
    {
        binddropdown();
    }
}