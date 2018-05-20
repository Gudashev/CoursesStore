function validation(email) {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(String(email).toLowerCase());
}

$(document).ready(() => {

    let name = $('#name');
    let last_name = $('#last_name');
    let patronymic = $('#patronymic');  // Отчество
    let email = $('#email');
    let password = $('#password');

    let registration = $('#registration');

    function event() {
        if (
            name.val() != '' &&  // Если имя введено
            last_name.val() != '' &&  // Если фамилия введена
            patronymic.val() != '' &&  // Если отчество введено
            validation(email.val())  &&  // Если формат email'a соблюден
            password.val() != ''  // Если пароль введен
        ){
            if (registration.attr('class').split(' ').includes('disabled')){
                registration.removeClass('disabled');
                registration.addClass('shadow');
                registration.disabled = false;
            }
        } else {
            if (!registration.attr('class').split(' ').includes('disabled')){
                registration.addClass('disabled');
                registration.removeClass('shadow');
                disabled.disabled = true;
            }
        }
    }

    name.on('keyup', event);
    last_name.on('keyup', event);
    patronymic.on('keyup', event);
    email.on('keyup', event);
    password.on('keyup', event);

});
