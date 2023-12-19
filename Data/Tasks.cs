﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementApp.Data
{
    public partial class Tasks
    {
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Title { get; set; } = null!;
        public int TaskStatus { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("Tasks")]
        public virtual Projects Project { get; set; } = null!;
    }

    public partial class Tasks
    {
        [NotMapped]
        public bool IsComplete { get => TaskStatus == 1; set => TaskStatus = value ? 1 : 0; }
    }
}