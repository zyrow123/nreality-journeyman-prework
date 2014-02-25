test("multiple of 3", function () {

    ok(app.isMultipleOfThree(3) === "Fizz", "Passed!");
});

test("multiple of 5", function () {

    ok(app.isMultipleOfFive(5) === "Buzz", "Passed!");


});

test("is multiple", function () {
    
    ok(app.isMultiple(5, 5) === true && app.isMultiple(5, 6) === false, "Passed!");

});

test("transform value", function () {

    var resultThree = app.transform(3);
    
    var resultFive = app.transform(5);

    var resultFithTeen = app.transform(15);
    
    ok(resultThree === "Fizz" && resultFive === "Buzz" && resultFithTeen === "FizzBuzz", "Passed!");


});