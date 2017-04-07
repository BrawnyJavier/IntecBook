var note;
function MasterLoad(id) {
    $(document).ready(function () {
        note = $('#summernote');
        note.summernote();
        console.log(note.summernote('code'));
        $("#TrimestresSelect").empty();
        $.getJSON("api/Trimestres/GetTrimestres", function (json) {
            console.log(json);
            for (var key in json) {
                if (json.hasOwnProperty(key)) {
                    $('#TrimestresSelect').append('<option value="' + json[key].id + '">' + json[key].trimestre + '</option>');
                }
            }
            LoadSubjects($("#TrimestresSelect").val());
        });
        $("#TrimestresSelect").change(function () {
            LoadSubjects($("#TrimestresSelect").val());
        });
        if (id) {
            $.getJSON("api/Notas/GetNoteById/" + id, function (json) {
                console.log(json);
                note.summernote('code', json.content);
                $('#TitleInput').val(json.title);
            });
            //note.summernote('code');
        }
    });
}

function LoadSubjects(Trimestre) {
    $("#AsignaturasSelect").empty();
    $.getJSON("api/Trimestres/GetTrimestreSchedule/" + Trimestre, function (json) {
        console.log(json);
        for (var key in json) {
            if (json.hasOwnProperty(key)) {
                $('#AsignaturasSelect').append('<option value="' + json[key].idAsignatura + '">' + json[key].asignatura + '</option>');
            }
        }
    });
}
function log() {
    console.log(note.summernote('code'));
}
$(document).on("click", "#submitNotebtn", function () {
    $('#submitNotebtn').prop('disabled', true);
    var noteModel = {
        StudentSubjectId: $('#AsignaturasSelect').val(),
        title: $('#TitleInput').val(),
        content: note.summernote('code'),
        ownerId: null
    }
    $.ajax({
        type: "POST",
        url: "api/Notas/CreateNote/",
        data: JSON.stringify(noteModel),
        contentType: "application/json",
        success: function (data) {
            $('#submitNotebtn').prop('disabled', true);
            swal('Nota guardada :P');
        }
    });
});