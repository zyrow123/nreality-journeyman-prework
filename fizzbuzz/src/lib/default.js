// ------------------------------------------------
// Copyright © Microsoft Corporation. All rights reserved
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at

// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-------------------------------------------------
var app = {};

(function () {
    "use strict";

    window.addEventListener("load", function load(event) {
        window.removeEventListener("load", load, false);
        init();
    }, false);

    function init() {
        $("#link").on("click", fizzbuzz);
    }

    function printValue(value) {
        $("ul").append($('<li>').append(value));
    }
    
    function fizzbuzz() {
        for (var i = 1; i <= 100; i++) {
            printValue(app.transform(i));
        }
    }

    app.isMultipleOfThree = function (value) {
        return app.isMultiple(value, 3) ? "Fizz":"";
    };
    
    app.isMultipleOfFive = function (value) {
        return app.isMultiple(value, 5) ? "Buzz" : "";
    };

    app.isMultiple = function (value, denominator) {
        return (value % denominator) === 0;
    };

    
    app.transform = function (value) {
        
         var transformation = app.isMultipleOfThree(value);
        transformation += app.isMultipleOfFive(value);

        return transformation === "" ? value : transformation;
    };
}());