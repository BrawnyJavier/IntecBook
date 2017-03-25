var oTable;
function PeriodoClass() {
    this.id = "";
    this.trimestre = "";
    this.user = "";
    this.year = "";
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
var tempPeriodo = new PeriodoClass();
function MasterLoad() {
    $(document).ready(function () {
        $('#editBtn,#seeRegs,#deleteBtn').hide();
        //  $('#deleteBtn').hide();
        oTable = $('#SchedulesTable').DataTable({
            responsive: true,
            "ajax": {
                "url": "/api/Trimestres",
                "dataType": 'json',
                "type": "GET",
                "dataSrc": ""
            },
            "columns": [
                { "data": "id" },
                   { "data": "year" },
                { "data": "trimestre" }
            ]
        });
        $('#SchedulesTable tbody').on('click', 'tr', function () {
            console.log(oTable.row(this).data());
            tempPeriodo.set(oTable.row(this).data());
            $('#deleteBtn,#seeRegs').show();
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
            var Periodo =
                  {
                      Id: null,
                      Trimestre: $('#AsignaturaCreditos').val(),
                      Year: $('#AsignaturaName').val(),
                      User: null
                  };
            $.ajax({
                type: "POST",
                data: JSON.stringify(Periodo),
                url: "api/Trimestres",
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
                url: "api/Trimestres/" + tempPeriodo.id,
                contentType: "application/json",
                success: function (data) {
                    $("#ConfirmDeleteBtn").attr("disabled", false);
                    oTable.ajax.reload();
                    tempPeriodo.reset();
                    $('#delete').modal('toggle');
                }
            });
        });
        // Editar un registro
        $(document).on("click", "#UpdateRegBtn", function () {
            $("#UpdateRegBtn").attr("disabled", true);
            var Periodo =
                  {

                      Id: tempPeriodo.id,
                      Trimestre: $('#AsignaturaCreditosED').val(),
                      User: tempPeriodo.user,
                      Year: $('#AsignaturaNameED').val()
                  };
            $.ajax({
                type: "PUT",
                url: "api/Trimestres/" + tempPeriodo.id,
                data: JSON.stringify(Periodo),
                contentType: "application/json",
                success: function (data) {
                    $("#UpdateRegBtn").attr("disabled", false);
                    oTable.ajax.reload();
                    tempPeriodo.reset();
                    $('#edit').modal('toggle');
                }
            });
        });

        $(document).on("click", "#editBtn", function () {
            $('#AsignaturaNameED').val(tempPeriodo.year);
            $('#AsignaturaCreditosED').val(tempPeriodo.trimestre);
        });
    });
}


