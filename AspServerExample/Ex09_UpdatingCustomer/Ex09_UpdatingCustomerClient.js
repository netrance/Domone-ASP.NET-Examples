$(document).ready(function () {
    // Load the customer which ID is 'temp_user'.
    var jsonInput = { customer_id: 'temp_user' };
    $.ajax({
        type: 'POST',
        url: '../Ex07_ReadingCustomerFromDB/Ex07_ReadingCustomer.aspx',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(jsonInput),
        success: function (data) {
            // Fill the customer data into the update form.
            $('#input_id').val(data.customers[0].customer_id);
            $('#input_password').val(data.customers[0].customer_pw);
            $('#input_name').val(data.customers[0].customer_name);
            $('#input_mobile').val(data.customers[0].customer_mobile);
            $('#input_email').val(data.customers[0].customer_email);
        },
        error: function (request, status, error) {
            alert('Cannot load customer table. (Error code: ' + request.status + ')');
        }
    });

});

function updateCustomer() {
    // Input customer data as JSON object to send to the server.
    var jsonInput = {
        customer_id: $('#input_id').val(),
        customer_pw: $('#input_password').val(),
        customer_name: $('#input_name').val(),
        customer_mobile: $('#input_mobile').val(),
        customer_email: $('#input_email').val()
    };

    // Send the JSON object to update the customer data into the database.
    $.ajax({
        type: 'POST',
        url: './Ex09_UpdatingCustomer.aspx',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(jsonInput),
        success: function (data) {
            // Notify that it is successful or not to update the customer.
            if (data.update_result == 'success') {
                alert('Updated your account info successfully.');
            }
            else {
                alert('Cannot update your account info.');
            }
        },
        error: function (request, status, error) {
            alert('Cannot update your account info. (Error code: ' + request.status + ')');
        }
    });
}