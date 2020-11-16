namespace Pcb.Dto.Reference
{
    /// <summary>
    /// Metadata for generically viewing/editing reference data.
    /// </summary>
    public class ReferenceMeta
    {
        /// <summary>The reference type of this metadata, e.g. all ref.Facility metadata will be ReferenceType.Facility</summary>
        public ReferenceType ReferenceType { get; set; }

        /// <summary>Field name</summary>
        public string Name { get; set; }

        /// <summary>The HTML input type used to edit the field</summary>
        public string InputType { get; set; }

        /// <summary>
        /// Category of field, determining where to find its value.
        /// e.g. Standard = direct property access, Flag = Flags dictionary, etc.
        /// </summary>
        public ReferenceMetaCategory Category { get; set; }

        /// <summary>Required</summary>
        public bool IsRequired { get; set; }

        /// <summary>Read-only</summary>
        public bool IsReadOnly { get; set; }

        /// <summary>Allows fields not-relevant for edit to be hidden</summary>
        public bool IsVisible { get; set; }

        /// <summary>Name of the type this field references, where available</summary>
        public ReferenceType? References { get; set; }
    }
}
