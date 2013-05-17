function onError(e) {
    console.log(e.errors);
    alert('An error occured!');
    e.sender.cancelChanges();
}

function onDataBound(e) {
    var grid = e.sender;
    grid.element.find("tr[role='row']").each(function () {
        var dataItem = grid.dataItem(this);
        $(this).attr('data-id', dataItem.Id);
    });
}