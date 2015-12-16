$(document).ready(function () {

});

function createCustomer() {
    // Input customer data as JSON object to send to the server.
    var jsonInput = {
        customer_id: $('#input_id').val(),
        customer_pw: $('#input_password').val(),
        customer_name: $('#input_name').val(),
        customer_mobile: $('#input_mobile').val(),
        customer_email: $('#input_email').val()
    };

    // Send the JSON object to insert the customer data into the database.
    $.ajax({
        type: 'POST',
        url: './Ex08_InsertingCustomer.aspx',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(jsonInput),
        success: function (data) {
            // Notify that it is successful or not to insert the new customer.
            if (data.insert_result == 'success') {
                alert('Created your account successfully.');
            }
            else {
                alert('Cannot create your account.');
            }
        },
        error: function (request, status, error) {
            alert('Cannot create your account. (Error code: ' + request.status + ')');
        }
    });
}