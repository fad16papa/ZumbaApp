$(document).ready(function () {
    // This will run the spinner when the user click the save button in UserSettingIndex
    $("#btnUpdateUser").click(function () {
        // add spinner to button
        $(this).html(
            `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...`
        );
    });

    // This will run the spinner when the user click the register button in RegisterPage
    $("#btnRegisterUser").click(function () {
        // add spinner to button
        $(this).html(
            `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...`
        );
    });

    // This will run the spinner when the user click the register button in RegisterPage
    $("#btnUploadUserPhoto").click(function () {
        // add spinner to button
        $(this).html(
            `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...`
        );
    });
});
