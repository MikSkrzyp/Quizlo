using AutoMapper;
using Quizlo.API.Model.Domain;
using Quizlo.API.Model.DTOs;

namespace Quizlo.API.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        /*CreateMap<Quiz, QuizDto>().ReverseMap();
        CreateMap<Question, QuestionDto>().ReverseMap();
        CreateMap<Answer, AnswerDto>().ReverseMap();
        CreateMap<Quiz, QuizCreateDto>().ReverseMap();
        CreateMap<Question, QuestionCreateDto>().ReverseMap();
        CreateMap<Answer, AnswerCreateDto>().ReverseMap();*/
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<User,GetUserDTO>().ReverseMap();
        CreateMap<CreateQuizDto,Quiz>().ReverseMap();
        CreateMap<Quiz,GetQuizDTO>().ReverseMap();

    }
    
}