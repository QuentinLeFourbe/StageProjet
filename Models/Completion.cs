using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormProject.Models
{
    public class Completion
    {
        public string Firstname;

        public string Lastname;

        public int QuestionId;

        public int PossibleAnswerId;

        public Question Question;

        public PossibleAnswer PossibleAnswer;
    }
}