// Get the registration <form> element from the DOM.
var form = document.getElementById("registration-form");
var submitButton = form.querySelector("button");
    
// TODO: Get the password <input> elements from the DOM by ID
// var passwordInput = ...;
// var confirmPasswordInput = ...;

var checkPasswords = function () {
    // TODO: Compare passwordInput value to confirmPasswordInput value

    // TODO: If passwords don't match then display error message on confirmPasswordInput (using setCustomValidity)

    // TODO: If passwords do match then clear the error message (setCustomValidity with empty string)
};

var addPasswordInputEventListeners = function () {
    // TODO: Listen for the "input" event on passwordInput and confirmPasswordInput.
    //       Call the checkPasswords function
};

var formSubmissionAttempted = function() {
    form.classList.add("submission-attempted");
};

var addSubmitClickEventListener = function() {
    submitButton.addEventListener("click", formSubmissionAttempted, false);
};

addPasswordInputEventListeners();
addSubmitClickEventListener();
