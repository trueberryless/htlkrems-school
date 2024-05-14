var ttt = [[0,0,0],[0,0,0],[0,0,0]];


var player1 = true;
var setvalue = 0;
var player = "Player X";
var roundadder = 0;

function Draw(x,y)
{
    if(search_win() == false){        
        
        if(ttt[x][y] == 0){
            if(player1) {
                setvalue = 1;
                player = "Player X";
            } else {
                setvalue = 4;
                player = "Player O";
            }
            ttt[x][y] = setvalue;
	    roundadder++;
            if(search_win()){
                document.getElementById('message').innerHTML = player + " won!";
            }
            refresh_item(x,y);
            player1 = !player1;
        }    
        
    }    
}
function refresh_item(x,y) {
    var symbol;
    if(player1){
        symbol = "x";
    } else{
        symbol = "o";
    }
    switch(x) {
        case 0: 
            switch(y) {
                case 0:
                    document.getElementById('0_0').innerHTML = symbol;
                    break;
                case 1:
                    document.getElementById('0_1').innerHTML = symbol;
                    break;
                case 2:
                    document.getElementById('0_2').innerHTML = symbol;
                    break;
            }
            break;
        case 1: 
            switch(y) {
                case 0:
                    document.getElementById('1_0').innerHTML = symbol;
                    break;
                case 1:
                    document.getElementById('1_1').innerHTML = symbol;
                    break;
                case 2:
                    document.getElementById('1_2').innerHTML = symbol;
                    break;
            }
            break;
        case 2: 
            switch(y) {
                case 0:
                    document.getElementById('2_0').innerHTML = symbol;
                    break;
                case 1:
                    document.getElementById('2_1').innerHTML = symbol;
                    break;
                case 2:
                    document.getElementById('2_2').innerHTML = symbol;
                    break;
            }
            break;
    }
}

function search_win() {
    for(i = 0; i < 3; i++){
        if(ttt[i][0] + ttt[i][1] + ttt[i][2] == 3 || ttt[i][0] + ttt[i][1] + ttt[i][2] == 12)
            return true;
        if(ttt[0][i] + ttt[1][i] + ttt[2][i] == 3 || ttt[0][i] + ttt[1][i] + ttt[2][i] == 12)
            return true;
    }    
    if(ttt[0][0] + ttt[1][1] + ttt [2][2] == 3 || ttt[0][0] + ttt[1][1] + ttt [2][2] == 12)
        return true;
    if(ttt[0][2] + ttt[1][1] + ttt[2][0] == 3 || ttt[0][2] + ttt[1][1] + ttt[2][0] == 12)
        return true;
    if(roundadder >= 9){
        player = "Noone";
        return true;
    }
    return false;
}

