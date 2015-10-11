using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex03_ResponseJSON_FromObject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Member member = new Member("Domone", 88);

        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        string jsonResponseAsString = jsSerializer.Serialize(member);

        Response.Write(jsonResponseAsString);
        Response.End();
    }
}