using System.Collections.Generic;

namespace Pcb.Dto.Reference
{
    /// <summary>
    /// Details required to generically view/edit any reference item.
    /// </summary>
    public class ReferenceContext
    {
        public ReferenceType Type { get; set; }

        public IEnumerable<ReferenceMeta> Meta { get; set; }

        public IReferenceItemFull Data { get; set; }

        public IDictionary<string, IEnumerable<IReferenceItem>> RefData { get; set; }
    }
}
