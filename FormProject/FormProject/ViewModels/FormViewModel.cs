using FormProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormProject.ViewModels
{

    public class FormViewModel
    {
        public FormViewModel()
        {
            Block = new HashSet<Block>();
        }
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<Block> Block { get; set; }
        
    }
}