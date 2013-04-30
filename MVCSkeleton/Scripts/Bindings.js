$(document).ready(function() {
    $('#refreshProductsGridData').click(function() {
        $('#ProductsGrid').data('kendoGrid').dataSource.read();
    });
});