$(document).ready(function () {
    // Input data as JSON object to send to the server.
    var jsonInput = { dollar: 1 };

    // Send a value as won, and receive another value as dollar.
    $.ajax({
        type: 'POST',
        url: './Ex06_ExchangeServer.aspx', //'http://localhost/HelloWorld.aspx',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(jsonInput),
        success: function (data) {
            document.write('JSON input - ' + jsonInput.dollar + '달러');
            document.write('<br/>');
            document.write('JSON output - ' + data.won + '원');
        },
        error: function (request, status, error) {
            document.write('Error Code: ' + request.status + '<p/>');
            document.write('Message: <br/>')
            document.write(request.responseText + '<p/>');
            document.write('Error:' + error);
        }
    });
});
