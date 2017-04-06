var note;
$(document).ready(function () {
    note = $('#summernote');
    note.summernote();
    console.log(note.summernote('code'));
});
function log() {
    console.log(note.summernote('code'));
}