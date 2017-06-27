using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
         
                int executeNonQuery = new Db().ExecuteNonQuery(@"INSERT INTO [dbo].[TestTable]
           ([Text])  VALUES('sssss')");
            }
        }
    }
}