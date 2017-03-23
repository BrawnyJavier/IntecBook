$(document).ready(function () {
    
    $('#datatable').DataTable({
        responsive: true
    });
    $(document).on("click", "#asignaturasNav", function () {
        $("#AjaxLoads").load("/Html/Subjects.html", function () {
            SubjectsLoad();
    });
    }); 
    $(document).on("click", "#TrimestresNav", function () {
        $("#AjaxLoads").load("/Html/Trimestres.html", function () {

        });
    });
    
});