var elem;

var operand1=0;
var opera_switch=1;
var oparand2=0;
var operator="";
var counter=1;

function c_init()
{
    elem = document.getElementById("c_body");
    elem.addEventListener("keydown", KeyDownPressed );
    document.getElementById("c_1").addEventListener("click", function() {C_ButtonClicked("1");});
    document.getElementById("c_2").addEventListener("click", function() {C_ButtonClicked("2");});
    document.getElementById("c_3").addEventListener("click", function() {C_ButtonClicked("3");});
    document.getElementById("c_4").addEventListener("click", function() {C_ButtonClicked("4");});
    document.getElementById("c_5").addEventListener("click", function() {C_ButtonClicked("5");});
    document.getElementById("c_6").addEventListener("click", function() {C_ButtonClicked("6");});
    document.getElementById("c_7").addEventListener("click", function() {C_ButtonClicked("7");});
    document.getElementById("c_8").addEventListener("click", function() {C_ButtonClicked("8");});
    document.getElementById("c_9").addEventListener("click", function() {C_ButtonClicked("9");});
    document.getElementById("c_0").addEventListener("click", function() {C_ButtonClicked("0");});
    document.getElementById("c_+").addEventListener("click", function() {C_ButtonClicked("+");});
    document.getElementById("c_-").addEventListener("click", function() {C_ButtonClicked("-");});
    document.getElementById("c_/").addEventListener("click", function() {C_ButtonClicked("/");});
    document.getElementById("c_x").addEventListener("click", function() {C_ButtonClicked("x");});
    // document.getElementById("c_C").addEventListener("click", function() {C_ButtonClicked("C");});
    document.getElementById("c_=").addEventListener("click", function() {C_ButtonClicked("=");});
    // document.getElementById("c_+/-").addEventListener("click", function() {C_ButtonClicked("+/-");});
    document.getElementById("c_AC").addEventListener("click", function() {C_ButtonClicked("AC");});
}

function KeyDownPressed(evt)
{
    debugger;
    // let zeichen = String.fromCharCode(evt.charCode);
    // let c_key = `${evt.key}`;
    switch(evt.key)
    {
        case "0": C_ButtonClicked("0"); break;
        case "1": C_ButtonClicked("1"); break;
        case "2": C_ButtonClicked("2"); break;
        case "3": C_ButtonClicked("3"); break;
        case "4": C_ButtonClicked("4"); break;
        case "5": C_ButtonClicked("5"); break; 
        case "6": C_ButtonClicked("6"); break;
        case "7": C_ButtonClicked("7"); break;
        case "8": C_ButtonClicked("8"); break;
        case "9": C_ButtonClicked("9"); break;
        case "Backspace": C_ButtonClicked("C"); break;
    }

    // document.getElementById("c_displayText").innerHTML = `<strong>Taste gedrückt</strong>: <br> key: `+c_key  ;
}

function C_ButtonClicked(clickvalue)
{
    switch(clickvalue)
    {
        case "1": ToOperand(1); break;
        case "2": ToOperand(2); break;
        case "3": ToOperand(3); break;
        case "4": ToOperand(4); break;
        case "5": ToOperand(5); break;
        case "6": ToOperand(6); break;
        case "7": ToOperand(7); break;
        case "8": ToOperand(8); break;
        case "9": ToOperand(9); break;
        case "0": ToOperand(0); break;
        case "+": Plus(); break;
        case "-": Minus(); break;
        case "/": Dividiert(); break;
        case "x": Mal(); break;
        case "+/-": MakeOposit(); break;
        // case "C": FuncClear(); break;
        case "AC": FuncClearAll(); break;
        case "=": Solve(); break;
    }
    debugger;

    function FuncClearAll()
    {
        operand1 = 0;
        operand2 = 0;
        counter  = 1;
        document.getElementById("c_displaylcd").value=operand1;
    }
    
    function Plus() {
        opera_switch=2;
        counter = 1;
        operator="+";
    }

    function Minus() {
        opera_switch=2;
        counter = 1;
        operator="-";
    }

    function Dividiert() {
        opera_switch=2;
        counter = 1;
        operator="/";
    }

    function Mal() {
        opera_switch=2;
        counter = 1;
        operator="x";
    }

    function MakeOposit() {
        operand1 *= -1;
        document.getElementById("c_displaylcd").value *= -1;
    }

    function Solve() {
        switch(operator){
            case "+": document.getElementById("c_displaylcd").value=operand1 + operand2; break;
            case "-": document.getElementById("c_displaylcd").value=operand1 - operand2; break;
            case "/": document.getElementById("c_displaylcd").value=operand1 / operand2; break;
            case "x": document.getElementById("c_displaylcd").value=operand1 * operand2; break;
        }
    }
  

    function ToOperand(opera)
    {
        if (opera_switch==1)
        {
            if(counter<=1)
                operand1=opera;
            else
            {
                operand1*=10;
                operand1+=opera;
            }
            counter++;
        } else{
            if(counter<=1)
                operand2=opera;
            else
            {
                operand2*=10;
                operand2+=opera;
            }
            counter++;
        }
        RefreshDisplay();

    }

    function RefreshDisplay()
    {
        if (opera_switch==1)
        {
            document.getElementById("c_displaylcd").value=operand1;
        }
        else
            document.getElementById("c_displaylcd").value=operand2;
    }
}















