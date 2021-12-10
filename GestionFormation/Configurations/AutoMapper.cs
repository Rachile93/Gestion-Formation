using AutoMapper;
using GestionFormation.Entity;
using GestionFormation.Models;

namespace GestionFormation.Configurations
{
    public class AutoMapperConfigurations : Profile
    {
        public AutoMapperConfigurations()
        {
            CreateMap<Formateur, FormateurViewModel>().ReverseMap();
            CreateMap<Formation, FormationViewModel>().ReverseMap();
            
            // CreateMap<PcrTest, PcrTestViewModel>()
            //     .ForMember(x => x.ReceptionDateee, y => y.MapFrom(z => z.ReceptionDate))
            //     .ReverseMap()
            //     .ForMember(x => x.ReceptionDate, y => y.MapFrom(z => z.ReceptionDateee));

            // CreateMap<PcrTest, PcrTestViewModel>()
            //     .ForMember(x => x.Code, y => y.MapFrom(z => $"{z.Code}{z.Comment}"));
        }
    }
}