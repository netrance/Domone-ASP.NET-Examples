$(document).ready(function () {

});

/*
    This function creates an input JSON object,
    and sends it to the server in order to
    check if a customer data exists.

    Example of input JSON object:
    {
        "header":
        {
            "ip_address": "192.168.0.1",
            "svc_req_name": "check_if_customer_exists"
        },
        "content":
        {
            "customer_id": "first_customer"
        }
    }

    Example of output JSON object:
    {
        "header":
        {
            "svc_res_code": 100
        },
        "content":
        {
            "if_customer_exists": "true"
        }
    }
*/
function checkIfCustomerExists() {
    // Input customer data as JSON object to send to the server.
    var jsonInput = {
        header: {
            ip_address: ip(),
            svc_req_name: 'check_if_customer_exists'
        },
        content: {
            customer_id: $('#input_id').val()
        }
    };

    // To check if the input JSON object was created.
    // alert(JSON.stringify(jsonInput));

    // Send the JSON object to check if the customer exists using an ID.
    $.ajax({
        type: 'POST',
        url: './Ex11_CheckIfCustomerExists.aspx',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(jsonInput),
        success: function (data) {
            // To check if the output JSON object was received.
            // alert(JSON.stringify(data));

            // Notify that the customer exists or not.
            if (data.content.if_customer_exists == true) {
                $('#div_result').html('Result: The customer exists.');
            }
            else {
                $('#div_result').html('Result: The customer does not exist.');
            }
        },
        error: function (request, status, error) {
            alert('Cannot create your account. (Error code: ' + request.status + ')');
        }
    });
}