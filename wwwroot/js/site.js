// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("#loader-wrapper").hide();

    $(document).bind('ajaxStart', function () {
        $("#loader-wrapper").show();
    }).bind('ajaxStop', function () {
        $("#loader-wrapper").hide();
    });
});



showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#form_modal .modal-body').html(res);
            $('#form_modal .modal-title').html(title);
            $('#form_modal').modal('show');
            
        }
    });
}

jQueryAjaxPost = (form) => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html);
                    $('#form_modal .modal-body').html('');
                    $('#form_modal .modal-title').html('');
                    $('#form_modal').modal('hide');
                    $.notify('Opération effectuée avec succès.', { globalPosition: 'top center', className: 'success' });
                } else {
                    $('#form_modal .modal-body').html(res.html);
                }
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
    
}

jQueryAjaxDelete = (form, message) => {
    if (confirm('Êtes-vous sûr de vouloir supprimer cet enregistrement ?')) {
        try {

            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
               
                success: function (res) {
                    $('#view-all').html(res.html);
                    $('#form_modal .modal-title').html('');
                    $('#form_modal .modal-body').html('');
                    $('#form_modal').modal('hide');
                    $.notify(message, { globalPosition: 'top center', className:'success' });
                },
                error: function (err) {
                    console.error("Erreur AJAX :", err);
                }
            });
        } catch (ex) {
            console.error("Exception JS :", ex);
        }
    }

    return false; 
}
