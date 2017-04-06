
function NotesDetailLoad(id) {
    $(document).ready(function () {
        if (id) {
            $.getJSON("api/Notas/GetNoteById/" + id, function (json) {
                console.log(json); console.log(json.title);
                $('#title').text(json.title);
                $('#content').html(json.content);
                $('#date').text(json.date);
                $('#subtitle').text(json.subtitle);   
            });
        }
    });
}


//$('#datatable').DataTable({
//    responsive: true
//});
//$(document).on("click", "#asignaturasNav", function () {
//    $("#AjaxLoads").load("/Html/Subjects.html", function () {
//        SubjectsLoad();
//});
//}); 
//$(document).on("click", "#TrimestresNav", function () {
//    $("#AjaxLoads").load("/Html/Trimestres.html", function () {
//        MasterLoad();
//    });
//});
//$(document).on("click", "#NotesNav", function () {
//    $("#AjaxLoads").load("/Html/Notes.html", function () {
//        NotesLoad();
//    });
//});

