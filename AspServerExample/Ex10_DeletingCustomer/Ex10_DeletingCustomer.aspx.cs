using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex10_DeletingCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the JSON input object from a client.
        Hashtable jsonInput = JSONUtil.GetJSONObject(Request);

        // Read input data from jsonInput
        string customerId = Convert.ToString(jsonInput["customer_id"]);

        // Make the connection to the database server.
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_HomeShopping"].ConnectionString);

        // Write the query to update the customer by the ID.
        string sql = "DELETE FROM dbo.HS_Customer WHERE customer_id = @customerId";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@customerId", customerId);

        // Execute update command.
        string result = "success";
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            result = "fail by exception";
        }

        // Create output JSON object.
        Hashtable jsonOutput = new Hashtable();
        jsonOutput.Add("delete_result", result);

        // Send the output JSON object to the client.
        // Serializing is needed to transform the object to a string.
        Response.Write(JSONUtil.toStringFromJSON(jsonOutput));
        Response.End();
    }
}