$(document).ready(function () {
});

function deleteCustomer() {
    var jsonInput = { customer_id: $('#input_id').val() };

    $.ajax({
        type: 'POST',
        url: './Ex10_DeletingCustomer.aspx',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(jsonInput),
        success: function (data) {
            // Notify that it is successful or not to delete the customer.
            if (data.delete_result == 'success') {
                alert('Deleted your account info successfully.');
            }
            else {
                alert('Cannot delete your account info.');
            }
        },
        error: function (request, status, error) {
            alert('Cannot delete your account info. (Error code: ' + request.status + ')');
        }
    });
}