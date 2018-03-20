//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Relationship : ICloneable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Relationship()
        {
            this.Attributes = new HashSet<Attribute>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Multiplicity1 { get; set; }
        public int Multiplicity2 { get; set; }
        public NameUniqueType NameUniqueFlag { get; set; }
        public RelationshipType Type { get; set; }
        public int ModelGraphId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attribute> Attributes { get; set; }
        public virtual RelationshipParent RelationshipParent { get; set; }
        public virtual ModelGraph ModelGraph { get; set; }
        public virtual Entity Entity1 { get; set; }
        public virtual Entity Entity2 { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
