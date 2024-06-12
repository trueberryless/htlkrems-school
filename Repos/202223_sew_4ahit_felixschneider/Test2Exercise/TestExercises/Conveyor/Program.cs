using Conveyor;

Maschine maschineA = new Maschine("MaschineA", 100, new SemaphoreSlim(0));
Maschine maschineB = new Maschine("MaschineB", 150, new SemaphoreSlim(0));
ConveyorBelt conveyorBelt = new ConveyorBelt();

new Thread(maschineA.Run).Start();
new Thread(maschineB.Run).Start();
new Thread(conveyorBelt.Run).Start();