using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex06_ExchangeServer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the JSON input object from a client.
        Hashtable jsonInput = JSONUtil.GetJSONObject(Request);

        // Read input data from jsonInput.
        long dollar = Convert.ToInt64(jsonInput["dollar"]);

        // Create output data.
        long won = convertDollarToWon(dollar);

        // Create output JSON object.
        Hashtable jsonOutput = new Hashtable();
        jsonOutput.Add("won", won);
        jsonOutput.Add("dollar", dollar);

        // Send the output JSON object to the client.
        // Serializing is needed to transform the object to a string.
        Response.Write(JSONUtil.toStringFromJSON(jsonOutput));
        Response.End();
    }

    // Suppose 1 dollar equals to 1128 wons.
    long convertDollarToWon(long dollar)
    {
        return dollar * 1128;
    }
}
/*
{
    // Temp data to test the communication between this server and clients.
    private Hashtable[] members;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get JSON string received from a client.
        string json;
        using (StreamReader reader = new StreamReader(Request.InputStream))
        {
            json = reader.ReadToEnd();
        }

        // Convert JSON string to Hashtable object.
        Hashtable jsonInput = new JavaScriptSerializer().Deserialize<Hashtable>(json);

        // Load or save data(if required).
        Hashtable[] members = getMembers();
        Hashtable targetMember = getMember(Convert.ToString(jsonInput["name"]), members);

        // Create new Hashtable object to be returned to the client.
        // Add the loaded data, which the client requested, into the container.
        Hashtable responseContent = new Hashtable();
        if (null != targetMember)
        {
            responseContent.Add("name", targetMember["name"]);
            responseContent.Add("score", targetMember["score"]);
        }

        // Send the new Hashtable object to the client.
        // Serializing is needed to transform the Hashtable object to a string.
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        Response.Write(jsSerializer.Serialize(responseContent));
        Response.End();
    }

    private Hashtable[] getMembers()
    {
        Hashtable[] members = new Hashtable[5];

        for (int i = 0; i < members.Length; i++)
        {
            members[i] = new Hashtable();
        }

        members[0].Add("name", "Tom");
        members[0].Add("score", 83);
        members[1].Add("name", "Jane");
        members[1].Add("score", 91);
        members[2].Add("name", "Yuri");
        members[2].Add("score", 76);
        members[3].Add("name", "Ryan");
        members[3].Add("score", 73);
        members[4].Add("name", "Jose");
        members[4].Add("score", 95);

        return members;
    }

    private Hashtable getMember(string name, Hashtable[] members)
    {
        foreach (Hashtable ht in members)
        {
            if (!ht.ContainsKey("name"))
            {
                continue;
            }

            if (name.Equals(ht["name"]))
            {
                return ht;
            }
        }

        return null;
    }
}
*/