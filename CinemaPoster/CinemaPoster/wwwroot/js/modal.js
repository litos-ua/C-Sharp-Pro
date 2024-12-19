    //document.addEventListener("DOMContentLoaded", function () {
    //    const movieLinks = document.querySelectorAll(".movie-title");

    //    movieLinks.forEach(link => {
    //    link.addEventListener("click", function (event) {
    //        event.preventDefault();
    //        const movieId = this.getAttribute("data-id");

    //        fetch(`/Movies/GetMovieDetails?id=${movieId}`)
    //            .then(response => {
    //                if (response.ok) {
    //                    return response.text();
    //                } else {
    //                    throw new Error("Failed to load movie details.");
    //                }
    //            })
    //            .then(html => {
    //                document.getElementById("modalBody").innerHTML = html;
    //                const modal = new bootstrap.Modal(document.getElementById("movieDetailsModal"));
    //                modal.show();
    //            })
    //            .catch(error => {
    //                console.error(error);
    //                alert("Error loading movie details.");
    //            });
    //    });
    //    });
//});

//document.addEventListener("DOMContentLoaded", function () {
//    const movieLinks = document.querySelectorAll(".movie-title");

//    movieLinks.forEach(link => {
//        link.addEventListener("click", function (e) {
//            e.preventDefault(); // Отключить переход по ссылке

//            const movieId = this.getAttribute("data-id");
//            const modalContent = document.getElementById("movieDetailsContent");

//            // Очистить содержимое перед загрузкой данных
//            modalContent.innerHTML = "Loading...";

//            // Загрузить данные через AJAX
//            fetch(`/movies/details/${movieId}`)
//                .then(response => {
//                    if (!response.ok) {
//                        throw new Error("Failed to load movie details");
//                    }
//                    return response.text();
//                })
//                .then(html => {
//                    modalContent.innerHTML = html; // Вставить данные в модальное окно
//                })
//                .catch(error => {
//                    modalContent.innerHTML = `<div class="alert alert-danger">${error.message}</div>`;
//                });
//        });
//    });
//});

document.addEventListener("DOMContentLoaded", function () {
    const movieLinks = document.querySelectorAll(".movie-title");

    movieLinks.forEach(link => {
        link.addEventListener("click", function (e) {
            e.preventDefault(); // Отключить переход по ссылке

            const movieId = this.getAttribute("data-id");
            const modalContent = document.getElementById("movieDetailsContent");

            if (!modalContent) {
                console.error("Element with id 'movieDetailsContent' not found.");
                return;
            }

            // Очистить содержимое перед загрузкой данных
            modalContent.innerHTML = "Loading...";

            // Загрузить данные через AJAX
            fetch(`/movies/details/${movieId}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error("Failed to load movie details");
                    }
                    return response.text();
                })
                .then(html => {
                    modalContent.innerHTML = html; // Вставить данные в модальное окно
                })
                .catch(error => {
                    modalContent.innerHTML = `<div class="alert alert-danger">${error.message}</div>`;
                });
        });
    });
});




