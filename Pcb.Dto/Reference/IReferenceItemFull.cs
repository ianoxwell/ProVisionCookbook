
using System;
using System.Collections.Generic;

namespace Pcb.Dto.Reference
{
    /// <summary>
    /// Reference item with full field coverage.
    /// This can be freely passed around the server (it's cached),
    /// but should rarely be returned to the client.
    /// The client is normally only interested in fields within IReferenceItem.
    /// </summary>
    public interface IReferenceItemFull : IReferenceItemEx
    {

    }
}
