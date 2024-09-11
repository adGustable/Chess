"use strict";

/**
 * Validates the names of two players if validation is enabled.
 */
function validateForm() {
    // Get the checkbox element
    var enableValidation = document.getElementById('EnableValidation').checked;

    // Get player names from input fields
    var whitePlayer = document.getElementById('WhitePlayerName').value;
    var blackPlayer = document.getElementById('BlackPlayerName').value;

    // If validation is enabled, perform the validation
    if (enableValidation) {
        if (!whitePlayer || !blackPlayer) {
            showReturnMessage("Both player names must be filled.");
            return false;
        }
        if (whitePlayer === blackPlayer) {
            showReturnMessage("Players cannot have the same name.");
            return false;
        }

        // Redirect to another page if validation passes
        window.location.href = "C:\Users\faber\OneDrive\Documents\GitHub\Chess\ChessUI\MainWindow.xaml"; // Change to the URL of your main window
        return true;
    } else {
        // Redirect to another page if validation is not enabled
        window.location.href = "C:\Users\faber\OneDrive\Documents\GitHub\Chess\ChessUI\MainWindow.xaml"; // Change to the URL of the alternative page
        return true;
    }
}

/**
 * Displays a message in the return message div.
 * @param {string} message - The message to display.
 */
function showReturnMessage(message) {
    var returnMessageDiv = document.getElementById('ReturnMessage');
    if (returnMessageDiv) {
        returnMessageDiv.innerText = message;
        returnMessageDiv.style.display = 'block';
    }
}
