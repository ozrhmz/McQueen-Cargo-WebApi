function filter() {
    var tcNo = $("#txtTcNo").val().toLowerCase(); // Case-insensitive search
    $("#loading").show();
    $("#musteriListesi tr").hide();
    $("#musteriListesi tr td:contains('" + tcNo + "')").parent().show();
    $("#loading").hide();
}