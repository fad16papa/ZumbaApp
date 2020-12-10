//Javascript to Display the error message and display the proper ErrorHeader and ErrorBody
function DisplayErrorModal(errorHeader, errorBody) {

    document.getElementById("errorHeaderLabel").textContent = errorHeader;
    document.getElementById("errorBodyLabel").textContent = errorBody;

    $('#errorModal').modal("show");

};

//Javascript to Display the Success message and display the proper SuccessHeader and SuccessBody
function DisplaySuccessModal(successHeader, successBody) {

    document.getElementById("successHeaderLabel").textContent = successHeader;
    document.getElementById("successBodyLabel").textContent = successBody;

    $('#successModal').modal("show");
};