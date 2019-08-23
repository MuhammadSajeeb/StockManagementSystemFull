<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="StockManagementSystem.Category.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h4>Create a new Category</h4>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" ID="lblMessage" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text=""></asp:Label>
            <div class="col-md-10">
                <div class="messagealert" id="alert_container">
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblCode" CssClass="col-md-2 control-label" Font-Bold="true" Text="Code" Font-Size="Medium"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCode"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
                <asp:HiddenField ID="IdHiddenField" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblName" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Name"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                    CssClass="text-danger" ErrorMessage="The Roll field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="CategorySaveButton" Text="Save" CssClass="btn btn-info" OnClick="CategorySaveButton_Click" />
                <asp:Button runat="server" ID="ClearButton" Text="Clear" CssClass="btn btn-info" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                <asp:GridView ID="CategoriesGridView" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="6" CellSpacing="10" OnPageIndexChanging="CategoriesGridView_PageIndexChanging" OnSelectedIndexChanged="CategoriesGridView_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial No" ItemStyle-Width="130">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="130px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Code" HeaderText="Category Code" />
                        <asp:BoundField DataField="Name" HeaderText="Category Name" />
                        <asp:CommandField HeaderText="Action" SelectText="Edit" ShowSelectButton="True">
                            <ItemStyle ForeColor="#CC0000" />
                        </asp:CommandField>
                    </Columns>
                    <PagerStyle Font-Bold="true" Font-Size="Small" ForeColor="#3399FF" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <style type="text/css">
        .messagealert {
            width: 280px;
        }
    </style>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Failed':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
    <link href="../Content/Gridviewstylesheet.css" rel="stylesheet" />
</asp:Content>
