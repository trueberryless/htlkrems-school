<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>

    <script>
        var green = false;
        var light = 1; //1 = red; 2 = yellow; 3 = green;
        async function ChangeLight(){
            
            if(green){
                document.getElementById("green").style.backgroundColor = "darkgrey";
                await Sleep(500);
                document.getElementById("green").style.backgroundColor = "green";
                await Sleep(1000); 
                document.getElementById("green").style.backgroundColor = "darkgrey";
                await Sleep(500);
                document.getElementById("green").style.backgroundColor = "green";
                await Sleep(1000);                
                document.getElementById("green").style.backgroundColor = "darkgrey";
                await Sleep(500);
                document.getElementById("green").style.backgroundColor = "green";
                await Sleep(1000);
                document.getElementById("green").style.backgroundColor = "darkgrey";
                await Sleep(500);
                document.getElementById("yellow").style.backgroundColor = "yellow";
                await Sleep(1300);
                document.getElementById("yellow").style.backgroundColor = "darkgrey";
                document.getElementById("red").style.backgroundColor = "red";
            } else if(!green){
                document.getElementById("yellow").style.backgroundColor = "yellow";
                await Sleep(1300);
                document.getElementById("red").style.backgroundColor = "darkgrey";
                document.getElementById("yellow").style.backgroundColor = "darkgrey";
                document.getElementById("green").style.backgroundColor = "green";
            }
            green = !green;
        }
        function ChangeLights(){
            if(light < 1)
                light = 3;

            if(light == 1){
                document.getElementById("red2").style.backgroundColor = "darkgrey";
                document.getElementById("green2").style.backgroundColor = "green";                
            } else if(light == 2){
                document.getElementById("yellow2").style.backgroundColor = "darkgrey";
                document.getElementById("red2").style.backgroundColor = "red";
            } else if(light == 3){
                document.getElementById("green2").style.backgroundColor = "darkgrey";
                document.getElementById("yellow2").style.backgroundColor = "yellow";                
            }

            light--;
        }
        function Sleep(milliseconds) {
            return new Promise(resolve => setTimeout(resolve, milliseconds));
        }
    </script>
</head>
<body>
    <div>This is a normal traffic light:</div>
    <table style="border: 1px solid black; ">
        <tr>
            <td><div id="red" style="width: 50px; height: 50px; background-color: red;"></div></td>
        </tr>
        <tr>
            <td><div id="yellow" style="width: 50px; height: 50px; background-color: darkgrey;"></div></td>
        </tr>
        <tr>
            <td><div id="green" style="width: 50px; height: 50px; background-color: darkgrey;"></div></td>
        </tr>
    </table>   
    <br>
    <button onclick="ChangeLight();">Change the color of the traffic light!</button>
    <br><br><br><br><br>
    <div>This is a traffic light, which changes color not as in real life:</div>
    <table style="border: 1px solid black; ">
        <tr>
            <td><div id="red2" style="width: 50px; height: 50px; background-color: red;"></div></td>
        </tr>
        <tr>
            <td><div id="yellow2" style="width: 50px; height: 50px; background-color: darkgrey;"></div></td>
        </tr>
        <tr>
            <td><div id="green2" style="width: 50px; height: 50px; background-color: darkgrey;"></div></td>
        </tr>
    </table>   
    <br>
    <button onclick="ChangeLights();">Change the color of the traffic light!</button>
</body>
</html>