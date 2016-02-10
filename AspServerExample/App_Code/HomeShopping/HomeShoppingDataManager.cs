using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Database manager class to read or write data of HomeShopping program.
/// Singleton pattern is applied to allow to create only one object of this class.
/// </summary>
public class HomeShoppingDataManager
{
    private static HomeShoppingDataManager manager = null;

    // Lock object to prevent creating two or more HomeShoppingDatamanager objects.
    private static object syncRoot = new Object();

    // This constructor is private to apply singleton pattern.
    private HomeShoppingDataManager()
    {
    }

    // This method returns HomeShoppingDataManager object.
    // The object is created if it was not created.
    public static HomeShoppingDataManager getInstance()
    {
        lock (syncRoot)
        {
            if (null == manager)
            {
                manager = new HomeShoppingDataManager();
            }
        }

        return manager;
    }

    // Connect to SQL Server DBMS.
    private SqlConnection getSqlConnection()
    {
        return new SqlConnection(ConfigurationManager.ConnectionStrings["DB_CAFE24_NETRANCE"].ConnectionString);
    }

    // Check whether a customer exists in the database using a customer ID.
    public bool checkIfCustomerExists(string customerId)
    {
        bool ifCustomerExists = false;

        // Create SQL command to check if the customer with customerid exists.
        SqlConnection connection = getSqlConnection();
        SqlCommand cmd = new SqlCommand("HS_CheckIfCustomerExists", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@customer_id", customerId);

        // Run the command, and evaluate if the customer exists or not.
        connection.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        if (!rd.Read())
        {
            ifCustomerExists = false;
        }
        else
        {
            ifCustomerExists = true;
        }

        // Close or dispose the used objects.
        rd.Close();
        connection.Close();

        return ifCustomerExists;
    }
}