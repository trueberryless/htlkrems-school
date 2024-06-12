namespace LinqExamples
{
    internal class Item
    {
        public int Id { get; set; }
        public string Name { get => $"Item {Id}"; }
        public int OwnerId { get; set; }
    }
}
