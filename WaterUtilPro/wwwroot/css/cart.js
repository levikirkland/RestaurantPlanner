var cartModal = document.getElementById('cartModal')
cartModal.addEventListener('show.bs.modal', function (event) {

    var button = event.relatedTarget

    var id = button.getAttribute('data-bs-id')
    var name = button.getAttribute('data-bs-name')

    var modalBodyInput = cartModal.querySelector('.modal-body input')

    modalBodyInput.value = id + ' ' + name
});