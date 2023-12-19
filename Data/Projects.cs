﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementApp.Data
{
    public partial class Projects
    {
        public Projects()
        {
            Tasks = new HashSet<Tasks>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; } = null!;
        [Column(TypeName = "ntext")]
        public string Description { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? DateDue { get; set; }
        [StringLength(450)]
        public string CreatedBy { get; set; } = null!;
        public int ProjectStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }

    public partial class Projects
    {
        [NotMapped]
        public int TaskCount { get => Tasks.Count; }

        [NotMapped]
        public int TasksCompleted { get => Tasks.Count(t => t.IsComplete); }

        [NotMapped]
        public string DateDueFormatted { get => DateDue?.ToString("yyyy-MM-dd") ?? "Not set"; }

        [NotMapped]
        public string StatusAsString
        {
            get => ProjectStatus switch
            {
                0 => "Not started",
                1 => "In progress",
                2 => "Completed",
                3 => "Cancelled",
                _ => "Unknown"
            };
        }
    }
}