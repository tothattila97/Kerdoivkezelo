"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var httpOptions = {
    headers: new http_1.HttpHeaders({
        'Content-Type': 'application/json'
    })
};
var BejelentkezesService = /** @class */ (function () {
    function BejelentkezesService(http, baseURL) {
        this.http = http;
        this.baseURL = baseURL;
    }
    BejelentkezesService.prototype.bejelentkezes = function () {
    };
    return BejelentkezesService;
}());
exports.BejelentkezesService = BejelentkezesService;
//# sourceMappingURL=bejelentkezes.service.js.map