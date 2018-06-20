var app = app || {};

//app.metodo2 = function(param1) {
//    return param1 + ' (dentro de metodo 2)';
//};

app.comunes = function () {

    var self = {};

    self.metodo2 = function (param1) {
        return param1 + ' (dentro de comunes.metodo2)';
    }

    return self;

}();