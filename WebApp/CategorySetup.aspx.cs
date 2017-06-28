using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace WebApp
{
    public partial class CategorySetup : System.Web.UI.Page
    {
        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                GetCat();
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {

                string query = @"Sptbl_Category_Save_Update";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        Value = txtCategory.Text,
                        ParameterName = "@CategoryName",
                    },
                    new SqlParameter
                    {
                        Value = string.IsNullOrWhiteSpace(hidCatID.Value)?"0":hidCatID.Value,
                        ParameterName = "@id",
                    },
                    new SqlParameter
                    {
                        Value = Session["userId"],
                        ParameterName = "@CreatedBy",
                    }
                };

                int count = _db.ExecuteNonQuery(query,sqlParameters);
                if (count>0)
                {
                    GetCat();
                }

            }
        }
        private bool Validation()
        {

            bool result = true;
            string msg = string.Empty;
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                msg += "Category Name is empty" + "<br>";
            }
            if (!string.IsNullOrWhiteSpace(msg))
            {
                ShowErrorMsg(msg);
                result = false;
            }
            return result;
        }
        private void GetCat()
        {
            string query = @"SELECT C.[Id],C.[CategoryName] ,U.UserName  FROM [PosDB].[dbo].[tbl_Category] C inner JOIN [dbo].[tbl_User] U on C.CreatedBy = U.ID";
            DataSet dataSet = null;
            dataSet = _db.GetDataSet(query);
            grdRole.DataSource = dataSet;
            grdRole.DataBind();
        }
        private void ShowErrorMsg(string msg)
        {
            lblError.Text = msg;
            divError.Visible = true;
        }
    }
}