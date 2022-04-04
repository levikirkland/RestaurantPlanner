var demo1 = $('select[name="duallistbox_demo1[]"]').bootstrapDualListbox({
    nonSelectedListLabel: 'Available Payees',
    selectedListLabel: 'Selected Payees',
    preserveSelectionOnMove: 'moved',
    moveAllLabel: 'Move all',
    removeAllLabel: 'Remove all'
});
$("#demoform").submit(function () {
    alert($('[name="duallistbox_demo1[]"]').val());
    return false;
});