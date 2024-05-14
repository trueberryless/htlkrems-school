$(document).ready(function() {
    var size = 30;
    var background_Color = "darkorange";
    var foreground_Color = "white";

    $("#b-red").click(function() {        
        if(document.getElementById('bigdiv').style.color != "red")
            background_Color = "red";
    }); 
    $("#b-green").click(function() {
        if(document.getElementById('bigdiv').style.color != "green")
            background_Color = "green";
    }); 
    $("#b-blue").click(function() {
        if(document.getElementById('bigdiv').style.color != "darkorange") 
            background_Color = "darkorange";
    });

    $("#input").change(function() { 
        $("#ausgabe").html($("#input").val());
    });
    $("#f-white").click(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "white")
            foreground_Color = "white";
    });    
    $("#f-red").click(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "red")
            foreground_Color = "red";
    }); 
    $("#f-green").click(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "green")
            foreground_Color = "green";
    });
    $("#f-blue").click(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "blue")
            foreground_Color = "blue";
    });
    $("#f-black").click(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "black")
            foreground_Color = "black";
    });
    $("#plus").click(function() {
        size += 4;
        if(size > 80)
            size = 80;
        $("#ausgabe").css("font-size", size + "px");
    });
    $("#minus").click(function() {
        size -= 4;
        if(size < 10)
            size = 10;
        $("#ausgabe").css("font-size", size + "px");
    });

    //-------------------------------------------------------------------------

    $("#b-red").mouseenter(function() {
        if(document.getElementById('bigdiv').style.color != "red")
            $("#bigdiv").css("background-color", "red");
    })
    $("#b-red").mouseleave(function() {
        $("#bigdiv").css("background-color", background_Color);
    })
    $("#b-green").mouseenter(function() {
        if(document.getElementById('bigdiv').style.color != "green")
            $("#bigdiv").css("background-color", "green");
    })
    $("#b-green").mouseleave(function() {
        $("#bigdiv").css("background-color", background_Color);
    })
    $("#b-blue").mouseenter(function() {
        if(document.getElementById('bigdiv').style.color != "darkorange")
            $("#bigdiv").css("background-color", "darkorange");
    })
    $("#b-blue").mouseleave(function() {
        $("#bigdiv").css("background-color", background_Color);
    })

    $("#f-white").mouseenter(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "white")
            $("#bigdiv").css("color", "white");
    })
    $("#f-white").mouseleave(function() {
        $("#bigdiv").css("color", foreground_Color);
    })
    $("#f-red").mouseenter(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "red")
            $("#bigdiv").css("color", "red");
    })
    $("#f-red").mouseleave(function() {
        $("#bigdiv").css("color", foreground_Color);
    })
    $("#f-green").mouseenter(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "green")
            $("#bigdiv").css("color", "green");
    })
    $("#f-green").mouseleave(function() {
        $("#bigdiv").css("color", foreground_Color);
    })
    $("#f-blue").mouseenter(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "blue")
            $("#bigdiv").css("color", "blue");
    })
    $("#f-blue").mouseleave(function() {
        $("#bigdiv").css("color", foreground_Color);
    })
    $("#f-black").mouseenter(function() {
        if(document.getElementById('bigdiv').style.backgroundColor != "black")
            $("#bigdiv").css("color", "black");
    })
    $("#f-black").mouseleave(function() {
        $("#bigdiv").css("color", foreground_Color);
    })
});