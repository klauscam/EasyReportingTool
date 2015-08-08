<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publisher.aspx.cs" Inherits="WebApplication10.publisher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery1_11_3.js" type="text/javascript"></script>
    <script>
        function save() {
            jQuery.ajax({
                url: "addReport.aspx?server=" + $("#server").val() + "&catalog=" + $("#catalog").val() + "&sql=" + $("#sql").val().replace(/\n/g, " ").replace(/\r/g, " "),
                success: function (data) {

                    if (data == "Trouble") $("#error").val("Trouble");
                    else $("#error").html("/report.aspx?guid="+data);
                },

                async: false
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <input placeholder="Server" type="text" id="server" /><br/>
            <input placeholder="Catalog" type="text" id="catalog" /><br/>
            <textarea placeholder="Sql"  cols="100" rows="25" id="sql" ></textarea><br/>
            <input type="button" value="Save" onclick="save()" /><label id="error"></label>
    </div>
    </form>
</body>
</html>
