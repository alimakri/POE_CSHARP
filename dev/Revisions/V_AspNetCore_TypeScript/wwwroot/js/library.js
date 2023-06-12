var jqtest = {
    showMsg: function () {
        var v = jQuery.fn.jquery.toString();
        var content = $('#ts-example2')[0].innerHTML;
        alert(content.toString());
        $('#ts-example2')[0].innerHTML = content + " " + v + "!!";
    }
};
jqtest.showMsg();
//# sourceMappingURL=library.js.map