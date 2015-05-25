$(document).ready(function () {
    var dropdown = $("#teachings");
    var model = JSON.parse(dropdown.val());
    fillLessonsDropDown(model.Lessons);
    fillTariffsDropDown(model.Tariffs);
});

$("#teachings").on("change", function (e) {
    var model = JSON.parse(this.value);
    fillLessonsDropDown(model.Lessons);
    fillTariffsDropDown(model.Tariffs);
})

function fillLessonsDropDown(lessons) {
    $("#lessonsDropDown").empty();
    $.each(lessons, function (i, lesson) {
        $('#lessonsDropDown')
             .append($('<option>', { value: lesson.LessonId })
             .text(lesson.FormattedTimeAndDay));
    });
}

function fillTariffsDropDown(tariffs) {
    $("#tariffsDropDown").empty();
    $.each(tariffs, function (i, tariff) {
        $('#tariffsDropDown')
             .append($('<option>', { value: tariff.TariffId })
             .text(tariff.FormattedInfo));
    });
}