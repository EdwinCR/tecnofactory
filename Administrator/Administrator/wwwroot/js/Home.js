function AddFavorite(id) {

	$.ajax({
		url: '/Home/AddFavorite',
		type: 'POST',
		data: { idComic: id },
		dataType: "json",
		success: function (response) {
			if (response.esValido) {
				if (response.mensaje == "Add" || response.mensaje == "Update") {
					Swal.fire({
						icon: "success",
						title: "Agregado Correctamente.",
						showConfirmButton: false,
						timer: 2000
					});
				}
				else {
					Swal.fire({
						title: "¡Atención!",
						text: "Ya se encuentra en la lista de favoritos.",
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
			alert('Error al subir el archivo.');
		}
	});
}