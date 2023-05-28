//Person
$(document).ready(function () {
    $('.js-delete-persons').on('click', function () {
        var btn = $(this);
        bootbox.confirm({
            message: "Are You Sure To Delete this Person?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-outline-secondary'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({
                        url: '/persons/delete/' + btn.data('id'),
                        success: function () {
                            var personsContainer = btn.parents('.tbl');
                            personsContainer.addClass('animate__animated animate__zoomOut');
                            setTimeout(function () {
                                storeContainer.remove();
                            }, 500);
                            toastr.success('Person Deleted Successfully');
                        },
                        error: function () {
                            toastr.error('Wrong Occure!');
                        }
                    });
                }
            }
        });
    });
});

//Data Table
$(document).ready(function () {
    var table = $('#datatable').DataTable({
        responsive: true,
    });
    new $.fn.dataTable.FixedHeader(table);
});