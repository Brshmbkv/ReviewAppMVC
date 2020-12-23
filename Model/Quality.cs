using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Quality
    {
        [BindNever]
        public int Id { get; set; }
        [Required]
        public QualityLevel Smile { get; set; }
        [Required]
        public QualityLevel Beauty { get; set; }
        [Required]
        public QualityLevel Nature { get; set; }
        [Required]
        public QualityLevel Character { get; set; }
        [Required]
        public QualityLevel Communication { get; set; }
        [Required]
        public QualityLevel Humor { get; set; }
        [Required]
        public string ReviewText { get; set; }
        public Person Person { get; set; }
    }

    public enum QualityLevel
    {
        VeryLow,
        Low,
        Normal,
        High,
        VeryHigh
    }
}
