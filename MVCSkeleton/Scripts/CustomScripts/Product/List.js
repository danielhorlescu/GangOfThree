var refreshBtn = 'refreshProductsGridData';
var productGrid = 'productsGrid';
var deleteSelected = 'deleteSelected';
var deleteSelectedPath = '/Product/DeleteSelected';

function onChange(e) {
    var gridRows = $('#' + productGrid).data('kendoGrid');
    
    var selectedCells = gridRows.select();

    if (selectedCells.length == 0) {
        $('#' + deleteSelected).addClass('k-state-disabled');
    } else {
        $('#' + deleteSelected).removeClass('k-state-disabled');
    }
}

$(document).ready(function () {
    $('#' + refreshBtn).click(function () {
        $('#' + productGrid).data('kendoGrid').dataSource.read();
    });
    
    $('#' + deleteSelected).click(function (e) {
        if ($(this).attr('class').indexOf('k-state-disabled') !== -1) {
            return;
        }
        var alert = confirm("Are you sure that you want to delete selected Products?");
        if (alert == false) {
            return;
        }

        var gridRows = $('#' + productGrid).data('kendoGrid');
        var items = new Array();

        gridRows.select().each(function () {
            var dataItem = gridRows.dataItem($(this));
            items.push(dataItem);
        });

        $.ajax({
            type: 'POST',
            url: deleteSelectedPath,
            data: JSON.stringify({ selectedProducts: items }),
            dataType: 'html',
            contentType: 'application/json; charset=utf-8'
        }).done(function (data) {
            if (data !== '') {
                onError(data);
            } else {
                $('#' + refreshBtn).trigger('click');
            }
        });
    });
});