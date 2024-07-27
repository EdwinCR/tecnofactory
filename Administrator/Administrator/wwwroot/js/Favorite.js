function RemoveFavorite(id) {

	$.ajax({
		url: '/Home/RemoveFavorite',
		type: 'POST',
		data: { idComic: id },
		dataType: "json",
		success: function (response) {
			if (response.esValido) {
				if (response.mensaje == "Update") {
					Swal.fire({
						icon: "success",
						title: "Eliminado Correctamente.",
						showConfirmButton: false,
						timer: 2000
					});
					$('.card-'+id).remove()
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