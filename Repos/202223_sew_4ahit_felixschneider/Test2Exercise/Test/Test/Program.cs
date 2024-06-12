using Test;

new Thread(new StudentGuide().Run).Start();
new Thread(new StudentGuide().Run).Start();
new Thread(new StudentGuide().Run).Start();
new Thread(new StudentGuide().Run).Start();
new Thread(new StudentGuide().Run).Start();

while (true)
{
    new Thread(new VisitorGroup().Run).Start();
    Thread.Sleep(100);
}