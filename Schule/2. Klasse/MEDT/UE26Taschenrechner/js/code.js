var eingabe = "";
var ausgabe = "0";
var zahl = "";
var op = "";
var on = false;
var ergebnis = 0;
var ausgabenspeicher = "";
var elem;

function init() {
    elem = document.getElementById("body");
    elem.addEventListener("keydown", KeyDownPressed);
}

function KeyDownPressed(evt) {
    switch(evt.key) {
        case "1": Checkifon(); Calc("1"); break;
        case "2": Checkifon(); Calc("2"); break;
        case "3": Checkifon(); Calc("3"); break;
        case "4": Checkifon(); Calc("4"); break;
        case "5": Checkifon(); Calc("5"); break;
        case "6": Checkifon(); Calc("6"); break;
        case "7": Checkifon(); Calc("7"); break;
        case "8": Checkifon(); Calc("8"); break;
        case "9": Checkifon(); Calc("9"); break;
        case "0": Checkifon(); Calc("0"); break;
        case "Backspace": Calc("back"); break;
        case "Delete": Calc("ce"); break;
        case "Enter": Calc("="); break; 
        case "Escape":
        case "o": Calc("on"); break;
        case "e": Calc("e"); break;
        case "p": Calc("pi"); break;
        case "w": Calc("square"); break;        
        case ".": Calc("."); break;
        case "+": 
        case "a": Calc("+"); break;
        case "-":
        case "s": Calc("-"); break;
        case "/":
        case "d": Calc("/"); break;
        case "*":
        case "m": Calc("*"); break;
        case "h": 
        case "^":
        case "°": Calc("^"); break;
    }

    function Checkifon() {
        if(!on){
            on = true; 
            ausgabe = "0"; 
            document.getElementById('on').style.color = "green"; 
            document.getElementById('on').innerHTML = "ON";
        }
    }
}

function Calc(eingabe) {
    if(on) {
        ausgabenspeicher = ausgabe;
    }
    if(ausgabe == "0" || ausgabe == "00"){
        ausgabe = "";
    }
        
    switch(eingabe) {
        case 'on':
            if(on) {
                ausgabe = "";
                document.getElementById('on').style.color = "red";
                document.getElementById('on').innerHTML = "OFF";
            } else {
                ausgabe = "0";
                document.getElementById('on').style.color = "green";
                document.getElementById('on').innerHTML = "ON";
            }
            on = !on;
            break;
        case 'ce':
            ausgabe = "0";
            break;
        case '1':
            ausgabe += "1";
            break;
        case '2':
            ausgabe += "2";
            break;
        case '3':
            ausgabe += "3";
            break;
        case '4':
            ausgabe += "4";
            break;
        case '5':
            ausgabe += "5";
            break;
        case '6':
            ausgabe += "6";
            break;
        case '7':
            ausgabe += "7";
            break;
        case '8':
            ausgabe += "8";
            break;
        case '9':
            ausgabe += "9";
            break;
        case '0':
            ausgabe += "0";
            break;
        case '+':
            ausgabe += " + "; 
            break;    
        case '-':
            ausgabe += " - "; 
            break;
        case '*':
            ausgabe += " * "; 
            break;
        case '/':
            ausgabe += " / "; 
            break;    
        case '^':
            ausgabe += " ^ ";
            break; 
        case 'square' :
            ausgabe += " s ";
            break;
        case '.':
            if(ausgabe==""){
                ausgabe += "0";
            }
            ausgabe += ".";
            break;
        case 'back':
            if(ausgabe != "0" || ausgabe.length > 0)
                ausgabe = ausgabe.substring(0, ausgabe.length - 1);
            break;
        case 'e':
            ausgabe += String(Math.E);
            break;
        case 'pi':
            ausgabe += String(Math.PI);
            break;
    }
    // Rechenvorgang
    const myArray = ausgabe.split(' ');
    

    for(var i = 1; i < myArray.length; i += 2) {
        if(myArray[i] == "*") {
            myArray[i-1] = Number(myArray[i-1]) * Number(myArray[i+1]);
            for(var j = i; j < myArray.length - 2; j++) {
                myArray[j] = myArray[j+2];
            }
            myArray.pop(); myArray.pop();
            i -= 2;
        }
        if(myArray[i] == "/") {
            myArray[i-1] = Number(myArray[i-1]) / Number(myArray[i+1]);
            for(var j = i; j < myArray.length - 2; j++) {
                myArray[j] = myArray[j+2];
            }
            myArray.pop(); myArray.pop();
            i -= 2;
        }
    }    
    var erg = Number(myArray[0]);
    for(var i = 1; i < myArray.length; i += 2) {
        switch(myArray[i]) {
            case '+': 
                erg += Number(myArray[i+1]);
                break;
            case '-': 
                erg -= Number(myArray[i+1]);
                break;
            case '*': 
                erg *= Number(myArray[i+1]);
                break;
            case '/': 
                erg /= Number(myArray[i+1]);
                break;
            case '^':
                erg = Math.pow(erg, Number(myArray[i+1]));
                break;
        }
    }

    if(eingabe == "square") {
        erg = Math.sqrt(erg);
        if((Number(erg) * 100000000) % 10 != 0){
            ausgabe = Math.round(erg.toString() * 10000000) / 10000000 + "...";
        } else {
            ausgabe = Number(erg);
        } 
    }
    
    if(eingabe == "=") {
        if((Number(erg) * 100000000) % 10 != 0){
            ausgabe = Math.round(erg.toString() * 10000000) / 10000000 + "...";
        } else {
            ausgabe = Number(erg);
        }        
    }

    if(ausgabe == "0" || ausgabe == "" || on == false) {
        document.getElementById('ce').style.color = "white";
    } else {
        document.getElementById('ce').style.color = "lightskyblue";
    }

    if(ausgabe == "" || ausgabe == "0" || on == false) {
        document.getElementById('back').style.color = "white";
    } else {
        document.getElementById('back').style.color = "lightskyblue";
    }

    if(ausgabe != erg && myArray[myArray.length-1] != "" && on == true) {
        document.getElementById('=').style.color = "lightskyblue";
    } else {
        document.getElementById('=').style.color = "white";
    }   
    
    if(ausgabe == "") {
        ausgabe += "0";
    }

    if (ausgabe[ausgabe.length - 3] == "." && ausgabe[ausgabe.length - 2] == "." && ausgabe[ausgabe.length - 1] == "." && ausgabe.length < 12){
        ausgabe = ausgabe.substring(0, ausgabe.length - 3);
    }

    console.log(ausgabe);

    if(ausgabe == "Infinity" || ausgabe == "-Infinity" || ausgabe == "-Infinity...") {
        ausgabe = "Error";
        erg = "Divided by Zero";
    }

    if(on) {
        document.getElementById('ausgabe').innerHTML = ausgabe;
        document.getElementById('erg').innerHTML = erg;
    } else {
        ausgabe = ausgabenspeicher;
        document.getElementById('ausgabe').innerHTML = "";
        document.getElementById('erg').innerHTML = "";
    }

    if(ausgabe == "Error" || ausgabe == "NaN") {
        ausgabe = "0";
    }

    if (ausgabe[ausgabe.length - 3] == "." && ausgabe[ausgabe.length - 2] == "." && ausgabe[ausgabe.length - 1] == "."){
        ausgabe = ausgabe.substring(0, ausgabe.length - 3);
    }
}

// const body = document.querySelector('body');

// body.addEventListener("keydown" , function(){
//     switch(){

//     }
// })

$(document).bind('keydown', function (evt) {
    console.log("Tastaturcode: " + evt.keyCode);
    Calc(evt.keyCode);
});