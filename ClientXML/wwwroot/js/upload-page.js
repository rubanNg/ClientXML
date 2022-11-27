const button = document.querySelector('#uploadFile');
const inputFile = document.querySelector('#inputFile');
const fileInfo = document.querySelector('#fileInfo');
const successInfo = document.querySelector('#successInfo');
const errorInfo = document.querySelector('#errorInfo');
const wrapperContent = document.querySelector('.wrapper-content');


inputFile.addEventListener('change', async function (event) {
    wrapperContent.classList.toggle('is-loading');
    try {
        const file = [...event.target.files].at(0);
        fileInfo.textContent = `Выбранный файл: ${file.name}.`;
        const fileContent = await readFileContent(file);

        const options = {
            fileContent,
            method: 'POST',
            url: 'api/upload-xml-file',
        }

        const response = await sendFileContentToServer(options);

        if (response.success) {
            alert(`Готово !!`);
        }
        else {
            alert(JSON.stringify(response.errors));
        }
    } catch (e) {
        alert(e);
    }
    wrapperContent.classList.toggle('is-loading');
    inputFile.value = '';
});

button.addEventListener('click', function () {
    inputFile.click();
});

async function readFileContent(file) {
    return new Promise((resolve, reject) => {
        var reader = new FileReader();
        reader.onload = function (event) {
            resolve(event.target.result);
        };
        reader.onerror = function () {
            reject({ error: 'FileReader error', event });
        }
        reader.readAsText(file);
    })
}

async function sendFileContentToServer({ fileContent, method, url }) {
    const response = await fetch(url, {
        method,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ content: fileContent }),
    }).then(response => response.json());

    return response;
}