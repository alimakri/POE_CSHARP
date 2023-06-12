var jqtest = {
    showMsg: function (): void {
        let v: any = jQuery.fn.jquery.toString(); 
        let content: any = $('#ts-example2')[0].innerHTML;        
        $('#ts-example2')[0].innerHTML = content + " " + v + "!!";
    }
};
jqtest.showMsg();