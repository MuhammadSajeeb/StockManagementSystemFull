<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="StockManagementSystem.Party.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h4>Add a new Customer</h4>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <asp:Label runat="server" ID="lblMessage" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text=""></asp:Label>
            <div class="col-md-10">
                <div class="messagealert" id="alert_container">
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-3">
                <asp:Label runat="server" ID="lblCode" CssClass="control-label" Font-Bold="true" Text="Code" Font-Size="Medium"></asp:Label>
                <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCode"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
                <asp:HiddenField ID="IdHiddenField" runat="server" />
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblName" CssClass="control-label" Font-Bold="true" Font-Size="Medium" Text="Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblEmail" CssClass="control-label" AssociatedControlID="txtEmail">Email</asp:Label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-2">
                <asp:Image ID="ShowImage" runat="server" CssClass="form-control" Height="100px" Width="100px" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-1 col-md-3">
                <asp:Label runat="server" ID="lblAddress" CssClass="control-label" AssociatedControlID="txtAddress">Address</asp:Label>
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblContact" CssClass="control-label" AssociatedControlID="txtContact">Contact</asp:Label>
                <asp:TextBox runat="server" ID="txtContact" CssClass="form-control" TextMode="Phone" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContact"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblLoyaltyPoint" CssClass="control-label" AssociatedControlID="txtLoyaltyPoint">Loyalty Point</asp:Label>
                <asp:TextBox runat="server" ID="txtLoyaltyPoint" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblImageFileUpload" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Upload"></asp:Label>
                <asp:FileUpload ID="ImageFileUpload" runat="server" CssClass="form-control" onchange="ImagePreview(this);" />
                <asp:RequiredFieldValidator runat="server" ID="RfvImageUpload" ControlToValidate="ImageFileUpload"
                    CssClass="text-danger" ErrorMessage="The Upload field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-5 col-md-5">
                <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-info" OnClick="SaveButton_Click" />
                <asp:Button ID="ClearButton" runat="server" Text="Clear" CssClass="btn btn-info" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                <asp:GridView ID="CustomerGridView" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="6" CellSpacing="10">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial" ItemStyle-Width="130">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="50px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="Code" HeaderText="Code" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Contact" HeaderText="Contact" />
                        <asp:BoundField DataField="LoyaltyPoint" HeaderText="Loyalty Point" />
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
    <div class="col-md-2">
    </div>
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

    <script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ShowImage.ClientID%>').prop('src', e.target.result)
                        .width(100)
                        .height(100);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <link href="../Content/Gridviewstylesheet.css" rel="stylesheet" />
</asp:Content>
