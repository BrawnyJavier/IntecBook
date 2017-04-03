var oTable;
var PeriodosTable;
var AsignaturasTable;
var selected = false;
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
var tempPeriodo = new PeriodoClass();
var tempSubject = new subjectClass();
function MasterLoad() {
    $(document).ready(function () {
        $('#addSubject').slideUp();
        $('.clockpicker').clockpicker();
        $('#editBtn,#seeRegs,#deleteBtn,#AsignaturasTables').hide();
        //  $('#deleteBtn').hide();
        PeriodosTable = $('#SchedulesTable').DataTable({
            responsive: true,
            "ajax": {
                "url": "/api/Trimestres",
                "dataType": 'json',
                "type": "GET",
                "dataSrc": "",
                "sDom": 'rt',
                "paging": false,
                "ordering": true,
                "info": false
            },
            "columns": [
                { "data": "id" },
                   { "data": "year" },
                { "data": "trimestre" }
            ]
        });
        AsignaturasTable = $('#AsignaturasTable').DataTable({
            responsive: true,
            "ajax": {
                "url": "/api/Subjects",
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
        $('#SchedulesTable tbody').on('click', 'tr', function () {
            console.log(PeriodosTable.row(this).data());
            tempPeriodo.set(PeriodosTable.row(this).data());
            $('#deleteBtn,#seeRegs,#AsignaturasTables').show();
            $('#editBtn').show();
            $('#Add').hide();
            if ($(this).hasClass('selected')) {
                $('#Add').show();
                $('#deleteBtn,#seeRegs,#editBtn,#AsignaturasTables').hide();
                //$('#AsignaturasTables').hide();
                $(this).removeClass('selected');
            }
            else {
                PeriodosTable.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }
        });
        $('#AsignaturasTable tbody').on('click', 'tr', function () {
            console.log(AsignaturasTable.row(this).data());
            tempSubject.set(AsignaturasTable.row(this).data());
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                AsignaturasTable.$('tr.selected').removeClass('selected');
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
                    PeriodosTable.ajax.reload();
                }
            });
        });
        $(document).on("click", "#SelectSub", function () {
            $('#Asignaturas').modal('toggle');
            $('#addSubject').slideDown();


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
                    PeriodosTable.ajax.reload();
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
                    PeriodosTable.ajax.reload();
                    tempPeriodo.reset();
                    $('#edit').modal('toggle');
                }
            });
        });
        $(document).on("click", "#editBtn", function () {
            $('#AsignaturaNameED').val(tempPeriodo.year);
            $('#AsignaturaCreditosED').val(tempPeriodo.trimestre);
        });
        $(document).on("click", "#saveButtn", function () {
            // This is for submitting the reg for students subjects.
            //var Periodo =
            //    {
            //        Id: null,
            //        Trimestre: $('#AsignaturaCreditos').val(),
            //        Year: $('#AsignaturaName').val(),
            //        User: null
            //    };
            //$.ajax({
            //    type: "POST",
            //    data: JSON.stringify(Periodo),
            //    url: "api/Trimestres",
            //    contentType: "application/json",
            //    success: function (data) {
            //        $("#saveButtn").attr("disabled", false);
            //        PeriodosTable.ajax.reload();
            //    }
            //});



        });
    });
}


