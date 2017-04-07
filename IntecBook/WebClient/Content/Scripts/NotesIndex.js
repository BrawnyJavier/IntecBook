var oTable;
function NotesClass() {
    this.id = "";
    this.subject = "";
    this.subjectId = "";
    this.title = "";
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
var tempNote = new NotesClass();
function NotesLoad() {
    $(document).ready(function () {
        $('#editBtn,#seeBtn').hide();
        $('#deleteBtn').hide();
        //var link = "http://localhost:60410/";
        oTable = $('#AsignaturasTable').DataTable({
            responsive: true,
            "ajax": {
                "url": "/api/Notas/GetNotes/",
                "dataType": 'json',
                "type": "GET",
                "dataSrc": ""
            },
            "columns": [
                { "data": "id" },
                { "data": "title" },
               { "data": "subject" }

            ]
        });
        $('#AsignaturasTable tbody').on('click', 'tr', function () {
            console.log(oTable.row(this).data());
            tempNote.set(oTable.row(this).data());
            $('#deleteBtn,#seeBtn,#seeBtn').show();
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
        //$(document).on("click", "#saveButtn", function () {
        //    $("#saveButtn").attr("disabled", true);
        //    var Asignatura =
        //          {
        //              Id: null,
        //              Name: $('#AsignaturaName').val(),
        //              Creditos: $('#AsignaturaCreditos').val()
        //          };
        //    $.ajax({
        //        type: "POST",
        //        data: JSON.stringify(Asignatura),
        //        url: "api/Subjects/CreateSubject",
        //        contentType: "application/json",
        //        success: function (data) {
        //            $("#saveButtn").attr("disabled", false);
        //            oTable.ajax.reload();
        //        }
        //    });
        //});
        $(document).on("click", "#createBtns", function () {
            $("#AjaxLoads").load("/Html/NotesEditor.html", function () {
                MasterLoad();
            });
        });
        $(document).on("click", "#editBtn", function () {
            $("#AjaxLoads").load("/Html/NotesEditor.html", function () {
                var id = tempNote.id;
                console.log(id);
                MasterLoad(id);
            });
        });
        // Eliminar un registro 
        $(document).on("click", "#ConfirmDeleteBtn", function () {
            $("#ConfirmDeleteBtn").attr("disabled", true);
            $.ajax({
                type: "DELETE",
                url: "api/Notas/DeleteNote/" + tempNote.id,
                contentType: "application/json",
                success: function (data) {
                    $("#ConfirmDeleteBtn").attr("disabled", false);
                    oTable.ajax.reload();
                    tempNote.reset();
                    $('#delete').modal('toggle');
                }
            });
        });
        //// Editar un registro
        //$(document).on("click", "#UpdateRegBtn", function () {
        //    $("#UpdateRegBtn").attr("disabled", true);
        //    var Asignatura =
        //          {
        //              Id: null,
        //              Name: $('#AsignaturaNameED').val(),
        //              Creditos: $('#AsignaturaCreditosED').val()
        //          };
        //    $.ajax({
        //        type: "PUT",
        //        url: "api/Subjects/UpdateSubject/" + tempNote.id,
        //        data: JSON.stringify(Asignatura),
        //        contentType: "application/json",
        //        success: function (data) {
        //            $("#UpdateRegBtn").attr("disabled", false);
        //            oTable.ajax.reload();
        //            tempNote.reset();
        //            $('#edit').modal('toggle');
        //        }
        //    });
        //});
        $(document).on("click", "#editBtn", function () {
            $('#AsignaturaNameED').val(tempNote.name);
            $('#AsignaturaCreditosED').val(tempNote.creditos);
        });
        $(document).on("click", "#seeBtn", function () {
            $("#AjaxLoads").load("/Html/NotesDetail.html", function () {
                NotesDetailLoad(tempNote.id);
            });
        });
    });
}


