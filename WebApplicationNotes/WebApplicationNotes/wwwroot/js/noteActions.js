/**
 * Отправка запроса c formData
 * @param {string} url 
 * @param {object} formData 
 * @param {string} redirectUrl 
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
            alert(result.message); 
            if (redirectUrl) {
                window.location.href = redirectUrl;
            }
        } else {
            alert(result.message); 
        }
    } catch (error) {
        console.error("Error:", error);
        alert("An unexpected error occurred.");
    }
}

/**
 * Инициализация формы.
 * @param {string} formId 
 * @param {string} actionUrl 
 * @param {string} redirectUrl 
 */
function initializeNoteForm(formId, actionUrl, redirectUrl) {
    const form = document.getElementById(formId);
    if (form) {
        form.addEventListener("submit", function (e) {
            e.preventDefault(); 

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
