using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex08_InsertingCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the JSON input object from a client.
        Hashtable jsonInput = JSONUtil.GetJSONObject(Request);

        // Read input data from jsonInput: customer ID
        string customerId = Convert.ToString(jsonInput["customer_id"]);
        string customerPw = Convert.ToString(jsonInput["customer_pw"]);
        string customerName = Convert.ToString(jsonInput["customer_name"]);
        string customerMobile = Convert.ToString(jsonInput["customer_mobile"]);
        string customerEmail = Convert.ToString(jsonInput["customer_email"]);

        // Make the connection to the database server.
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_HomeShopping"].ConnectionString);

        // Write the query to find the customer by the ID.
        string sql = "INSERT INTO dbo.HS_Customer ("
                + "customer_id, customer_pw, customer_name, customer_mobile, customer_email) VALUES ("
                + "@customerId, @customerPw, @customerName, @customerMobile, @customerEmail)";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@customerId", customerId);
        cmd.Parameters.AddWithValue("@customerPw", customerPw);
        cmd.Parameters.AddWithValue("@customerName", customerName);
        cmd.Parameters.AddWithValue("@customerMobile", customerMobile);
        cmd.Parameters.AddWithValue("@customerEmail", customerEmail);

        // Execute insert command.
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
        jsonOutput.Add("insert_result", result);

        // Send the output JSON object to the client.
        // Serializing is needed to transform the object to a string.
        Response.Write(JSONUtil.toStringFromJSON(jsonOutput));
        Response.End();
    }
}