let dataFunc

function addRowDT(data) {
    dataFunc = data
    var tabla = $('#tbl_pacientes').DataTable();
    for (var i = 0; i < data.length; i++) {
        tabla.row.add([
            data[i].IdPaciente,
            data[i].Nombres,
            (data[i].ApPaterno + " " + data[i].ApMaterno),
            ((data[i].Sexo == 'M') ? "Masculino" : "Femenino"),
            data[i].Edad,
            data[i].Direccion,
            ((data[i].Estado == true) ? "Activo" : "Inactivo"),
            `<button value="Actualizar" title="Actualizar" data-id=${data[i].IdPaciente} data-target="#imodal" data-toggle="modal" class="btn btn-primary btn-edit"><i class="far fa-edit"></i></button>&nbsp; ` +
            `<button value="Eliminar" title="Eliminar" data-id=${data[i].IdPaciente} class="btn btn-danger btn-delete"><i class="far fa-trash-alt"></i></button>`

        ]).draw(false);
    }
}

function sendDataAjax(url, params, cb, type, ) {
    $.ajax({
        type: type,
        url: url,
        data: params,
        contentType: "application/json; charset= utf-8",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            cb(data.d);
        }
    })
}

window.onload = function () {
    sendDataAjax('GestionPaciente.aspx/ListarPaciente', {}, addRowDT, "POST");

    //Evento click para boton editar
    $(document).on('click', '.btn-edit', function (e) {
        e.preventDefault();
        let id = parseInt($(this).attr('data-id'));
        let data = $(this).parent().parent().children();
        fillModalData(data);
        var obj = JSON.stringify({ id: JSON.stringify(id), direccion: $("#txtAddress").val() });
        updatePaciente(obj);
    });

    //Evento click para boton eliminar
    $(document).on('click', '.btn-delete', function (e) {
        e.preventDefault();
        Swal.fire({
            title: 'Eliminar Paciente',
            text: '¿Seguro que desea eliminar paciente?',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, eliminar'
        }).then((result) => {
            if (result.value) {
                Swal.fire(
                    'Eliminado!',
                    'Paciente Eliminado.',
                    'success'
                )
            }
        })
        console.log(parseInt($(this).attr('data-id')));
    });

    //Enviar datos al servidor
    

}

//Cargar datos en el modal
function fillModalData(data)
{
    $('#txtNames').val(data[1].innerHTML);
    $('#txtLastNames').val(data[2].innerHTML);
    $('#txtAddress').val(data[5].innerHTML);
}

function updateAjax(type, url, params)
{
    $.ajax({
        type: type,
        url: url,
        data: params,
        dataType: "json",
        contentType: "application/json; charset= utf-8",
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            console.log(response);
        }
    })
}

function updatePaciente(obj)
{
    $("#btnActualizar").click(function (e)
    {
        e.preventDefault();
        updateAjax("POST", "GestionPaciente.aspx/ObtenerPaciente", obj);
    });
}



