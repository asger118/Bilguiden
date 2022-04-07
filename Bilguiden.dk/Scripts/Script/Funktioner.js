
let Biler = [];
const buttons = document.querySelectorAll('.knap');

function GetBil_ID(Bil_ID) {
    if (Biler.length <= 3) {
        //Checker om Bil_ID er i arrayet i forvej
        if (Biler.includes(Bil_ID)) {
            //Hvis Bil_ID er i array[Biler]
            } else {
        //Hvis Bil_ID ikke er i array[Biler]
                switch (Biler.length) {
                    case 0:
                        Biler.push(Bil_ID);
                        console.log(Biler);
                        break;
                    case 1:
                        Biler.push(Bil_ID);
                        console.log(Biler);
                        break;
                    case 2:
                        Biler.push(Bil_ID);
                        console.log(Biler);
                        break;
                    case 3:
                        Biler.length = 0;
                        buttons.forEach(button => button.classList.remove('active'));
                        Biler.push(Bil_ID);
                        console.log(Biler);
                        break;
        }
        }
    }
}

buttons.forEach(button => {
    button.addEventListener('click', () => {

        switch (Biler.length) {
            case 1:
                button.classList.add('active');
                break;
            case 2:
                button.classList.add('active');
                break;
            case 3:
                button.classList.add('active');
                break
            default:
                button.classList.remove('active');
                button.classList.add('active');
        }
    });
});

//URL: hvor dataen skal hen/endpoint
function SendData() {
    window.location.href = "/Home/Sammenlign?Bil_ID1=" + Biler[0] + "&Bil_ID2=" + Biler[1]+ "&Bil_ID3=" + Biler[2];
}



