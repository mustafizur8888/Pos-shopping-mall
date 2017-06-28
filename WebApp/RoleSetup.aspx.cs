using System;
using System.Data;
using System.Web.UI.WebControls;
using DAL;

namespace WebApp
{
    public partial class RoleSetup : System.Web.UI.Page
    {
        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {

            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                GetRole();
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {

            if (Validation())
            {
                int count = 0;
                string roleName = txtRoleName.Text;
                if (string.IsNullOrWhiteSpace(hidRoleID.Value))
                {
                    string query = @"INSERT INTO [dbo].[tbl_Role]([RoleName],[CreatedBy])VALUES('" + roleName + "','" + Session["userId"] + "')";
                    count = _db.ExecuteNonQuery(query);
                }
                else if (!string.IsNullOrWhiteSpace(hidRoleID.Value))
                {
                    string query = @"UPDATE [dbo].[tbl_Role]
                                    SET [RoleName] = '" + txtRoleName.Text + "',[CreatedBy] = '" + Session["userId"] + "',[TimeStamp] = GETDATE()WHERE id='" + hidRoleID.Value + "'";
                    count = _db.ExecuteNonQuery(query);
                }


                if (count > 0)
                {
                    GetRole();
                    Clear();
                    ShowSuccMsg("Role Save Successfully");
                }
                else
                {
                    ShowErrorMsg("Failed To Save/Update");
                }
            }


        }

        private void Clear()
        {
            txtRoleName.Text = string.Empty;
            hidRoleID.Value = string.Empty;
        }

        private void GetRole()
        {
            string query = @"  Select R.Id,R.RoleName,U.UserName from [dbo].[tbl_Role] R  inner join [dbo].[tbl_User] U on   U.id = R.createdBy";
            DataSet dataSet = null;
            dataSet = _db.GetDataSet(query);
            grdRole.DataSource = dataSet;
            grdRole.DataBind();
        }

        private void ShowSuccMsg(string msg)
        {
            lblSuccess.Text = msg;
            divSucc.Visible = true;
        }

        private bool Validation()
        {

            bool result = true;
            string msg = string.Empty;
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                msg += "Role Name is empty" + "<br>";
            }


            if (!string.IsNullOrWhiteSpace(msg))
            {
                ShowErrorMsg(msg);
                result = false;
            }
            return result;
        }

        private void ShowErrorMsg(string msg)
        {
            lblError.Text = msg;
            divError.Visible = true;
        }

        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string id = ((HiddenField)gvr.FindControl("hidRoleId")).Value;
            string RoleName = ((HiddenField)gvr.FindControl("hidRoleName")).Value;
            txtRoleName.Text = RoleName;
            hidRoleID.Value = id;

        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string id = ((HiddenField)gvr.FindControl("hidRoleId")).Value;

            string query = @"DELETE FROM [dbo].[tbl_Role]    WHERE id='" + id + "'";
            int count = _db.ExecuteNonQuery(query);


            if (count > 0)
            {
                GetRole();
                Clear();
                ShowSuccMsg("Delete Successfully");
            }
            else
            {
                ShowErrorMsg("Failed To Delete");
            }
        }
    }
}