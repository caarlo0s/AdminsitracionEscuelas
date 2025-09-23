using AdminSchool.Application.Common.Dtos;
using AdminSchool.Application.UserApp.Commands.AddUser;
using AdminSchool.Domain.Common;
using AdminSchool.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.AutoMapper
{
    public class MappingProfile :Profile
    {

        public MappingProfile() {
            CreateMap<Users, UserInfoDto>();
            CreateMap<AddUserCommand, Users>();

            CreateMap<Users, UserListDto>();

            CreateMap<Users, UserUpdateInfo>();

            CreateMap<Tutor,TutorsStudentDto>();

            CreateMap<Student,GetAllStudentsDto>()
                .ForMember(src=>src.GroupName, opt=>opt.MapFrom(m=>m.Group.Name))
                .ForMember(src => src.GradeName, opt => opt.MapFrom(m => m.Group.Grade.Name));

            CreateMap<EducationLevel, GetAllEducationLevelsDto>();
        } 
    }
}
