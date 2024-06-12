using MarsMission;


Sentinel s1 = new Sentinel("R1D2");
Sentinel s2 = new Sentinel("R2D2");
Harvester h1 = new Harvester("H1V3");
Harvester h2 = new Harvester("H2V3");
Harvester h3 = new Harvester("H3V3");
Harvester h4 = new Harvester("H5V3");

new Thread(s1.Run).Start();
new Thread(s2.Run).Start();
new Thread(h1.Run).Start();
new Thread(h2.Run).Start();
new Thread(h3.Run).Start();
new Thread(h4.Run).Start();