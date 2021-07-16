<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LUXURY_SITE.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Teldaluxury Admin[Sign In]</title>
    <!-- plugins:css -->
   <%--<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.min.js"></script>--%>
   
    <%--<%--<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>--%>

    <script src="Admin/js/sweetalert.js"></script>


    <script> 
        var object = { status: false, ele: null };

        function ConfirmDelete() {

            if (status) { return true; };
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Yes, delete it!",
                cancelButtonText: "No, cancel plx!",
                closeOnConfirm: true,
                closeOnCancel: false
            },
                function (isConfirm)
                {
                    if (isConfirm)
                    {
                        swal("Deleted!", "Your imaginary file has been deleted.", "success");
                    } else {
                        swal("Cancelled", "Your imaginary file is safe :)", "error");
                    }
                });
            return false;
        };

        function newSweet()
        {
            swal({
                title: "Are you sure?",
                text: "Once deleted, you will not be able to recover this imaginary file!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) =>
                {
                    if (willDelete)
                    {
                        swal("Poof! Your imaginary file has been deleted!",
                            {
                                icon: "success",
                            });
                    } else
                    {
                        swal("Your imaginary file is safe!");
                    }
                });

        }


    </script>


    <link rel="stylesheet" href="Admin/vendors/feather/feather.css" />
    <link rel="stylesheet" href="Admin/vendors/ti-icons/css/themify-icons.css" />
    <link rel="stylesheet" href="Admin/vendors/css/vendor.bundle.base.css" />
    <!-- endinject -->
    <!-- Plugin css for this page -->
    <!-- End plugin css for this page -->
    <!-- inject:css -->
    <link rel="stylesheet" href="Admin/css/vertical-layout-light/style.css" />
    <!-- endinject -->
    <link rel="shortcut icon" href="Admin/images/favicon.png" />
</head>

<body>
    <form runat="server">
        <div class="container-scroller">
            <div class="container-fluid page-body-wrapper full-page-wrapper">
                <div class="content-wrapper d-flex align-items-center auth px-0">
                    <div class="row w-100 mx-0">
                        <div class="col-lg-4 mx-auto">
                            <div class="auth-form-light text-left py-5 px-4 px-sm-5">
                                <div class="brand-logo text-center">
                                    <img src="Admin/images/logo.svg" alt="logo" />
                                </div>
                                <h4 class="text-center">Hello! let's get started</h4>
                                <h6 class="font-weight-light text-center">Sign in to continue.</h6>
                                <asp:Label ID="lblErrorMsg" runat="server" CssClass="font-weight-light text-center text-danger" />
                                <div class="pt-3">
                                    <div class="form-group">
                                        <asp:TextBox runat="server" TextMode="Email" class="form-control form-control-lg" ID="txtemail" placeholder="Email address" required OnTextChanged="txtemail_TextChanged" />
                                        <asp:Label CssClass="text-muted small" ID="emailvalidator" runat="server" ForeColor="DarkRed" />
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control form-control-lg" ID="txtpassword" placeholder="Password"  required />
                                        <asp:Label CssClass="text-muted small" ID="passwordvalidator" runat="server" ForeColor="DarkRed" />
                                    </div>
                                   
                                    <div class="mt-3">
                                        <asp:Button runat="server" ID="btnSubmit" Text="SIGN IN" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" OnClick="SignIn" />
                                         <%--<asp:Button ID="Button1" runat="server" CssClass="text-primary" Text="Sign In" OnClick="SignIn" />--%>
                                    </div>
                                    
                                    <div class="my-2 d-flex justify-content-between align-items-center">
                                        <div class="form-check">
                                            <label class="form-check-label text-muted">
                                                <input type="checkbox" class="form-check-input" />
                                                Keep me signed in
                   
                                            </label>
                                        </div>
                                        <a href="#" class="auth-link text-black">Forgot password?</a>
                                    </div>
                                    <div class="mb-2">
                                        
                                        <button  type="button" class="btn btn-block btn-facebook auth-form-btn">
                                            <i class="ti-facebook mr-2"></i>Connect using facebook
                 
                                        </button>
                                    </div>
                                    <div class="text-center mt-4 font-weight-light">
                                        Don't have an account? 

                                        <asp:Button ID="btnsub" UseSubmitBehavior="false" runat="server"  CssClass="text-primary" Text="Sweet Alert Test" OnClientClick="return newSweet(this);" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- content-wrapper ends -->
            </div>
            <!-- page-body-wrapper ends -->
        </div>
        <!-- container-scroller -->
        <!-- plugins:js -->
        <script src="Admin/vendors/js/vendor.bundle.base.js"></script>
        <!-- endinject -->
        <!-- Plugin js for this page -->
        <!-- End plugin js for this page -->
        <!-- inject:js -->
        <script src="Admin/js/off-canvas.js"></script>
        <script src="Admin/js/hoverable-collapse.js"></script>
        <script src="Admin/js/template.js"></script>
        <script src="Admin/js/settings.js"></script>
        <script src="Admin/js/todolist.js"></script>
        <!-- endinject -->
    </form>
</body>

</html>