function saveAsFile(filename, bytesBase64) {
    if (navigator.msSaveBlob) {
        //Download document in Edge browser
        const data = window.atob(bytesBase64);
        const bytes = new Uint8Array(data.length);
        for (let i = 0; i < data.length; i++) {
            bytes[i] = data.charCodeAt(i);
        }
        const blob = new Blob([bytes.buffer], {type: "application/octet-stream"});
        navigator.msSaveBlob(blob, filename);
    } else {
        const link = document.createElement('a');
        link.download = filename;
        link.href = "data:application/octet-stream;base64," + bytesBase64;
        document.body.appendChild(link); // Needed for Firefox
        link.click();
        document.body.removeChild(link);
    }
}

function prettifyAuditJson() {
    let oldJSON = document.getElementById('prettyOldJSONFormat').value;
    let newJSON = document.getElementById('prettyNewJSONFormat').value;

    if (oldJSON == null || oldJSON === "") {
        console.log("oldJSON is null")
    } else {
        let parseOldJSON = JSON.parse(oldJSON);
        document.getElementById('prettyOldJSONFormat').value = JSON.stringify(parseOldJSON, undefined, 4);
    }

    if (newJSON == null || newJSON === "") {
        console.log("newJSON is null")
    } else {
        let parseNewJSON = JSON.parse(newJSON);
        document.getElementById('prettyNewJSONFormat').value = JSON.stringify(parseNewJSON, undefined, 4);
    }
}


function initializeInactivityTimer(dotnetHelper) {
    let timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 600000); // logout after 15 minutes = 900000msec
    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout");
    }
}

function timeOutCall(dotnethelper) {
    document.onmousemove = resetTimeDelay;
    document.onkeypress = resetTimeDelay;

    function resetTimeDelay() {
        dotnethelper.invokeMethodAsync("TimerInterval");
    }
}


function blazorSetTitle(title) {
    document.title = title;
}

function blazorSetDescription(description) {
    let desc = document.querySelector('#description');
    desc.content = description;
}
    