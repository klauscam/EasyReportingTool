using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class addReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["sql"] != null)
                {

                    string guid = Guid.NewGuid().ToString();
                    using (DataClasses1DataContext dc = new DataClasses1DataContext())
                    {
                        Query q = new Query();
                        q.Guid = guid;
                        q.catalog = Request["catalog"];
                        q.createdby = User.Identity.Name;
                        q.createdon = DateTime.Now;
                        q.enabled = true;
                        q.server = Request["server"];
                        q.sql = Request["sql"];

                        dc.Queries.InsertOnSubmit(q);
                        dc.SubmitChanges();


                    }


                    Response.Write(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(guid)));

                }
            }catch{
                Response.Write("Trouble");
            }
        }
    }
}