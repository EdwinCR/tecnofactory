document.addEventListener('DOMContentLoaded', function () {
	$('.group-navbar').remove();
});

function loginUser() {
	const email = $('#Email').val();
	const pass = $('#Password').val();


	if (email == '' || pass == '') {
		Swal.fire({
			title: "¡Atención!",
			text: "Debe escribir un correo ó contraseña.",
			icon: "warning",
			confirmButtonColor: "#0dcaf0"
		});
		return false;
	}

	const data = {
		Email: email,
		Password: pass
	}

	$.ajax({
		url: '/Acces/LoginUser',
		type: 'POST',
		data: data,
		dataType: "json",
		success: function (response) {
			if (response.esValido) {
				if (response.acceso) {
					Swal.fire({
						icon: "success",
						title: "Iniciando Sesión",
						showConfirmButton: false,
						didOpen: () => {
							Swal.showLoading();
						},
					});

					setTimeout(() => {
						window.location.href = '/Home/Index';
					}, 1000);
				}
				else {
					Swal.fire({
						title: "¡Atención!",
						text: "Usuario o contraseña incorrecta.",
						icon: "warning",
						confirmButtonColor: "#0dcaf0"
					});
				}
			}
			else {
				Swal.fire({
					title: "¡Atención!",
					text: response.mensaje,
					icon: "warning",
					confirmButtonColor: "#0dcaf0"
				});
			}
		},
		error: function (xhr, status, error) {
			alert('Error conexión a WebApi.');
		}
	});
}