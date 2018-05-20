$(document).ready(() => {

    let price = $('.price');

    function event(e) {
        let field = $(this);
        field.val(field.val().replace(/\D/g,''))
    }

    price.on('keyup', event);

    let save = $('.save');

    function saveEvent() {
        let self = $(this)
        let id = self.attr('id').split('-')[1];

        $('#id').val(id.split('_')[1]);
        $('#name').val($('#name' + id).val());
        $('#description').val($('#desc' + id).val());
        $('#price').val($('#price' + id).val());

        document.getElementById('s').click();

    }

    save.on('click', saveEvent);

});
