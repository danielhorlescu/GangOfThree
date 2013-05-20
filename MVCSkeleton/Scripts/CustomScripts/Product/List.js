var refreshBtn = 'refreshProductsGridData';
var productGrid = 'productsGrid';
var deleteSelected = 'deleteSelected';
var deleteSelectedPath = '/Product/DeleteSelected';

$(document).ready(function () {
    $('#' + refreshBtn).click(function () {
        $('#' + productGrid).data('kendoGrid').dataSource.read();
    });
    
    $('#' + 'deleteSelected').click(function () {
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
        });
    });
});