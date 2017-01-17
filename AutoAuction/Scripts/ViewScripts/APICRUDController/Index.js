$(document).ready(function () {  
    var table = $("#customerLots").DataTable({
        "autoWidth":false,
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
        ajax: {
            url: "/api/APICRUD/",
            type: 'GET',
            dataType: 'json',
            dataSrc: ""
        },
        columnDefs: [
                    { "width": "2000px", "targets": [4] },
            { "width": "2000px", "targets": [5] }
        ],
        columns: [
            {
                data: "LotName"
            },
            {
                data: "LotImageUrl",
                render: function (data) {
                    return '<img src="' + data + '" style="height:auto;width:120px;"/>';
                }
            },
            {
                data:
                    "StarLotSaleDate",
                render: function (data) {
                    return setData(data);
                }

            },
            {
                data:
                    "EndLotSaleDate",
                render: function (data) {
                    return setData(data);
                }
            },
            {
                data: "CurrentPrice",
                render: function (data) {
                    return data + ' $';
                }
            },
            {
                data: null,
                render: function(data) {
                    if ((!data.IsSold) && (data.LotMaker)) {
                        return "Это ваш лот";
                    }
                    if ((data.IsSold) && (data.LotMaker)) {
                        return "Ваш лот продан";
                    }
                    if ((data.IsSold) && (!data.LotMaker)) {
                        return data.CustomerBet + ' $ ';
                    }
                    return data.CustomerBet + ' $       '
                        + "<img class='UpCustomerBet' data-UpdatePrice-Id="
                        + data.LotId +
                        " src='/Content/Icons/arrow_up.png' style='cursor:pointer;'/>";
                }
            },
            {
                data: null,
                render: function(data) {
                    if (data.LotMaker) {
                        if (data.IsSold) {
                            return "Ваш лот продан";
                        }
                        return "Это ваш Лот";
                    } else {
                        if ((data.IsSold) && (!data.LotMaker)) {
                            return "";
                        }
                        return "<button class='btn btn-danger js-delete' data-customerLots-Id="
                            + data.LotId + ">Удалить ставку</button>";
                    }
                }
            },
            {
                data: null,
                render: function(data) {
                    if (data.IsSold)
                        return "Продан";
                    return "Не продан";
                }
            },
            {
                data: null,
                render: function (data) {
                    if (data.IsSold) {
                        if (data.WinAuction)
                            return "Вы владелец";
                        return "Не вы владелец";
                    }
                    return "Нет владельца";                   
                }
            }
        ]
    });
    function setData(data) {
        return (data.substr(8, 2) + "/" + data.substr(5, 2) + "/" + data.substr(0, 4));
    }
    //Up the price
    $("#customerLots").on("click", ".UpCustomerBet", function () {
        var img = $(this);
        $.ajax({
            url: "/api/APICRUD/" + img.attr("data-UpdatePrice-Id"),
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                if (data.IsSold) {
                    bootbox.alert("Лот уже продан");
                } else {
                    bootbox.prompt({
                        title: "Введите новую ставку",
                        value: data.CurrentPrice,
                        callback: function (result) {
                            if (result === null) {
                                bootbox.alert("Введите корректную цену");
                            } else {
                                if (result <= data.CurrentPrice)
                                    bootbox.alert("Цена должна быть больше текущей");
                                else {
                                    var updateCurrentPrice = {
                                        LotId:data.LotId,
                                        CustomerBet: result
                                    }
                                    $.ajax({
                                        url: '/api/APICRUD/',
                                        type: 'PUT',
                                        data: JSON.stringify(updateCurrentPrice),
                                        contentType: "application/json;charset=utf-8",
                                        success: function (data, status) {
                                            window.location = '/Customer';                                           
                                        },
                                        error: function(jxqr, error, status) {
                                            //
                                            var response = jQuery.parseJSON(jxqr.responseText);
                                            $('#errors').empty();
                                            $('#errors').append("<h2>" + "Ошибка Лота" + "</h2>");
                                            //Lot.IsSold error
                                            if (response['ModelState']['acLot.Lot.IsSold']) {

                                                $.each(response['ModelState']['acLot.Lot.IsSold'], function(index, item) {
                                                    $('#errors').append("<p>" + item + "</p>");
                                                });
                                            }
                                        }
                                    });
                                }
                            }
                        }
                    });

                }
            }
        });
    });
    //delete Lot
    $("#customerLots").on("click", ".js-delete", function () {      
        var button = $(this);
        bootbox.confirm("Вы действительно хотите удалить свою ставку?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/APICRUD/" + button.attr("data-customerLots-Id"),
                    type: 'DELETE',
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
    //Select by row
    $('#customerLots tbody').on('click', 'tr', function () {    
        var data = table.row(this).data();
        if ((data != null) && (!data.IsSold) && (data.LotMaker)) {         
            window.location = '/CRUD/UpdateLot/' + data.LotId;          
        }
    });
    //Button
    $("#AddNewLot").click(function () {
        window.location = '/CRUD/AddNewLot/';

    });
    $("#CustomerLots").click(function () {
        window.location = '/CRUD';
    });
});