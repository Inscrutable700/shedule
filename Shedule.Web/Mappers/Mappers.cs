using AutoMapper;
using Shedule.Data.Model;
using Shedule.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.Mappers
{
    public class CustomMappers
    {
        public static void InitializeAllMappers()
        {
            Mapper.CreateMap<Teaching, TeachingViewModel>();
            Mapper.CreateMap<TeachingViewModel, Teaching>();
        }
    }
}