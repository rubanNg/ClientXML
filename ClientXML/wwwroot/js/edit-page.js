const clientForm = document.querySelector('#clientForm');
const sendForm = document.querySelector('#sendForm');


clientForm.addEventListener('submit', async function (event) {

    event.preventDefault();

    const formData = new FormData(clientForm);
    const formValue = Object.fromEntries(formData);

    const response = await sendDataToServer(formValue);

    if (response.success) {
        alert('Успешено!');
        location = "/clients";
    } else alert(JSON.stringify(response.errors));

});


async function sendDataToServer(client) {
    return await fetch('/api/update', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(client),
    }).then(response => response.json());
}