$(document).ready(function () {
    var table = $("#table").DataTable({
        "oLanguage": {
            "sLengthMenu": "Показать _MENU_ записей на странице",
            "sZeroRecords": "Извините - ничего не найдено",
            "sInfo": "Показано _START_ до _END_ из _TOTAL_ записей",
            "sInfoEmpty": "Нет записей",
            "sInfoFiltered": "(из _MAX_ записей)",
            "sSearch": "Поиск:",
            "oPaginate": {
                "sNext": "След. стр.",
                "sPrevious": "Пред. стр."
            }
        },
        "columnDefs": [
            {
                'visible': false,
                'targets': [0]
            }
        ]
    });
    $('#table tbody').on('click', 'tr', function () {
        var data = table.row(this).data();      
        var lotId = data.toString().substr(0, data.toString().indexOf(','));      
        $.ajax({
            url: "/api/APICRUD/" + lotId,
            type: 'GET',
            dataType: 'json',
            success: function (data) {              
                if (data.LotMaker) {
                    window.location = '/CRUD/UpdateLot/' + lotId;
                }              
            }
        });
        window.location = '/CRUD/AddCustomerToLot/' + lotId;
    });
    $("#CustomerLots").click(function () {
        window.location = '/Customer';
    });
    $("#UpdateLots").click(function () {
        location.reload();
    });
});