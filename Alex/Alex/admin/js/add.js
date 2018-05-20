$(document).ready(() => {

    let name = $('#name');
    let description = $('#description');
    let price = $('#price');
    let file = $('#file');

    let add = $('#add');

    function event() {
        price.val(price.val().replace(/\D/g,''))
        if (
            name.val() !== '' &&
            description.val() !== '' &&
            price.val() !== '' &&
            file.val() !== ''
        ){
            if (add.attr('class').split(' ').includes('disabled')){
                add.removeClass('disabled');
            }
        } else if (!add.attr('class').split(' ').includes('disabled')){
            add.addClass('disabled');
        }
    }

    name.on('keyup', event);
    description.on('keyup', event);
    price.on('keyup', event);
    file.on('change', event);

});
