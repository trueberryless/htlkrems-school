function OpenWin(url,name,height,width)
{
  var InfoWin = window.open(url,name,"directories=0,height="+height+",width=" + width + ",hotkeys=0,location=0,menubar=0,resizable=1,screenX=150,screenY=10,left=150,top=10,scrollbars=1,status=1,titlebar=0,toolbar=0");
  InfoWin.focus();
}