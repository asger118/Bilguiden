
Biler = [];

function GetBil_ID(Bil_ID) {

    if (Biler.length <= 2) {
    //Checker om Bil_ID er i arrayet i forvej
    if (Biler.indexOf(Bil_ID) !== -1) {
    //Hvis Bil_ID er i array[Biler]
    }
    //Hvis Bil_ID ikke er i array[Biler]
    else {
        Biler.push(Bil_ID);
        console.log(Biler);
        }
    }
}

function FjernBil_ID() {

    if (Biler.length > 0) {

        Biler.length = 0;
        console.log(Biler);
    }
}
//URL: hvor dataen skal hen/endpoint
//
function SendData() {
    let bo = JSON.parse(JSON.stringify(Biler));
    console.log(bo);

$.ajax({
    url: "/Home/Sammenlign",
    type: "POST",
    data: bo,
    success: function (result) { console.log("ID'er" + result) },
    error: function (error) {console.log(error)},

})
}