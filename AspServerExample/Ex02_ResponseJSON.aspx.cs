using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex02_ResponseJSON : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Hashtable jsonResponse = new Hashtable();
        jsonResponse.Add("Name", "Domone");
        jsonResponse.Add("Score", 88);

        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        string jsonResponseAsString = jsSerializer.Serialize(jsonResponse);

        Response.Write(jsonResponseAsString);
        Response.End();
    }
}