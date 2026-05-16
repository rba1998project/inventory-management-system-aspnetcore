function showModal(title, message, type) {

    $("#modalTitle").text(title);

    $("#modalMessage").text(message);

    let header = $("#msgModal .modal-header");

    header.removeClass(
        "bg-success bg-danger bg-warning text-white"
    );

    if (!type)
        type = title;

    if (type.toLowerCase() === "success") {
        header.addClass("bg-success text-white");
    }
    else if (type.toLowerCase() === "error") {
        header.addClass("bg-danger text-white");
    }

    var modal = new bootstrap.Modal(
        document.getElementById("msgModal")
    );

    modal.show();
}