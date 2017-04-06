var oTable;
function subjectClass() {
    this.id = "";
    this.name = "";
    this.creditos = "";
    this.set = function (obj) {
        for (var key in obj) {
            this[key] = obj[key];
        }
    }
    this.reset = function () {
        for (var key in this) {
            if (!jQuery.isFunction(this[key])) {
                this[key] = null;
            }
        }
    }
}
var tempSubject = new subjectClass();
function SubjectsLoad() {
    $(document).ready(function () {
        $('#editBtn').hide();
        $('#deleteBtn').hide();
        //var link = "http://localhost:60410/";
        oTable = $('#AsignaturasTable').DataTable({
            responsive: true,
            "ajax": {
                "url": "/api/GetSubjects",
                "dataType": 'json',
                "type": "GET",
                "dataSrc": ""
            },
            "columns": [
                { "data": "id" },
                { "data": "name" },
                { "data": "creditos" },
            ]
        });
        $('#AsignaturasTable tbody').on('click', 'tr', function () {
            console.log(oTable.row(this).data());
            tempSubject.set(oTable.row(this).data());
            $('#deleteBtn').show();
            $('#editBtn').show();
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                oTable.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                
            }
        });
        // Añadir un registro 
        $(document).on("click", "#saveButtn", function () {
            $("#saveButtn").attr("disabled", true);
            var Asignatura =
                  {
                      Id: null,
                      Name: $('#AsignaturaName').val(),
                      Creditos: $('#AsignaturaCreditos').val()
                  };
            $.ajax({
                type: "POST",
                data: JSON.stringify(Asignatura),
                url: "api/Subjects/CreateSubject",
                contentType: "application/json",
                success: function (data) {
                    $("#saveButtn").attr("disabled", false);
                    oTable.ajax.reload();
                }
            });
        });
        // Eliminar un registro 
        $(document).on("click", "#ConfirmDeleteBtn", function () {
            $("#ConfirmDeleteBtn").attr("disabled", true);
            $.ajax({
                type: "DELETE",
                url: "api/Subjects/DeleteSubject/" + tempSubject.id,
                contentType: "application/json",
                success: function (data) {
                    $("#ConfirmDeleteBtn").attr("disabled", false);
                    oTable.ajax.reload();
                    tempSubject.reset();
                    $('#delete').modal('toggle');
                }
            });
        });
        // Editar un registro
        $(document).on("click", "#UpdateRegBtn", function () {
            $("#UpdateRegBtn").attr("disabled", true);
            var Asignatura =
                  {
                      Id: null,
                      Name: $('#AsignaturaNameED').val(),
                      Creditos: $('#AsignaturaCreditosED').val()
                  };
            $.ajax({
                type: "PUT",
                url: "api/Subjects/UpdateSubject/" + tempSubject.id,
                data: JSON.stringify(Asignatura),
                contentType: "application/json",
                success: function (data) {
                    $("#UpdateRegBtn").attr("disabled", false);
                    oTable.ajax.reload();
                    tempSubject.reset();
                    $('#edit').modal('toggle');
                }
            });
        });
        
        $(document).on("click", "#editBtn", function () {
            $('#AsignaturaNameED').val(tempSubject.name);
            $('#AsignaturaCreditosED').val(tempSubject.creditos);
        });
    });
}


