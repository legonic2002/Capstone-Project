
function inputEmailAddress(event) {
    // Get the pressed key from the event
    var keyPressed = event.key;

    // Allow backspace, delete, arrow keys, home, end, and valid email characters
    if (
        keyPressed === "Backspace" ||
        keyPressed === "Delete" ||
        /^[a-zA-Z0-9@\.\-_]$/.test(keyPressed)
    ) {
        return;
    }

    // Prevent the input of any other keys
    event.preventDefault();
}




function inputNumber(event) {
    // Get the key code of the pressed key
    var keyCode = event.keyCode || event.which;

    // Get the pressed key from the event
    var keyPressed = event.key;

    // Allow key codes for numeric characters (0-9) and numpad keys
    if (
        (keyCode >= 48 && keyCode <= 57) || // Numeric keys (0-9)
        (keyCode >= 96 && keyCode <= 105) || // Numpad keys (0-9)
        keyCode === 8 || // Backspace
        keyCode === 9 // Tab
    ) {
        // Allow the default action for these keys
        return;
    }

    // Prevent the default action for non-numeric key presses
    event.preventDefault();
}

function inputUserName(event) {
    // Get the pressed key from the event
    var keyPressed = event.key;

    // Allow backspace, delete, arrow keys, home, end, and alphanumeric characters
    if (
        keyPressed === "Backspace" ||
        keyPressed === "Delete" ||
        keyPressed === "ArrowLeft" ||
        keyPressed === "ArrowRight" ||
        keyPressed === "Home" ||
        keyPressed === "End" ||
        /^[a-zA-Z0-9_.]$/.test(keyPressed)
    ) {
        return;
    }

    // Prevent the input of any other keys
    event.preventDefault();
}

function inputName(event) {
    // Get the pressed key from the event
    var keyPressed = event.key;

    // Get the Unicode value of the pressed key
    var charCode = event.which || event.keyCode;

    // Allow backspace, delete, arrow keys, home, end, space, Vietnamese characters, and alphabet letters
    if (
        keyPressed === "Backspace" ||
        keyPressed === "Delete" ||
        keyPressed === "ArrowLeft" ||
        keyPressed === "ArrowRight" ||
        keyPressed === "Home" ||
        keyPressed === "End" ||
        keyPressed === " " ||  // Space
        charCode === 32 ||  // Space
        (charCode >= 65 && charCode <= 90) ||  // Uppercase letters
        (charCode >= 97 && charCode <= 122) ||  // Lowercase letters
        (charCode >= 192 && charCode <= 255)  // Vietnamese characters and diacritics
    ) {
        return;
    }

    // Prevent the input of any other keys
    event.preventDefault();
}

