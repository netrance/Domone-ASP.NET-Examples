using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex05_ResponseJSONArray_FromList_Ex05_ResponseJSONArray_FromList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create a list including members.
        List<Member> memberList = new List<Member>();
        memberList.Add(new Member("Domone", 88));
        memberList.Add(new Member("Gomone", 91));
        memberList.Add(new Member("Imone", 96));

        // Transform the list into JSON string.
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        string jsonResponseAsString = jsSerializer.Serialize(memberList);

        // Return the JSON string.
        Response.Write(jsonResponseAsString);
        Response.End();
    }
}