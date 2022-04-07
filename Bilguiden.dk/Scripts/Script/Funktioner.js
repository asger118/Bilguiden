
let Biler = [];
const buttons = document.querySelectorAll('.knap');


    buttons.forEach(button => {
        button.addEventListener('click', () => {
            button.classList.add('active');
        });
    });


function GetBil_ID(Bil_ID) {
    if (Biler.length <= 2) {
        //Checker om Bil_ID er i arrayet i forvej
        if (Biler.includes(Bil_ID)) {
            //Hvis Bil_ID er i array[Biler]
        } else {
        //Hvis Bil_ID ikke er i array[Biler]
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



