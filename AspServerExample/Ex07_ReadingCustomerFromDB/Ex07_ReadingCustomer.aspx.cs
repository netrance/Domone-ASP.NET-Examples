using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public partial class Ex07_ReadingCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the JSON input object from a client.
        Hashtable jsonInput = JSONUtil.GetJSONObject(Request);

        // Read input data from jsonInput.
        string customerId = Convert.ToString(jsonInput["customer_id"]);

        // Create output JSON object.
        Hashtable jsonOutput = new Hashtable();
        jsonOutput.Add("customers", findCustomerById(customerId));

        // Send the output JSON object to the client.
        // Serializing is needed to transform the object to a string.
        Response.Write(JSONUtil.toStringFromJSON(jsonOutput));
        Response.End();
    }

    private List<Hashtable> findCustomerById(string customerId)
    {
        // Make the connection to the database server.
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_HomeShopping"].ConnectionString);

        // Write the query to find the customer by the ID.
        string sql = "SELECT * FROM dbo.Customer WHERE customer_id = @customerId";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@customerId", customerId);

        // Load customer data from the data server.
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        List<Hashtable> userList = new List<Hashtable>();
        while (rd.Read())
        {
            userList.Add(getCustomerFrom(rd));
        }

        rd.Close();
        con.Close();

        return userList;
    }

    private Hashtable getCustomerFrom(SqlDataReader rd)
    {
        Hashtable customerAsHashtable = new Hashtable();
        customerAsHashtable.Add("customer_id", rd["customer_id"]);
        customerAsHashtable.Add("customer_pw", rd["customer_pw"]);
        customerAsHashtable.Add("customer_name", rd["customer_name"]);
        customerAsHashtable.Add("customer_mobile", rd["customer_mobile"]);
        customerAsHashtable.Add("customer_email", rd["customer_email"]);

        return customerAsHashtable;
    }
}