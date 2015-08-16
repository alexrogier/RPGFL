// External Script Variables
// @userId - defined in View.ascx

$(document).ready(function () {
    $(function () {
        $(".sortable").sortable({
            revert: true
        });
        $(".draggable").draggable({
            connectToSortable: "#sortable",
            helper: "clone",
            revert: "invalid"
        });
        $("ul, li").disableSelection();
    });
});
function getDraftPriority() {

}

function postDraftPriority() {

}

function populateCharacters() {

}