function validation(email) {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(String(email).toLowerCase());
}

$(document).ready(() => {

    let email = $('#email');
    let password = $('#password');
    let login = $('#login');

    function event(){
        console.log('test');
        if (validation(email.val()) && password.val() !== ''){  // Если формат ввода email правильный и пароль не пустой
            if (login.attr('class').split(' ').includes('disabled')){
                login.removeClass('disabled');
                login.addClass('shadow');
                login.disabled = false;
            }
        } else {  // Есди введенные данные не верные
            if (!login.attr('class').split(' ').includes('disabled')){
                login.addClass('disabled');
                login.removeClass('shadow');
                login.disabled = true;
            }
        }
    }

    email.on('keyup', event);
    password.on('keyup', event);

});
