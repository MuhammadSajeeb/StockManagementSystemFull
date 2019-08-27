<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="StockManagementSystem.Sale.Confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h4>Sale Product</h4>
    <br />
    <div class="form-horizontal">
        <div class="row">
            <div class="col-md-offset-1 col-md-5">
                <div class="panel panel-info" style="height: 250px">
                    <div class="panel-heading">
                        <h3 class="panel-title">Customer</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblCustomer" AssociatedControlID="CustomerDropDownList" CssClass="col-md-2 control-label">Customer</asp:Label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="CustomerDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CustomerDropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblLoyaltyPoint" AssociatedControlID="txtLoyaltyPoint" CssClass="col-md-2 control-label">Loyalty Point</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtLoyaltyPoint" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                            </div>
                        </div>
                        <hr/>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblInvoice" AssociatedControlID="txtInvoice" CssClass="col-md-2 control-label">Invoice</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtInvoice" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5" style="width: 500px">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h3 class="panel-title">Product</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblProduct" AssociatedControlID="ProductDropDownList" CssClass="col-md-2 control-label">Product</asp:Label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ProductDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ProductDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblAvailableQty" AssociatedControlID="txtAvailableQty" CssClass="col-md-2 control-label">Available</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="txtAvailableQty" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblMrp" AssociatedControlID="txtMrp" CssClass="col-md-2 control-label">MRP</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="txtMrp" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblQty" AssociatedControlID="txtQty" CssClass="col-md-2 control-label">Quantity</asp:Label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="txtQty" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="false" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-7 col-md-12">
                                        <asp:Button ID="AddButton" runat="server" Text="Add" CssClass="btn btn-info" Width="85px" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-5">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title">Sales Details</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="col-md-5">
                                <asp:GridView ID="SalesGridView" runat="server" EmptyDataText="No Purchase Order" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="False" CellSpacing="10">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                        <asp:BoundField DataField="Name" HeaderText="Product" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                        <asp:BoundField DataField="Mrp" HeaderText="Mrp" />
                                        <asp:BoundField DataField="TotalMrp" HeaderText="TotalMrp" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnDelete" CommandArgument='<%# Eval("Id") %>' CommandName="DeleteRow" ForeColor="#8C4510" runat="server" CausesValidation="false">Delete</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle Font-Bold="true" Font-Size="Small" ForeColor="#3399FF" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblGrandTotal" AssociatedControlID="txtAvailableQty" CssClass="col-md-2 control-label">Grand Total</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtGrandTotal" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblDiscount" AssociatedControlID="txtMrp" CssClass="col-md-2 control-label">Discount</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblPaidAmount" AssociatedControlID="txtPaidAmount" CssClass="col-md-2 control-label">Paid Amount</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtPaidAmount" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="false" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblChanges" AssociatedControlID="txtChanges" CssClass="col-md-2 control-label">Changes</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtChanges" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="false" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-7 col-md-12">
                                <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="btn btn-info" Width="85px" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblMessage" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text=""></asp:Label>
                            <div class="col-md-10">
                                <div class="messagealert" id="alert_container">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
    <script>
        $('#<%=ProductDropDownList.ClientID%>').chosen();
        $('#<%=CustomerDropDownList.ClientID%>').chosen();
    </script>
    <%--    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/ScrollableGridViewPlugin_ASP.NetAJAXmin.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=PurchaseGridView.ClientID %>').Scrollable({
                ScrollHeight: 100,
                IsInUpdatePanel: true
            });
        });
    </script>--%>
</asp:Content>
