$(document).ready(function () {
    var dropdown = $("#teachings");
    var classRooms = dropdown.val();
    fillLessonsDropDown(classRooms);
});

$("#teachings").on("change", function (e) {
    var classRooms = this.value;
    fillLessonsDropDown(classRooms);
})

function fillLessonsDropDown(data) {
    var lessons = JSON.parse(data);
    $("#lessonsDropDown").empty();
    $.each(lessons, function (i, lesson) {
        $('#lessonsDropDown')
             .append($('<option>', { value: lesson.LessonId })
             .text(lesson.FormattedTimeAndDay));
    });
}