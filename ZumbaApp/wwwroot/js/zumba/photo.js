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

function UploadPhoto() {

    var formData = new FormData($(this)[0]);

    console.log(formData);

    $.ajax({
        method: 'POST',
        url: "/Photos/UplaodUserPhoto",
        data: formData,
    }).done(function (data) {

        var newBody = $('.modal-body', data);
        var placeholderElement = $('#ModalPlaceholder');
        placeholderElement.find('.modal-body').replaceWith(newBody);

        // find IsValid input field and check it's value
        // if it's valid then hide modal window
        var isValid = newBody.find('[name="IsValid"]').val() == 'True';
        // if (isValid) {
        //     placeholderElement.find('.modal').modal('hide');

        //     let successHeader = "User Action!";
        //     let successBody = "New asset has been created!";

        //     //function call to display the Error Message
        //     DisplaySuccessModal(successHeader, successBody);

        //     //function call
        //     viewAssets();
        // }
    }).fail(function () {

        // let errorHeader = "System Error!";
        // let errorBody = "Error! \nPlease contact administrator.";

        // //function calln to display the Error Message
        // DisplayErrorModal(errorHeader, errorBody);
    });
}

function UploadBlogPhotoModal() {
    //DIV placeholder for the Modal
    var placeholderElement = $('#ModalPlaceholder');

    $.ajax({
        method: 'GET',
        url: "/BlogPhotos/UploadBlogPhoto",

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

function UploadBlogPhoto() {

    var formData = new FormData($(this)[0]);

    console.log(formData);

    $.ajax({
        method: 'POST',
        url: "/BlogPhotos/UploadBlogPhoto",
        data: formData,
    }).done(function (data) {

        var newBody = $('.modal-body', data);
        var placeholderElement = $('#ModalPlaceholder');
        placeholderElement.find('.modal-body').replaceWith(newBody);

        // find IsValid input field and check it's value
        // if it's valid then hide modal window
        var isValid = newBody.find('[name="IsValid"]').val() == 'True';
        // if (isValid) {
        //     placeholderElement.find('.modal').modal('hide');

        //     let successHeader = "User Action!";
        //     let successBody = "New asset has been created!";

        //     //function call to display the Error Message
        //     DisplaySuccessModal(successHeader, successBody);

        //     //function call
        //     viewAssets();
        // }
    }).fail(function () {

        // let errorHeader = "System Error!";
        // let errorBody = "Error! \nPlease contact administrator.";

        // //function calln to display the Error Message
        // DisplayErrorModal(errorHeader, errorBody);
    });
}