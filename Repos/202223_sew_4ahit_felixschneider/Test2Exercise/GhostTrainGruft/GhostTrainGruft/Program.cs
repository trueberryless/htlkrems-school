using GhostTrainGruft;

Task.Run(new GhostTrain().Run);

while (true)
{
    Task.Run(new Customer().Run);
    Thread.Sleep(10);
}