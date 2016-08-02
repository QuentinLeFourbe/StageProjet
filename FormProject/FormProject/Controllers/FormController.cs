using FormProject.Models;
using FormProject.Repositories;
using FormProject.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormProject.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            using (RepositoryForm entities = new RepositoryForm())
            {
                var formList = entities.GetList();
                return View(formList);
            }
        }

        public ActionResult ViewForm(int id)
        {
            using (RepositoryForm entities = new RepositoryForm())
            {
                var formReturn = entities.GetCompleteForm(id);
                return View(formReturn);
            }
        }




        // GET: Form/Create
        public ActionResult NewForm(int id = 0)
        {
            using (RepositoryForm entities = new RepositoryForm())
            {
                if (id == 0)
                {
                    var model = new FormViewModel
                        {
                            Block =
                                {
                                new Block
                                    {
                                    Question =
                                        {
                                        new Question
                                            {
                                            Title = "Sur une échelle de 1 à 5 quel est votre niveau de satisfaction",
                                            Type = 2,
                                            PossibleAnswer =
                                                {
                                                new PossibleAnswer { Title = "1" },
                                                new PossibleAnswer { Title = "2" },
                                                new PossibleAnswer { Title = "3" },
                                                new PossibleAnswer { Title = "4" },
                                                new PossibleAnswer { Title = "5" }
                                                }
                                            }
                                        }
                                    }
                                }
                        };
                        return View(model);
                    }
                else
                {
                    var form = entities.GetCompleteForm(id);
                    var model = AutoMapper.Mapper.Map<FormViewModel>(form);
                    return View(model);
                }
            }
        }

        // POST: Form/Create
        [HttpPost]
        public ActionResult NewForm(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                using (RepositoryForm context = new RepositoryForm())
                {
                    var model = AutoMapper.Mapper.Map<Form>(form);
                    model.DateCreation = DateTime.Now;
                    if (context.GetSingle(model.Id) != null)
                    {
                        context.Update(model);
                        return RedirectToAction("Index");
                    }
                    context.Create(model);
                    return RedirectToAction("Index");
                }
            }
            HttpNotFound();
            return View();

        }



        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {
            using (RepositoryForm context = new RepositoryForm())
            {
                var item = context.GetSingle(id);
                context.Delete(item);
                return RedirectToAction("Index");
            }

        }


    }
}
