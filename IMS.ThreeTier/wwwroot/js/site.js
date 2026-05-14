function showModal(title, message, type = "success") {

    $("#modalTitle").text(title);

    $("#modalMessage").text(message);

    let header = $("#msgModal .modal-header");

    header.removeClass(
        "bg-success bg-danger bg-warning text-white"
    );

    if (type === "success") {
        header.addClass("bg-success text-white");
    }
    else if (type === "error") {
        header.addClass("bg-danger text-white");
    }

    var modal = new bootstrap.Modal(
        document.getElementById("msgModal")
    );

    modal.show();
}