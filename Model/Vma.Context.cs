﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VmaContainer : DbContext
    {
        public VmaContainer()
            : base("name=VmaContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TransformationRuleModelModel> TransformationRuleModelModelSet { get; set; }
        public virtual DbSet<TransformationRuleModelText> TransformationRuleModelTextSet { get; set; }
        public virtual DbSet<TransformationModelText> TransformationModelTextSet { get; set; }
        public virtual DbSet<TransformationModelModel> TransformationModelModelSet { get; set; }
        public virtual DbSet<Attribute> AttributeSet { get; set; }
        public virtual DbSet<RelationshipParent> RelationshipParentSet { get; set; }
        public virtual DbSet<ModelGraphParent> ModelGraphParentSet { get; set; }
        public virtual DbSet<ModelGraph> ModelGraphSet { get; set; }
        public virtual DbSet<Entity> EntitySet { get; set; }
        public virtual DbSet<EntityParent> EntityParentSet { get; set; }
        public virtual DbSet<Relationship> RelationshipSet { get; set; }
    }
}