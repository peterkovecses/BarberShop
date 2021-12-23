function refreshPage(result) {
    if (result && result.url) {
        if (result.url === "reload") {
            window.location.reload();
        } else {
            window.location.href = result.url;
        }
    }
}
