/**
 * Отправка AJAX-запроса для создания или редактирования заметки.
 * @param {string} url - URL для отправки данных.
 * @param {object} formData - Данные формы.
 * @param {string} redirectUrl - URL для переадресации при успехе.
 */
async function submitNoteForm(url, formData, redirectUrl) {
    console.log("Submitting to:", url);
    console.log("FormData (as object):", formData);
    console.log("Request Body (JSON):", JSON.stringify(formData));
    try {
        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(formData)
        })

        console.log("Response status:", response.status);

        const result = await response.json();
        console.log("Response JSON:", result);
        

        if (result.success) {
            // Успешное выполнение
            alert(result.message); // Вы можете заменить на SweetAlert, если нужно
            if (redirectUrl) {
                window.location.href = redirectUrl;
            }
        } else {
            // Ошибка
            alert(result.message); // Вы можете заменить на SweetAlert, если нужно
        }
    } catch (error) {
        console.error("Error:", error);
        alert("An unexpected error occurred.");
    }
}

/**
 * Инициализация обработки формы.
 * @param {string} formId - ID формы.
 * @param {string} actionUrl - URL для обработки формы.
 * @param {string} redirectUrl - URL для переадресации при успехе.
 */
function initializeNoteForm(formId, actionUrl, redirectUrl) {
    const form = document.getElementById(formId);
    if (form) {
        form.addEventListener("submit", function (e) {
            e.preventDefault(); // Отключаем стандартное поведение формы

            const formData = {
                Id: form.dataset.id || null,
                Title: document.getElementById("Title").value,
                Tags: document.getElementById("Tags").value,
                Content: document.getElementById("Content").value,
                ContactId: document.getElementById("ContactId").value
            };

            //console.log(actionUrl, formData, redirectUrl);



            submitNoteForm(actionUrl, formData, redirectUrl);
        });
    }
}
