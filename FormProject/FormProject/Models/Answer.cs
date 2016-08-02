namespace FormProject.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        public int Id { get; set; }

        public int PossibleAnswerId { get; set; }

        public int QuestionId { get; set; }

        [StringLength(500)]
        public string UserAnswer { get; set; }

        [JsonIgnore]
        public virtual PossibleAnswer PossibleAnswer { get; set; }

        [JsonIgnore]
        public virtual Question Question { get; set; }
    }
}
