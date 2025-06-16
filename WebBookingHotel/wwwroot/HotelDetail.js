document.addEventListener('DOMContentLoaded', function () {
    const images = document.querySelectorAll('.images-grid img');
    images.forEach(image => {
        image.addEventListener('click', function () {
            const zoomedImage = document.createElement('div');
            zoomedImage.style.position = 'fixed';
            zoomedImage.style.top = '0';
            zoomedImage.style.left = '0';
            zoomedImage.style.width = '100%';
            zoomedImage.style.height = '100%';
            zoomedImage.style.backgroundColor = 'rgba(0, 0, 0, 0.8)';
            zoomedImage.style.display = 'flex';
            zoomedImage.style.justifyContent = 'center';
            zoomedImage.style.alignItems = 'center';
            zoomedImage.style.zIndex = '1000';
            zoomedImage.innerHTML = `<img src="${this.src}" style="max-width: 90%; max-height: 90%;"/>`;

            zoomedImage.addEventListener('click', function () {
                document.body.removeChild(zoomedImage);
            });

            document.body.appendChild(zoomedImage);
        });
    });
});
// click heart

document.addEventListener('DOMContentLoaded', function () {
    const favButton = document.querySelector('.fav-btn');

    favButton.addEventListener('click', function () {
        // Toggle the "active" class to switch between empty and filled heart
        this.classList.toggle('active');
    });
});