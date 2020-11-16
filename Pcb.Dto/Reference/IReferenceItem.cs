
namespace Pcb.Dto.Reference
{
    /// <summary>
    /// Basic reference item with common fields needed to
    /// get the job done 99% of the time.
    /// </summary>
    public interface IReferenceItem
    {
        /// <summary>
        /// Primary key
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Brief description suitable for use in HTML select elements
        /// </summary>
        string Title { get; }
    }
}
