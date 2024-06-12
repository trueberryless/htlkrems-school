namespace CodeSamples
{
    /// <summary>
    /// Provides electricity to its consumers as long as there is enough free capacity.
    /// </summary>
    public static class ElectricGenerator
    {
        private static IList<IEnergyConsumer> consumers = new List<IEnergyConsumer>();
        private static double capacity = 1000;

        /// <summary>
        /// Maximum amount of produced energy.
        /// Default: 1000
        /// </summary>
        public static double Capacity
        {
            get => capacity;
            set
            {
                // don't allow values smaller than zero
                capacity = Math.Max(0, value);
            }
        }

        public static double CurrentConsumption =>
            consumers.Sum(c => c.GetCurrentConsumption());

        public static double FreeCapacity =>
            Capacity - CurrentConsumption;

        public static void AddConsumer(IEnergyConsumer consumer)
        {
            if (consumer.GetCurrentConsumption() > FreeCapacity)
            {
                throw new Exception("Consumer exceeds capacity.");
            }

            consumers.Add(consumer);
        }

        public static void AddConsumers(IEnumerable<IEnergyConsumer> consumersToAdd)
        {
            foreach (var consumer in consumersToAdd)
            {
                consumers.Add(consumer);
            }
        }

        public static void RemoveConsumer(IEnergyConsumer consumer)
        {
            consumers.Remove(consumer);
        }

        /// <summary>
        /// Returns all currently attached consumers that fit the condition specified by the predicate.
        /// </summary>
        public static IEnumerable<IEnergyConsumer> GetConsumerBy(Func<IEnergyConsumer, bool> predicate)
            => consumers.Where(predicate);
    }

    /// <summary>
    /// Consumes energy provided by an <see cref="ElectricGenerator"/>.
    /// </summary>
    public interface IEnergyConsumer
    {
        public double GetCurrentConsumption();
    }

    public class Machine : IEnergyConsumer
    {
        public string MachineName { get; set; }
        public string Vendor { get; set; }
        public double EnergyConsumption { get; init; } = 0;

        public double GetCurrentConsumption()
        {
            return EnergyConsumption;
        }
    }

    public class LightSource : IEnergyConsumer
    {
        public double GetCurrentConsumption()
        {
            // We assume all light sources have a unified consumption.
            return 20;
        }
    }
}

