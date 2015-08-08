using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["guid"] != null)
            {
                string data;
                string columns;
                QueryResult.GenerateQuery(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(Request["guid"])), out data, out columns);

                Session["data"] = data;
                Session["columns"] = columns;
            }
        }
    }
}