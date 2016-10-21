function loadEdit(id, name, bio, picture) {

    $('#btnActor').attr('value', 'Editar').attr('onclick', 'editActor()');

    $('#id').val(id);
    $('#name').val(name);
    $('#bio').val(bio);
    $('#picture').val(picture);

    $('#dlgActor').dialog({
        title: 'Edit Actor'
    }).dialog('open')
}

function loadFromData(data) {
    if (data)
        $("#actors").find("tbody").append(getRowsFromData(data));
};

function dialogToActor() {
    var actor = {};

    actor.id = Number($("#id").val());
    actor.name = $("#name").val();
    actor.bio = $("#bio").val();
    actor.picture = $("#picture").val();

    return actor;
}

function rowFromActor(actor) {
    var str = '';
    var strEdit = actor.id + ",'" + actor.name + "','" + actor.bio + "','" + actor.picture + "'";

    str += '<tr class="' + actor.id + '">';
    str += '<td>' + actor.id + '</td>';
    str += '<td>' + actor.name + '</td>';
    str += '<td>' + actor.bio + '</td>';
    str += '<td><img src="' + actor.picture + '"></img></td>';
    str += '<td><input type="button" class="btn btn-warning" value="Editar" onclick="loadEdit(' + strEdit + ')"></button></td>';
    str += '<td><input type="button" class="btn btn-danger" value="Eliminar" onclick="deleteActor(' + actor.id + ')"></button></td>';

    str += '</tr>';
    return str;
};

function getRowsFromData(d) {

    var str = '';

    d.forEach(function (actor) {
        str += rowFromActor(actor);
    });

    return str;
};


function createElement(actor) {

    var actorElement = $('#actorElement').clone();
    $(actorElement).show();
    $(actorElement).find('#actorName').html(actor.name);
    $(actorElement).find('#actorBio').html(actor.bio);
    $(actorElement).find('#actorImg').attr('src', actor.picture);

    return actorElement;
}