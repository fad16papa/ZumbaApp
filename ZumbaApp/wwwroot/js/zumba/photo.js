function UploadPhotoModal() {
    //DIV placeholder for the Modal
    var placeholderElement = $('#ModalPlaceholder');

    $.ajax({
        method: 'GET',
        url: "/Photos/UplaodUserPhoto",

    }).done(function (data, statusText, xhdr) {
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
    }).fail(function (xhdr, statusText, errorText) {

        let errorHeader = "System Error!";
        let errorBody = "Error! \nPlease contact administrator.";

        //function calln to display the Error Message
        DisplayErrorModal(errorHeader, errorBody);
    });
}
