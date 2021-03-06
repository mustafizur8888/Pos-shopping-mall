﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategorySetup.aspx.cs" Inherits="WebApp.CategorySetup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 col-sm-12 col-lg-6 col-lg-offset-3 col-md-offset-3">

                <div class="alert alert-dismissible alert-danger text-center" runat="server" id="divError">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <asp:Label runat="server" ID="lblError"></asp:Label>
                </div>
                <div class="alert alert-dismissible alert-success text-center" runat="server" id="divSucc">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-9 col-sm-12 col-lg-9 col-lg-offset-3 col-md-offset-3">
            <div class="row">
                <div class="form-group">
                    <label for="txtCategory" class="col-lg-1 col-md-1 control-label">Role Name</label>
                    <div class="col-lg-4 col-md-6">
                        <asp:TextBox runat="server" CssClass="form-control" placeholder="Category Name" ID="txtCategory"></asp:TextBox>

                    </div>
                </div>

            </div>
            <br />
            <div class="row">
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-1 col-md-offset-1 col-md-10">
                        <button type="reset" class="btn btn-danger">Cancel</button>
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_OnClick" />
                    </div>

                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-8 col-lg-8 col-sm-12">
                    <asp:GridView ID="grdRole" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" />
                            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                            <asp:BoundField DataField="UserName" HeaderText="Created BY" />
                           <%-- <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="hidRoleId" Value='<%# Bind("Id") %>' />
                                    <asp:HiddenField runat="server" ID="hidRoleName" Value='<%# Bind("RoleName") %>' />
                                    <div class="btn-group btn-group-sm">
                                        <asp:Button runat="server" CssClass="btn btn-info btn-sm " Text="Edit" ID="btnEdit" OnClick="btnEdit_OnClick" />
                                        <asp:Button runat="server" CssClass="btn btn-warning  btn-sm" Text="Delete" ID="btnDelete" OnClick="btnDelete_OnClick" />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:HiddenField runat="server" ID="hidCatID" />
            </div>
        </div>
    </div>

</asp:Content>
