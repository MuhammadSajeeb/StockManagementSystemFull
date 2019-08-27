<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="StockManagementSystem.Product.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h4>Add a new Product</h4>
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
            <asp:Label runat="server" ID="lblCategories" AssociatedControlID="CategoriesDropDownList" CssClass="col-md-2 control-label">Categories</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="CategoriesDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CategoriesDropDownList_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CategoriesDropDownList"
                    CssClass="text-danger" ErrorMessage="This field is required." />
                <input type="button" id="btnShowLogin" class="btn btn-primary" value="Add" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblReorder" CssClass="col-md-2 control-label" AssociatedControlID="txtReorder">Reorder level</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtReorder" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtReorder"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblDiscription" CssClass="col-md-2 control-label" AssociatedControlID="txtDescription">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="Multiline" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescription"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblImageFileUpload" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Upload"></asp:Label>
            <div class="col-md-10">
                <asp:FileUpload ID="ImageFileUpload" runat="server" CssClass="form-control" onchange="ImagePreview(this);" />
                <asp:RequiredFieldValidator runat="server" ID="RfvImageUpload" ControlToValidate="ImageFileUpload"
                    CssClass="text-danger" ErrorMessage="The Upload field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblShowImage" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Image"></asp:Label>
            <div class="col-md-10">
                <asp:Image ID="ShowImage" runat="server" CssClass="form-control" Height="100px" Width="100px" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-info" OnClick="SaveButton_Click" />
                <asp:Button ID="ClearButton" runat="server" Text="Clear" CssClass="btn btn-info" />
            </div>
        </div>
        <%--\\popup model start\\--%>
        <div class="modal fade" id="LoginModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
            aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                        <h4 class="modal-title" id="ModalTitle">Create New Categories</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblCategoriesCode" CssClass="col-md-2 control-label" Font-Bold="true" Text="Code" Font-Size="Medium"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtCategoriesCode" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblCategoriesName" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Name"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtCategoriesName" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="CategoriesAddButton" Text="Save" runat="server" Class="btn btn-primary" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
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

    <script type="text/javascript">
        $(function () {
            $("#btnShowLogin").click(function () {
                $('#LoginModal').modal('show');
            });
        });
    </script>

    <%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />

    <script>
        $('#<%=CategoriesDropDownList.ClientID%>').chosen();
    </script>--%>
</asp:Content>
