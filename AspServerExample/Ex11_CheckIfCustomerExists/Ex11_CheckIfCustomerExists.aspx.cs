using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex11_CheckIfCustomerExists : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the JSON input object from a client.
        Hashtable jsonInput = JSONUtil.GetJSONObject(Request);

        // Read input data from jsonInput: customer ID
        // If you want to know the format of the input and output data,
        // go to the description of function checkIfCustomerExists()
        // in Ex11_CheckIfCustomerExists_Client.js.
        Dictionary<string, object> jsonContent
            = (Dictionary <string, object>)jsonInput["content"];
        string customerId
            = Convert.ToString(jsonContent["customer_id"]);

        // Check if the customer exists in the database.
        HomeShoppingDataManager dataManager = HomeShoppingDataManager.getInstance();
        bool ifCustomerExists = dataManager.checkIfCustomerExists(customerId);

        // Create output JSON object.
        Hashtable jsonOutput        = new Hashtable();
        Hashtable jsonOutputHeader  = new Hashtable();
        Hashtable jsonOutputContent = new Hashtable();

        jsonOutputHeader .Add("svc_res_code", 100);
        jsonOutputContent.Add("if_customer_exists", ifCustomerExists);
        jsonOutput       .Add("header", jsonOutputHeader);
        jsonOutput       .Add("content", jsonOutputContent);

        // Send the output JSON object to the client.
        // Serializing is needed to transform the object to a string.
        Response.Write(JSONUtil.toStringFromJSON(jsonOutput));
        Response.End();
    }
}