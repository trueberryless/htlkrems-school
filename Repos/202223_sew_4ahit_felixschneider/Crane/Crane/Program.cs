using Crane;

SemaphoreSlim semaphoreCrane = new SemaphoreSlim(0);
MachineA ma = new MachineA(semaphoreCrane);
MachineB mb = new MachineB(semaphoreCrane);
CraneClass c = new CraneClass(semaphoreCrane, ma, mb);


new Thread(c.Run).Start();
new Thread(ma.Run).Start();
new Thread(mb.Run).Start();