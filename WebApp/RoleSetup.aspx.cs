﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                string roleName = txtRoleName.Text;

                string query = @"INSERT INTO [dbo].[tbl_Role]
           ([RoleName])VALUES('" + roleName + "')";
                int count = _db.ExecuteNonQuery(query);
                if (count > 0)
                {
                    GetRole();
                    Clear();
                    ShowSuccMsg("Role Save Successfully");
                }
            }


        }

        private void Clear()
        {
            txtRoleName.Text = string.Empty;
        }

        private void GetRole()
        {
            string query = @"Select * from [dbo].[tbl_Role]";
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
    }
}