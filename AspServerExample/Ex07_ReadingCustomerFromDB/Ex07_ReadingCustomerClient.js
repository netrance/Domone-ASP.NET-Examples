$(document).ready(function () {
    // Input data as JSON object to send to the server.
    var jsonInput = { customer_id: 'first_customer' };

    // Send the JSON object with customer ID, and receive its data.
    $.ajax({
        type: 'POST',
        url: './Ex07_ReadingCustomer.aspx',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(jsonInput),
        success: function (data) {
            // Make and show the customer table using the received data.
            addCustomersTo($('#tbody_customer'), data.customers);
            $('#div_result').show();
            $('#div_waiting').hide();
        },
        error: function (request, status, error) {
            $('#div_waiting').html('Cannot load customer table. (Error code: ' + request.status + ')');
        }
    });
});

function addCustomersTo(tableBody, customersAsJsonArray) {
    var tableBodyContent = "";

    for (var i = 0; i < customersAsJsonArray.length; i++) {
        tableBodyContent += "<tr>";

        tableBodyContent += ("<td>" + customersAsJsonArray[i].customer_id + "</td>");
        tableBodyContent += ("<td>" + customersAsJsonArray[i].customer_pw + "</td>");
        tableBodyContent += ("<td>" + customersAsJsonArray[i].customer_name + "</td>");
        tableBodyContent += ("<td>" + customersAsJsonArray[i].customer_mobile + "</td>");
        tableBodyContent += ("<td>" + customersAsJsonArray[i].customer_email + "</td>");

        tableBodyContent += "</tr>";
    }

    tableBody.html(tableBodyContent);
}