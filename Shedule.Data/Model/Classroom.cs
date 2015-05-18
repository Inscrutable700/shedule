namespace Shedule.Data.Model
{
    /// <summary>
    /// The Classroom class.
    /// </summary>
    public class Classroom
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the name of the building.
        /// </summary>
        public string BuildingName { get; set; }
    }
}
