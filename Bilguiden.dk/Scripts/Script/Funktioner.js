
let Biler = [];

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
function SendData() {
    window.location.href = "/Home/Sammenlign?Bil_ID1=" + Biler[0] + "&Bil_ID2=" + Biler[1]+ "&Bil_ID3=" + Biler[2];

}




