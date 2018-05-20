$(document).ready(() => {

    function event() {
        let self = $(this);
        let id = self.attr('id').split('_')[1];
        $('#good').val(id);
        document.getElementById('add').click();
    }

    $('.buy').on('click', event);

});
