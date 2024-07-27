function registerUser() {
	const email = $('#Email').val();
	const pass = $('#Password').val();
	const userName = $('#UserName').val();
	const docNumber = $('#DocNumber').val();


	if (email == '' || pass == '' || userName == '' || docNumber == '') {
		Swal.fire({
			title: "¡Atención!",
			text: "Debe llenar todos los campos para completar el registro.",
			icon: "warning",
			confirmButtonColor: "#0dcaf0"
		});
		return false;
	}

	const data = {
		Email: email,
		Password: pass,
		UserName: userName,
		DocNumber: docNumber,
	}

	$.ajax({
		url: '/Acces/RegisterUser',
		type: 'POST',
		data: data,
		dataType: "json",
		success: function (response) {
			if (response.esValido) {
				if (response.mensaje == "Add") {
					Swal.fire({
						icon: "success",
						title: "Registrado Correctamente.",
						showConfirmButton: false,
						timer: 2000
					});

					setTimeout(() => {
						window.location.href = '/Acces/LoginUser';
					}, 3000);
				}
				else {
					Swal.fire({
						title: "¡Atención!",
						text: "El usuario ya existe.",
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