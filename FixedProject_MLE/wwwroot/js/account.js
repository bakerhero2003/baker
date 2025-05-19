function showError(message) {
    const errorDiv = document.createElement('div');
    errorDiv.className = 'error-message';
    errorDiv.textContent = `Erreur : ${message}`;
    errorDiv.style.color = 'red';
    errorDiv.style.marginTop = '10px';

    const forms = document.querySelectorAll('.form-box');
    forms.forEach(form => {
        const existingError = form.querySelector('.error-message');
        if (existingError) existingError.remove();
        form.appendChild(errorDiv.cloneNode(true));
    });
}
