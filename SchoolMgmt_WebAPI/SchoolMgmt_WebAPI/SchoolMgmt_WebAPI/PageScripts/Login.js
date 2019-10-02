var Login = {
    login: function () {
        var data = "username=" + $("#txtUserName").val() + "&password=" + $("#txtPassword").val() + "&grant_type=password";
        $.ajax({
            type: 'POST',
            cache: false,
            data: data,
            url: 'http://localhost:1559/token',
            //url: 'http://localhost:8081/token',
            success: function (data) {
                window.location.href = "/Dashboard/Index";
                sessionStorage.access_token = data.access_token;
            },
            error: function (err) {
                alert(err.responseJSON.error_description);
            }
        });
    },
    goToRegister: function () {
        $("#dvLogin").hide();
        $("#dvRegister").show();
    },
    goToLogin: function () {
        $("#dvLogin").show();
        $("#dvRegister").hide();
    }
}
$(document).ready(function () {


});
