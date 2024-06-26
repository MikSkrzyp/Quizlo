﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Quizlo.API.Model.Domain
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }

        public int QuizID { get; set; }

        [MaxLength(200)]
        public string QuestionText { get; set; }

        [MaxLength(50)]
        public string QuestionType { get; set; }

        [ForeignKey(nameof(QuizID))]
        [JsonIgnore]
        public Quiz Quiz { get; set; }

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
