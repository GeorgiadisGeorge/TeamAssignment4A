﻿using AutoMapper;
using TeamAssignment4A.Dtos;
using TeamAssignment4A.Models;
using TeamAssignment4A.Models.JointTables;

namespace TeamAssignment4A.Profiles
{
    public class Profile: AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Topic,TopicDto>();

            CreateMap<Topic, TopicDto>()

                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NumberOfPossibleMarks, opt => opt.MapFrom(src => src.NumberOfPossibleMarks))
                .ForMember(dest => dest.TitleOfCertificate, opt => opt.MapFrom(src => src.Certificate.TitleOfCertificate))
                .ForMember(dest => dest.Certificate, opt => opt.MapFrom(src => src.Certificate))
                .ReverseMap();
               


            CreateMap<Stem, StemDto>();

            CreateMap<Stem, StemDto>()
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
                .ForMember(dest => dest.OptionA, opt => opt.MapFrom(src => src.OptionA))
                .ForMember(dest => dest.OptionB, opt => opt.MapFrom(src => src.OptionB))
                .ForMember(dest => dest.OptionC, opt => opt.MapFrom(src => src.OptionC))
                .ForMember(dest => dest.OptionD, opt => opt.MapFrom(src => src.OptionD))
                .ForMember(dest => dest.CorrectAnswer, opt => opt.MapFrom(src => src.CorrectAnswer))
                .ForMember(dest => dest.TopicDescription, opt => opt.MapFrom(src => src.Topic.Description))
                .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic))
                .ReverseMap(); 
            
            CreateMap<Exam, ExamDto>();

            CreateMap<Exam, ExamDto>()
                .ForMember(dest => dest.AssessmentTestCode, opt => opt.MapFrom(src => src.AssessmentTestCode))
                .ForMember(dest => dest.ExaminationDate, opt => opt.MapFrom(src => src.ExaminationDate))
                .ForMember(dest => dest.ScoreReportDate, opt => opt.MapFrom(src => src.ScoreReportDate))
                .ForMember(dest => dest.CandidateScore, opt => opt.MapFrom(src => src.CandidateScore))
                .ForMember(dest => dest.PercentageScore, opt => opt.MapFrom(src => src.PercentageScore))
                .ForMember(dest => dest.AssessmentResultLabel, opt => opt.MapFrom(src => src.AssessmentResultLabel))                
                .ForMember(dest => dest.TitleOfCertificate, opt => opt.MapFrom(src => src.Certificate.TitleOfCertificate))
                .ForMember(dest => dest.Certificate, opt => opt.MapFrom(src => src.Certificate))
                .ReverseMap();

            CreateMap<ExamStem, ExamStemDto>();

            CreateMap<ExamStem, ExamStemDto>()
                .ForMember(dest => dest.SubmittedAnswer, opt => opt.MapFrom(src => src.SubmittedAnswer))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
                .ForMember(dest => dest.ExamId, opt => opt.MapFrom(src => src.Exam.Id))
                .ForMember(dest => dest.Exam, opt => opt.MapFrom(src => src.Exam))
                .ForMember(dest => dest.StemId, opt => opt.MapFrom(src => src.Stem.Id))
                .ForMember(dest => dest.Stem, opt => opt.MapFrom(src => src.Stem))
                .ReverseMap();
        }
    }
}
