using AutoMapper;
using SchoolAPI.Data.Dto.Address;
using SchoolAPI.Data.Dto.Grades;
using SchoolAPI.Data.Dto.Matter;
using SchoolAPI.Data.Dto.MatterProfessor;
using SchoolAPI.Data.Dto.Professor;
using SchoolAPI.Data.Dto.Student;
using SchoolAPI.Data.Model;
using System.Reflection;
using System.Xml;

namespace SchoolAPI.Profiles;

public class MapConfig : Profile
{
    public MapConfig()
    {
        #region Address

        CreateMap<ReadAddressDto, Address>().ReverseMap();
        CreateMap<PostUpdateAddressDto, Address>().ReverseMap();

        #endregion

        #region Grades

        CreateMap<Grades, ReadGradesDto>()
            .ForMember(x => x.StudentName, x => x.MapFrom(x => x.Students.Name))
            .ForMember(x => x.MatterName, x => x.MapFrom(x => x.Matters.Name))
            .ReverseMap();

        CreateMap<PostUpdateGradesDto, Grades>().ReverseMap();

        CreateMap<Grades, ReadGradesByStudentIdDto>()
            .ForMember(x => x.StudentName, x => x.MapFrom(x => x.Students.Name))
            .ForMember(x => x.MatterName, x => x.MapFrom(x => x.Matters.Name))
            .ForMember(x => x.Gpa, x => x.MapFrom(x => ((x.Grades1 + x.Grades2 + x.Grades3 + x.Grades4) / 4)))
            .ForMember(x => x.Status, x => x.MapFrom(x => ((x.Grades1 + x.Grades2 + x.Grades3 + x.Grades4) / 4) >= 5 ? "approved" : "failed"))
            .ReverseMap();

        #endregion

        #region Student

        CreateMap<Student, ReadStudentDto>()
            .ForMember(x => x.Cep, x => x.MapFrom(x => x.Address.Cep))
            .ForMember(x => x.Street, x => x.MapFrom(x => x.Address.Street))
            .ForMember(x => x.Number, x => x.MapFrom(x => x.Address.Number))
            .ForMember(x => x.Neighborhood, x => x.MapFrom(x => x.Address.Neighborhood))
            .ForMember(x => x.City, x => x.MapFrom(x => x.Address.City))
            .ForMember(x => x.Uf, x => x.MapFrom(x => x.Address.Uf))
            .ReverseMap();

        CreateMap<PostUpdateStudentDto, Student>().ReverseMap();

        #endregion

        #region Matter

        CreateMap<Matter, ReadMatterDto>().ReverseMap();
        CreateMap<Matter, PostUpdateMatterDto>().ReverseMap();

        #endregion

        #region Professor

        CreateMap<Professor, ReadProfessorDto>().ReverseMap();

        CreateMap<PostUpdateProfessorDto, Professor>().ReverseMap();

        #endregion

        #region MatterProfessor

        CreateMap<MatterProfessor, ReadMatterProfessorDto>()
            .ForMember(x => x.ProfessorName, x => x.MapFrom(x => x.Professor.Name))
            .ForMember(x => x.MatterName, x => x.MapFrom(x => x.Matter.Name))
            .ReverseMap();

        CreateMap<PostUpdateMatterProfessorDto, MatterProfessor>().ReverseMap();

        #endregion
    }
}

