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
    
    public partial class TransformationModelText
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransformationModelText()
        {
            this.TransformationRules = new HashSet<TransformationRuleModelText>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelGraphId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransformationRuleModelText> TransformationRules { get; set; }
        public virtual ModelGraph ModelGraph { get; set; }
    }
}