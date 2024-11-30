"use strict"

const arrayOfColors = [
    "#F0FFFF", "#FFE4C4", "#F0FFF0", "#FFFFE0", "#FDF5E6", "#DCDCDC", "#F5DEB3", "#FAFAD2"
];
const main = document.getElementById('main');
let currentIndex = 0;

function changeBackgroundColor() {
    main.style.backgroundColor = arrayOfColors[currentIndex];
    currentIndex = (currentIndex + 1) % arrayOfColors.length;
}

setInterval(changeBackgroundColor, 15000);
main.style.backgroundColor = arrayOfColors[currentIndex];