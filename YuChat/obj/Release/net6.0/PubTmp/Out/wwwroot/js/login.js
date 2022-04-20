async function login() {
    let email = document.getElementById('txtLogin').value;
    let pass = document.getElementById('txtPass').value;
    let data = {
        email: email,
        pass: pass
    };

    var response = await fetch('Login/Login',
        {
            body: JSON.stringify(data),
            cache: 'no-cache',
            headers: {
                'content-type': 'application/json'
            },
            method: 'POST'
        });
    alert(await response.text());
    if (response.ok) location.href = '/Chat/ChatRoom';
}

async function register() {
    let email = document.getElementById('txtRegLogin').value;
    let pass = document.getElementById('txtRegPass').value;
    let name = document.getElementById('txtRegName').value;
    let data = {
        email: email,
        pass: pass,
        name: name
    };

    var response = await fetch('Login/Register',
        {
            body: JSON.stringify(data),
            cache: 'no-cache',
            headers: {
                'content-type': 'application/json'
            },
            method: 'POST'
        });
    alert(await response.text());
    if (response.ok) location.href = '/Chat/ChatRoom';
}