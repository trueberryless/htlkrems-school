using Conveyor;

Thread ta = new Thread(new MachineA().Run);
Thread tb = new Thread(new MachineB().Run);
Thread tc = new Thread(new ConveyorBelt().Run);
            
ta.Start();
tb.Start();
tc.Start();