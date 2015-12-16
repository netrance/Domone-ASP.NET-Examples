using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex09_UpdatingCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the JSON input object from a client.
        Hashtable jsonInput = JSONUtil.GetJSONObject(Request);

        // Read input data from jsonInput
        string customerId = Convert.ToString(jsonInput["customer_id"]);
        string customerPw = Convert.ToString(jsonInput["customer_pw"]);
        string customerName = Convert.ToString(jsonInput["customer_name"]);
        string customerMobile = Convert.ToString(jsonInput["customer_mobile"]);
        string customerEmail = Convert.ToString(jsonInput["customer_email"]);

        // Make the connection to the database server.
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_HomeShopping"].ConnectionString);

        // Write the query to update the customer by the ID.
        string sql = "UPDATE dbo.Customer SET "
                + "customer_pw = @customerPw, "
                + "customer_name = @customerName, "
                + "customer_mobile = @customerMobile, "
                + "customer_email = @customerEmail "
                + "WHERE customer_id = @customerId";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@customerPw", customerPw);
        cmd.Parameters.AddWithValue("@customerName", customerName);
        cmd.Parameters.AddWithValue("@customerMobile", customerMobile);
        cmd.Parameters.AddWithValue("@customerEmail", customerEmail);
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
        jsonOutput.Add("update_result", result);

        // Send the output JSON object to the client.
        // Serializing is needed to transform the object to a string.
        Response.Write(JSONUtil.toStringFromJSON(jsonOutput));
        Response.End();
    }
}