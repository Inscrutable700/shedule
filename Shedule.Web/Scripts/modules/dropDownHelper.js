$(document).ready(function () {
    var dropdown = $("#teachings");
    var classRooms = dropdown.value;
    fillLessonsDropDown(classRooms);
    alert(classRooms);
});

$("#teachings").on("change", function (e) {
    var classRooms = this.value;
    fillLessonsDropDown(classRooms);
    alert(classRooms);
})

function fillLessonsDropDown(data) {
    var lessons = JSON.parse(data);
    $.each(lessons, function (lesson) {
        $('#lessonsDropDown')
             .append($('<option>', { value: lesson.LessonId })
             .text(lesson.FormattedTimeAndDay));
    });
}