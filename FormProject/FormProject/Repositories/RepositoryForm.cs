using FormProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormProject.Repositories
{
    public class RepositoryForm : RepositoryBase<FormModel, Form>
    {
        public Form GetSingle(int id)
        {
            var query = DbContext.Form.FirstOrDefault(x => x.Id == id);
            return query;
        }

        public List<Form> GetList()
        {
            var query = DbContext.Form.ToList();
            return query;
        }

        public Form GetCompleteForm(int id)
        {
            return DbContext.Form
                               .Include("Block")
                               .Include("Block.Question")
                               .Include("Block.Question.PossibleAnswer")
                               .FirstOrDefault(x => x.Id == id);
           
        }

    }
}