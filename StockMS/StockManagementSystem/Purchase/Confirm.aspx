<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="StockManagementSystem.Purchase.Confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h4>Purchase Product</h4>
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
            <div class="col-md-offset-3 col-md-2">
                <asp:Label runat="server" ID="lblDate" CssClass="control-label" Font-Bold="true" Text="Date" Font-Size="Medium"></asp:Label>
                <asp:TextBox runat="server" ID="txtDate" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblInvoice" CssClass="control-label" Font-Bold="true" Font-Size="Medium" Text="Invoice"></asp:Label>
                <asp:TextBox runat="server" ID="txtInvoice" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" />
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblSuplier" CssClass="control-label" AssociatedControlID="SuplierDropDownList">Suplier</asp:Label>
                <asp:DropDownList ID="SuplierDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-2">
                <asp:Label runat="server" ID="lblProduct" CssClass="control-label" AssociatedControlID="ProductDropDownList">Product</asp:Label>
                <asp:DropDownList ID="ProductDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblCode" CssClass="control-label" AssociatedControlID="txtCode">Code</asp:Label>
                <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" TextMode="Phone" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblManufacturedDate" CssClass="control-label" AssociatedControlID="txtManufacturedDate">Manufactured Date</asp:Label>
                <asp:TextBox runat="server" ID="txtManufacturedDate" CssClass="form-control" TextMode="Date" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtManufacturedDate"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblExpireDate" CssClass="control-label" AssociatedControlID="txtExpireDate">Expire Date</asp:Label>
                <asp:TextBox runat="server" ID="txtExpireDate" CssClass="form-control" TextMode="Date" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtExpireDate"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-2">
                <asp:Label runat="server" ID="lblQty" CssClass="control-label" AssociatedControlID="txtQty">Quantity</asp:Label>
                <asp:TextBox runat="server" ID="txtQty" CssClass="form-control" TextMode="Number" Font-Bold="true" Font-Size="Medium" Style="text-align: center" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQty"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblUnitPrice" CssClass="control-label" AssociatedControlID="txtUnitPrice">Unit price(Tk)</asp:Label>
                <asp:TextBox runat="server" ID="txtUnitPrice" CssClass="form-control" TextMode="Number" Font-Bold="true" Font-Size="Medium" Style="text-align: center"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUnitPrice"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblTotalPrice" CssClass="control-label" AssociatedControlID="txtTotalPrice">Total Price(Tk)</asp:Label>
                <asp:TextBox runat="server" ID="txtTotalPrice" CssClass="form-control" TextMode="Number" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true"/>
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" ID="lblMrp" CssClass="control-label" AssociatedControlID="txtMrp">New MRP(Tk)</asp:Label>
                <asp:TextBox runat="server" ID="txtMrp" CssClass="form-control" TextMode="Number" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true"/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-9 col-md-2">
                <asp:Button ID="AddButton" runat="server" Text="Add" CssClass="btn btn-info" OnClick="AddButton_Click" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                <asp:GridView ID="PurchaseGridView" runat="server" EmptyDataText="No Purchase Order" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="6" CellSpacing="10">
                    <Columns>
                        <asp:TemplateField HeaderText="Serial" ItemStyle-Width="130">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="50px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Code" HeaderText="Code"/>
                        <asp:BoundField DataField="ManufacturedDate" HeaderText="Manufactured Date" />
                        <asp:BoundField DataField="ExpireDate" HeaderText="Expire Date" />
                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
                        <asp:BoundField DataField="NewMrp" HeaderText="New Mrp" />
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
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
      <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet"/>
      <script>
          $('#<%=ProductDropDownList.ClientID%>').chosen();
      </script>
    <link href="../Content/Gridviewstylesheet.css" rel="stylesheet" />
</asp:Content>
