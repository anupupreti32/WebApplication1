using WebApplication1.DTOS.Certificate;
using WebApplication1.DTOS.Education;
using WebApplication1.DTOS.Profile;
using WebApplication1.DTOS.Project;
using WebApplication1.DTOS.Reference;
using WebApplication1.DTOS.Skill;
using WebApplication1.DTOS.WorkExperience;
using WebApplication1.Models;
//using Profile = AutoMapper.Profile;

namespace WebApplication1.Utilities;

public class MappingProfile : AutoMapper.Profile 
{

    public MappingProfile()
    {
        //ProfileMapping
        CreateMap<ProfileCreateDTO, Profile>();
        CreateMap<ProfileUpdateDTO, Profile>();
        CreateMap<Profile, ProfileUpdateDTO>();
        CreateMap<Profile, ProfileReadDTO>();
        
        //CertificateMapping
        CreateMap<CertificateCreateDTO, Certificate>();
        CreateMap<CertificateUpdateDTO, Certificate>();
        CreateMap<Certificate, CertificateReadDTO>();
        CreateMap<Certificate, CertificateUpdateDTO>();
        
        //EducationMapping
        CreateMap<EducationCreateDTO, Education>();
        CreateMap<EducationUpdateDTO, Education>();
        CreateMap<Education, EducationReadDTO>();
        CreateMap<Education, EducationUpdateDTO>();
        
        //ProjectMapping
        CreateMap<ProjectCreateDTO, Project>();
        CreateMap<ProjectUpdateDTO, Project>();
        CreateMap<Project, ProjectReadDTO>();
        CreateMap<Project, ProjectUpdateDTO>();
        
        //ReferenceMapping
        CreateMap<ReferenceCreateDTO, Reference>();
        CreateMap<ReferenceUpdateDTO, Reference>();
        CreateMap<Reference, ReferenceReadDTO>();
        CreateMap<Reference, ReferenceUpdateDTO>();
        
        //SkillMapping
        CreateMap<SkillCreateDTO, Skill>();
        CreateMap<SkillUpdateDTO, Skill>();
        CreateMap<Skill, SkillReadDTO>();
        CreateMap<Skill, SkillUpdateDTO>();
        
        //WorkExperinenceMapping
        CreateMap<WorkExperienceCreateDTO, WorkExperience>();
        CreateMap<WorkExperienceUpdateDTO, WorkExperience>();
        CreateMap<WorkExperience, WorkExperienceReadDTO>();
        CreateMap<WorkExperience, WorkExperienceUpdateDTO>();
    }

    
}