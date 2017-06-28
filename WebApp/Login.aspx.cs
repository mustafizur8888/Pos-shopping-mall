using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {

        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
        }
        private void ShowErrorMsg(string msg)
        {
            lblError.Text = msg;
            divError.Visible = true;
        }
        protected void btnLoging_OnClick(object sender, EventArgs e)
        {

            DataSet ds = _db.GetDataSet(@"SELECT  [Id],[UserName] FROM[PosDB].[dbo].[tbl_User] where userName = '" + txtUserName.Text +
                            "' and Password = '" + txtPassword.Text + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                Session["userName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                Session["userId"] = ds.Tables[0].Rows[0]["Id"].ToString();
            }
            else
            {
                ShowErrorMsg("User name or password wrong");
            }

        }
    }
}