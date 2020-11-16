namespace Pcb.Dto.Reference
{
    /// <summary>
    /// Reference field categories.
    /// Standard is accessed directly by property,
    /// Flag, Reference and Other are accessed by name in a specifically typed dictionary,
    /// e.g. Flags["IsOk"] or Reference["FacilityId"]
    /// </summary>
    public enum ReferenceMetaCategory
    {
        Standard = 1,   // Start at 1 to ensure all values are javascript-truthy.
        Flag,
        Reference,
        Other
    }
}
