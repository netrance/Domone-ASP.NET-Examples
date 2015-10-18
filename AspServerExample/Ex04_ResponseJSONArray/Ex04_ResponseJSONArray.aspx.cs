using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex04_ResponseJSONArray : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Two JSON objects
        Hashtable jsonMember1 = new Hashtable();
        jsonMember1.Add("Name", "Domone");
        jsonMember1.Add("Score", 88);
        Hashtable jsonMember2 = new Hashtable();
        jsonMember2.Add("Name", "Gomone");
        jsonMember2.Add("Score", 91);

        // JSON array, which include the above 2 objects.
        List<Hashtable> jsonArrayAsList = new List<Hashtable>();
        jsonArrayAsList.Add(jsonMember1);
        jsonArrayAsList.Add(jsonMember2);

        // JSON object to be returned to the client.
        Hashtable jsonResponse = new Hashtable();
        jsonResponse.Add("Members", jsonArrayAsList);

        // Transform the JSON object to a string.
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        string jsonResponseAsString = jsSerializer.Serialize(jsonResponse);

        // Return the JSON string.
        Response.Write(jsonResponseAsString);
        Response.End();
    }
}