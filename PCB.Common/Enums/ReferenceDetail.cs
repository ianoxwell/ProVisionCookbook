namespace Pcb.Common.Enums
{
    /// <summary>
    /// The level of detail to be returned for requested reference items.
    /// </summary>
    public enum ReferenceDetail
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>{Id,Title}</summary>
        Basic = 1,  // Start at 1 to ensure all values are javascript-truthy.

        /// <summary>Basic + {Code,Summary}</summary>
        Extended,

    }
}
