$(document).ready(() => {

    function event() {
        let self = $(this);
        let id = self.attr('id').split('_')[1];
        $('#val').val(id);
        document.getElementById('del').click();
    }

    $('.compl').on('click', event);

});
