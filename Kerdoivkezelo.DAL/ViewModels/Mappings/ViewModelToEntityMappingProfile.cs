using AutoMapper;
using Kerdoivkezelo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, User>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
