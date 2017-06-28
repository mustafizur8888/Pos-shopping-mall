<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 col-sm-12 col-lg-6 col-lg-offset-3 col-md-offset-3">

                <div class="alert alert-dismissible alert-danger text-center" runat="server" id="divError">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <asp:Label runat="server" ID="lblError"></asp:Label>
                </div>

            </div>

            <div class="col-md-9 col-sm-12 col-lg-9 col-lg-offset-3 col-md-offset-3">

                <div class="row">
                    <div class="form-group">
                        <label for="txtUserName" class="col-lg-1 col-md-1 control-label">User Name</label>
                        <div class="col-lg-4 col-md-6">
                            <asp:TextBox runat="server" CssClass="form-control" placeholder="User Name" ID="txtUserName"></asp:TextBox>

                        </div>
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label for="txtPassword" class="col-lg-1 col-md-1 control-label">Password</label>
                        <div class="col-lg-4 col-md-6">
                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Password" ID="txtPassword"></asp:TextBox>

                        </div>
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-1 col-md-offset-1 col-md-10">
                            <button type="reset" class="btn btn-danger">Cancel</button>
                            <asp:Button runat="server" ID="btnLoging" CssClass="btn btn-info" Text="Log In" OnClick="btnLoging_OnClick"/>
                        </div>

                    </div>
                </div>

            </div>



        </div>
    </div>

</asp:Content>
