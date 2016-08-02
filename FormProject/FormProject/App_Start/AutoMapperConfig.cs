using AutoMapper;
using FormProject.Models;
using FormProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormProject.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Form, FormViewModel>();
                cfg.CreateMap<FormViewModel, Form>();
            });
        }
    }
}