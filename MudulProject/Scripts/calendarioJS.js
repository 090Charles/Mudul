$(document).ready(function () {

    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        today: true,
        displayEventEnd: true,
        eventLimit: true, // allow "more" link when too many events
        cache: true,
        lazyFetching: true,
        events: function (start, end, timezone, callback) {
            $.ajax({
                url: '/Calendario/AjaxTest',
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache:true,
                success: function (data) {
                    var doc = JSON.parse(data);
                    var events = [];
                    $(doc).each(function () {
                        var horaInicio = parseDateToJS($(this).attr('HoraInicio'));
                        var horaLimite = parseDateToJS($(this).attr('HoraLimite'));
                        if (!isWorkingHour(horaLimite)) {
                            horaLimite.setDate(horaLimite.getDate() + 1);
                        }
                        events.push({
                            id:$(this).attr('Id'),
                            title: $(this).attr('Titulo'),
                            start: horaInicio,
                            end: horaLimite,
                            idActividad : $(this).attr('IdActividad'),
                            color: '#009688',
                            eventBackgroundColor: '#009688',
                            eventTextColor: '#009688'
                        });
                    });
                    callback(events);
                }
            });
        },
        eventClick: function (calEvent, jsEvent, view) {
            window.location = '/RevisarCalificaciones/Details/' + calEvent.idActividad;
        }
    });

    function parseDateToJS(toParseDate) {
        var jsonDate = toParseDate;
        var re = /-?\d+/;
        var m = re.exec(jsonDate);
        var formattedDate = new Date(parseInt(m[0]));
        return formattedDate;
    }

    function isWorkingHour(now) {
        return now.getHours() >= 9 && now.getHours() < 24;
    }
});