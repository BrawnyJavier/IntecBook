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
        $(document).on("click", "#saveButtn", function () {
            var Asignatura =
                  {
                      Id: null,
                      Name: $('#AsignaturaName').val(),
                      Creditos: $('#AsignaturaCreditos').val()
                  };

            $.ajax({
                type: "POST",
                data: JSON.stringify(Asignatura),
                url: "api/Subjects",
                contentType: "application/json",
                success: function (data) {
                    oTable.ajax.reload();
                }
            });


        });
    });
}


