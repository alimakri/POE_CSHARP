// Get the registration <form> element from the DOM.
var form = document.getElementById("registration-form");
var submitButton = form.querySelector("button");
    
// TODO: Task 1 - Get the password <input> elements from the DOM by ID
var passwordInput = document.getElementById("password");
var confirmPasswordInput = document.getElementById("confirm-password");

function checkPasswords() {
    // TODO: Task 2 - Compare passwordInput value to confirmPasswordInput value
    var passwordsMatch = passwordInput.value === confirmPasswordInput.value;
    // TODO: Task 3 - If passwords don't match then display error message on confirmPasswordInput (using setCustomValidity)
    //                If passwords do match then clear the error message (setCustomValidity with empty string)
    if (passwordsMatch) confirmPasswordInput.setCustomValidity("");
    else confirmPasswordInput.setCustomValidity("Your passwords don't match. Please type the same password again.");
    
};

var addPasswordInputEventListeners = function () {
    // TODO: Task 4 - Listen for the "input" event on passwordInput and confirmPasswordInput.
    //       Call the checkPasswords function
    passwordInput.addEventListener("input", checkPasswords, false);
    confirmPasswordInput.addEventListener("input", checkPasswords, false);
};

var formSubmissionAttempted = function() {
    form.classList.add("submission-attempted");
};

var addSubmitClickEventListener = function() {
    submitButton.addEventListener("click", formSubmissionAttempted, false);
};

addPasswordInputEventListeners();
addSubmitClickEventListener();

