using AutoMapper;
using WebUI.Client;
using WebUI.Filters;
using WebUI.Models.AboutUs;
using WebUI.Models.AboutusDto;
using WebUI.Models.Banner;
using WebUI.Models.City;
using WebUI.Models.contactusDto;
using WebUI.Models.Donationmethod;
using WebUI.Models.FirstSubclass;
using WebUI.Models.Gender;
using WebUI.Models.GovernanceClassification;
using WebUI.Models.Lookups;
using WebUI.Models.Masarat;
using WebUI.Models.News;
using WebUI.Models.Payment;
using WebUI.Models.Product;
using WebUI.Models.ProductType;
using WebUI.Models.ProductUnit;
using WebUI.Models.QualitativeClassfication;
using WebUI.Models.Question;
using WebUI.Models.Region;
using WebUI.Models.Reports;
using WebUI.Models.SecondSubclass;
using WebUI.Models.SocialMedia;
using WebUI.Models.TopGivers;
using DedicatedToPaymentLookup = WebUI.Client.DedicatedToPaymentLookup;
using QuickPaymentAmount = WebUI.Client.QuickPaymentAmount;
using SigningTheDonationGift = WebUI.Client.SigningTheDonationGift;

namespace WebUI.Mapping;

public class MappingProfileWeb : Profile
{
    public MappingProfileWeb()
    {
        CreateMap<UpdateQuestion, GetQuestionQueryResult>()
           .ForMember(d => d.QuestionAr, opt => opt.MapFrom(s => s.QuestionAr.ToString().Trim()))
          .ForMember(d => d.QuestionEn, opt => opt.MapFrom(s => s.QuestionEn.ToString().Trim()))
          .ForMember(d => d.AnswerAr, opt => opt.MapFrom(s => s.AnswerAr.Trim()))
          .ForMember(d => d.AnswerEN, opt => opt.MapFrom(s => s.AnswerEn.Trim()))
            .ForMember(d => d.QuestionStatue, opt => opt.MapFrom(s => s.QuestionStatues))
            .ForMember(d => d.PriorityNumber, opt => opt.MapFrom(s => s.QuestionPriority))
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.QuestionId))
            .ReverseMap();


        CreateMap<UpdateQuestion, UpdateQuestionCommand>()

          .ForMember(d => d.QuestionAr, opt => opt.MapFrom(s => s.QuestionAr.ToString().Trim()))
          .ForMember(d => d.QuestionEn, opt => opt.MapFrom(s => s.QuestionEn.ToString().Trim()))
          .ForMember(d => d.AnswerAr, opt => opt.MapFrom(s => s.AnswerAr.Trim()))
          .ForMember(d => d.AnswerEN, opt => opt.MapFrom(s => s.AnswerEn.Trim()))
          .ForMember(d => d.QuestionStatue, opt => opt.MapFrom(s => s.QuestionStatues))
          .ForMember(d => d.PriorityNumber, opt => opt.MapFrom(s => s.QuestionPriority))
          .ForMember(d => d.Id, opt => opt.MapFrom(s => s.QuestionId))
          .ReverseMap();


        CreateMap<CreateQuestionViewModel, AddNewQuestionCommand>()

         .ForMember(d => d.QuestionAr, opt => opt.MapFrom(s => s.QuestionAr.ToString().Trim()))
         .ForMember(d => d.QuestionEn, opt => opt.MapFrom(s => s.QuestionEN.ToString().Trim()))
         .ForMember(d => d.AnswerAr, opt => opt.MapFrom(s => s.AnswerAR.Trim()))
         .ForMember(d => d.AnswerEN, opt => opt.MapFrom(s => s.AnswerEN.Trim()))
         .ForMember(d => d.QuestionStatue, opt => opt.MapFrom(s => s.QuestionStatues))
         .ForMember(d => d.PriorityNumber, opt => opt.MapFrom(s => s.QuestionPriority))

         .ReverseMap();


        CreateMap<SetPaswordCommand, CreatePassword>()
         .ForMember(d => d.OTP, opt => opt.MapFrom(s => s.Otp))
         .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Pasword))
         .ForMember(d => d.VerifyPassword, opt => opt.MapFrom(s => s.VerifyPassword))
         .ReverseMap();


        CreateMap<MasaratDto, AddNewMasaratItemCommand>()
        .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
        .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
        .ForMember(d => d.DescriptionAr, opt => opt.MapFrom(s => s.DescriptionArbic))
        .ForMember(d => d.DescriptionEn, opt => opt.MapFrom(s => s.DescriptionEnglish))
        .ReverseMap();

        CreateMap<MasaratDto, EditMasaratItemCommand>()
       .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
       .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
       .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
       .ForMember(d => d.DescriptionAr, opt => opt.MapFrom(s => s.DescriptionArbic))
       .ForMember(d => d.DescriptionEn, opt => opt.MapFrom(s => s.DescriptionEnglish))
       .ForMember(d => d.IconIsEdit, opt => opt.MapFrom(s => s.IconIsEdit))
       .ForMember(d => d.OtherImagesIsEdit, opt => opt.MapFrom(s => s.OtherImagesIsEdit))
       //.ForMember(d => d.OtherImages, opt => opt.MapFrom(s => s.OtherImageDto))
       //.ForMember(d => d.FirstIsEdit, opt => opt.MapFrom(s => s.FirstIsEdit))
       //.ForMember(d => d.SecondIsEdit, opt => opt.MapFrom(s => s.SecondIsEdit))
       .ReverseMap();


        CreateMap<MasaratDto, GetMasaratItemToEditQueryResult>()
        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
        .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
        .ForMember(d => d.DiscriptionAr, opt => opt.MapFrom(s => s.DescriptionArbic))
        .ForMember(d => d.DiscriptionEn, opt => opt.MapFrom(s => s.DescriptionEnglish))

        .ReverseMap();

        CreateMap<ProductUnitModel, GetProductUnitByIdQueryResult>()
           .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
           .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
           .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
           .ReverseMap();


        CreateMap<RegionModel, GetRegionByIdQueryResult>()
         .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
         .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
         .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
         .ForMember(d => d.PostalCode, opt => opt.MapFrom(s => s.PostalCode))
         .ReverseMap();


        CreateMap<CityModel, GetCityByIdQueryResult>()
        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
        .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
        .ForMember(d => d.CountyId, opt => opt.MapFrom(s => s.CountryId))
        .ReverseMap();



     


        CreateMap<GovernanceClassificationModel, GetGovernanceClassificationByIdQueryResult>()
   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
   .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
   .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
   .ReverseMap();


        CreateMap<FirstSubclassModel, GetFirstSubclassByIdQueryResult>()
   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
   .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
   .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
   .ReverseMap();


        CreateMap<GenderModel, GetGenderByIdQueryResult>()
 .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
 .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
 .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
 .ReverseMap();


        CreateMap<ProductTypeModel, GetProductTypeByIdQueryResult>()
 .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
 .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
 .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
 .ReverseMap();

        CreateMap<DonationmethodModel, GetDonationmethodByIdQueryResult>()
.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
.ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
.ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
.ReverseMap();




        CreateMap<SecondSubclassModel, GetSecondSubclassByIdQueryResult>()
.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
.ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
.ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
.ReverseMap();

        CreateMap<NewsDto, AddNewsCommand>()
       .ForMember(d => d.TitleAr, opt => opt.MapFrom(s => s.TitleAr))
       .ForMember(d => d.TitleEn, opt => opt.MapFrom(s => s.TitleEn))
       .ForMember(d => d.SummaryAr, opt => opt.MapFrom(s => s.SummaryAr))
       .ForMember(d => d.SummaryEn, opt => opt.MapFrom(s => s.SummaryEn))
       .ForMember(d => d.DetailsAr, opt => opt.MapFrom(s => s.DetailsAr))
       .ForMember(d => d.DetailsEn, opt => opt.MapFrom(s => s.DetailsEn))
       .ForMember(d => d.NewsStatus, opt => opt.MapFrom(s => s.NewsStatus))
       .ReverseMap();

        CreateMap<NewsDto, CMSNewsQueryResult>()
       .ForMember(d => d.NewsId, opt => opt.MapFrom(s => s.NewsId))
       .ForMember(d => d.TitleAr, opt => opt.MapFrom(s => s.TitleAr))
       .ForMember(d => d.TitleEn, opt => opt.MapFrom(s => s.TitleEn))
       .ForMember(d => d.SummaryAr, opt => opt.MapFrom(s => s.SummaryAr))
       .ForMember(d => d.SummaryEn, opt => opt.MapFrom(s => s.SummaryEn))
       .ForMember(d => d.DetailsAr, opt => opt.MapFrom(s => s.DetailsAr))
       .ForMember(d => d.DetailsEn, opt => opt.MapFrom(s => s.DetailsEn))
       .ForMember(d => d.Status, opt => opt.MapFrom(s => s.NewsStatus))
       .ForPath(d => d.NewsImageDto.ImageId, opt => opt.MapFrom(s => s.ImageId))
       .ForPath(d => d.NewsImageDto.Url, opt => opt.MapFrom(s => s.ImgUrl))

       .ReverseMap();

        CreateMap<NewsDto, UpdateNewsCommand>()
       .ForMember(d => d.Id, opt => opt.MapFrom(s => s.NewsId))
       .ForMember(d => d.TitleAr, opt => opt.MapFrom(s => s.TitleAr))
       .ForMember(d => d.TitleEn, opt => opt.MapFrom(s => s.TitleEn))
       .ForMember(d => d.SummaryAr, opt => opt.MapFrom(s => s.SummaryAr))
       .ForMember(d => d.SummaryEn, opt => opt.MapFrom(s => s.SummaryEn))
       .ForMember(d => d.DetailsAr, opt => opt.MapFrom(s => s.DetailsAr))
       .ForMember(d => d.DetailsEn, opt => opt.MapFrom(s => s.DetailsEn))
       .ForMember(d => d.NewsStatus, opt => opt.MapFrom(s => s.NewsStatus))
       .ForMember(d => d.EditImage, opt => opt.MapFrom(s => s.EditImage))
       .ReverseMap();


        CreateMap<BannerEditDto, GetBannerQueryResult>()
      .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
      .ForMember(d => d.BannerNameAr, opt => opt.MapFrom(s => s.NameAr))
      .ForMember(d => d.BannerNameEn, opt => opt.MapFrom(s => s.NameEn))
      .ForMember(d => d.BannerDetailsAr, opt => opt.MapFrom(s => s.DescriptionArbic))
      .ForMember(d => d.BannerDetailsEn, opt => opt.MapFrom(s => s.DescriptionEnglish))
      .ForMember(d => d.StartAt, opt => opt.MapFrom(s => s.StartAt))
      .ForMember(d => d.EndAt, opt => opt.MapFrom(s => s.EndAt))
      .ForMember(d => d.IsBannerVideo, opt => opt.MapFrom(s => s.IsBannerVideo))
      .ForMember(d => d.Url, opt => opt.MapFrom(s => s.URL))
      .ForMember(d => d.Status, opt => opt.MapFrom(s => s.status))
      .ForMember(d => d.Periorty, opt => opt.MapFrom(s => s.Periorty))
      .ReverseMap();

        CreateMap<SiteContentDto, GetAllAboutUsQueryResult>()

      .ForMember(d => d.IdeaArDescription, opt => opt.MapFrom(s => s.IdeaArDescription))
      .ForMember(d => d.IdeaEnDescription, opt => opt.MapFrom(s => s.IdeaEnDescription))
      .ForMember(d => d.WaqfiPlatformARDescsription, opt => opt.MapFrom(s => s.WaqfiPlatformARDescsription))
      .ForMember(d => d.WaqfiPlatformEnDescription, opt => opt.MapFrom(s => s.WaqfiPlatformEnDescription))
      .ForMember(d => d.PlatformExpectedEffectEnDescription, opt => opt.MapFrom(s => s.PlatformExpectedEffectEnDescription))
      .ForMember(d => d.PlatformExpectedEffectArDescription, opt => opt.MapFrom(s => s.WaqfiPlatformARDescsription))
      .ForMember(d => d.TargetArDescription, opt => opt.MapFrom(s => s.TargetArDescription))
      .ForMember(d => d.TargetEnDescription, opt => opt.MapFrom(s => s.TargetEnDescription))
      .ForMember(d => d.ProductArDescription, opt => opt.MapFrom(s => s.ProductArDescription))
      .ForMember(d => d.ProductEnDescription, opt => opt.MapFrom(s => s.ProductEnDescription))
      .ForMember(d => d.SiteContentImage, opt => opt.MapFrom(s => s.SiteContentImage))
      .ReverseMap();

        CreateMap<SiteContentDto, EditAboutUsCommand>()

     .ForPath(d => d.AboutUsDto.IdeaArDescription, opt => opt.MapFrom(s => s.IdeaArDescription))
     .ForPath(d => d.AboutUsDto.IdeaEnDescription, opt => opt.MapFrom(s => s.IdeaEnDescription))
     .ForPath(d => d.AboutUsDto.WaqfiPlatformARDescsription, opt => opt.MapFrom(s => s.WaqfiPlatformARDescsription))
     .ForPath(d => d.AboutUsDto.WaqfiPlatformEnDescription, opt => opt.MapFrom(s => s.WaqfiPlatformEnDescription))
     .ForPath(d => d.AboutUsDto.PlatformExpectedEffectEnDescription, opt => opt.MapFrom(s => s.PlatformExpectedEffectEnDescription))
     .ForPath(d => d.AboutUsDto.PlatformExpectedEffectArDescription, opt => opt.MapFrom(s => s.WaqfiPlatformARDescsription))
     .ForPath(d => d.AboutUsDto.TargetArDescription, opt => opt.MapFrom(s => s.TargetArDescription))
     .ForPath(d => d.AboutUsDto.TargetEnDescription, opt => opt.MapFrom(s => s.TargetEnDescription))
     .ForPath(d => d.AboutUsDto.ProductArDescription, opt => opt.MapFrom(s => s.ProductArDescription))
     .ForPath(d => d.AboutUsDto.ProductEnDescription, opt => opt.MapFrom(s => s.ProductEnDescription))
     .ForPath(d => d.AboutUsDto.SiteContentImage, opt => opt.MapFrom(s => s.SiteContentImage))
     .ReverseMap();


        CreateMap<WagfiProductDetaliesQueryResult, AwqafProductDto>()
       .ForPath(d => d.ProductNameAr, opt => opt.MapFrom(s => s.ProductName))
       .ForPath(d => d.ProductNameEng, opt => opt.MapFrom(s => s.ProductNameEn))
       .ForPath(d => d.Amount, opt => opt.MapFrom(s => decimal.Parse(s.Amount)))
       .ForPath(d => d.MasarId, opt => opt.MapFrom(s => s.MasarID))
       .ForPath(d => d.Id, opt => opt.MapFrom(s => s.RequestId))
       .ReverseMap();


        CreateMap<AddWaqfiProductCommand, AwqafProductDto>()
     .ForPath(d => d.Id, opt => opt.MapFrom(s => s.Id))
     .ForPath(d => d.ProductNameAr, opt => opt.MapFrom(s => s.ProductNameAr))
     .ForPath(d => d.ProductNameEng, opt => opt.MapFrom(s => s.ProductNameEng))
     .ForPath(d => d.MasarId, opt => opt.MapFrom(s => s.MasarId))
     .ForPath(d => d.MasarFileId, opt => opt.MapFrom(s => s.MasarFileId))
     .ForPath(d => d.DonationMethod, opt => opt.MapFrom(s => s.DonationMethod))
     .ForPath(d => d.UnitType, opt => opt.MapFrom(s => s.UnitType))
     .ForPath(d => d.UnitPrice, opt => opt.MapFrom(s => s.UnitPrice))
     .ForPath(d => d.UnitCount, opt => opt.MapFrom(s => s.UnitCount))
     .ForPath(d => d.ForWhomAr, opt => opt.MapFrom(s => s.ForWhomAr))
     .ForPath(d => d.ForWhomEn, opt => opt.MapFrom(s => s.ForWhomEn))
     .ForPath(d => d.HowDoISupportThemEn, opt => opt.MapFrom(s => s.HowDoISupportThemEn))
     .ForPath(d => d.HowDoISupportThemAr, opt => opt.MapFrom(s => s.HowDoISupportThemAr))
     .ForPath(d => d.WhyDoISupportThemAr, opt => opt.MapFrom(s => s.WhatDoesOneDeviceOfferAr))
     .ForPath(d => d.WhyDoISupportThemEn, opt => opt.MapFrom(s => s.WhatDoesOneDeviceOfferEn))
     .ForPath(d => d.TheTypeOfBeneficiaryEn, opt => opt.MapFrom(s => s.TheTypeOfBeneficiaryEn))
     .ForPath(d => d.TheTypeOfBeneficiaryAr, opt => opt.MapFrom(s => s.TheTypeOfBeneficiaryAr))
     .ForPath(d => d.WhatDoesOneDeviceOfferAr, opt => opt.MapFrom(s => s.WhatDoesOneDeviceOfferAr))
     .ForPath(d => d.WhatDoesOneDeviceOfferEn, opt => opt.MapFrom(s => s.WhatDoesOneDeviceOfferEn))
     .ReverseMap();

        CreateMap<TopGiversAddDto, AddTopGiversDonationCommand>()
       .ForMember(d => d.Name, opt => opt.MapFrom(s => s.TopDonatorName))
       .ForMember(d => d.MobileNumber, opt => opt.MapFrom(s => new PhoneNumber() { CountryCode = "+966", MobileNumber = s.MobileNumber }))
       .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId))
       .ForMember(d => d.MasarId, opt => opt.MapFrom(s => s.MasarId))
       .ForMember(d => d.IsQuickDonation, opt => opt.MapFrom(s => s.IsQuickDonation))
       .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
       .ForMember(d => d.DonationDate, opt => opt.MapFrom(s => s.DonationDate))
       .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.DonationAmount))
       .ReverseMap();


        CreateMap<ComprehensiveReportSearch, ComprehensiveReportQuery>()
       .ForMember(d => d.MasarId, opt => opt.MapFrom(s => s.MasarId))
       .ForMember(d => d.ProductType, opt => opt.MapFrom(s => s.ProductType))
       .ForMember(d => d.UnitType, opt => opt.MapFrom(s => s.UnitType))
       .ForMember(d => d.ProductSize, opt => opt.MapFrom(s => s.ProductSize))
       .ForMember(d => d.ApprovedFrom, opt => opt.MapFrom(s => s.ApprovedFrom))
       .ForMember(d => d.ApprovedTo, opt => opt.MapFrom(s => s.ApprovedTo))
       .ForMember(d => d.ProductPaymentStatus, opt => opt.MapFrom(s => s.ProductPaymentStatus))
       .ForMember(d => d.ProductSize, opt => opt.MapFrom(s => s.ProductSize))
       .ForMember(d => d.Contain, opt => opt.MapFrom(s => s.Contain))
       .ForMember(d => d.SearchType, opt => opt.MapFrom(s => s.SearchType))
       .ForMember(d => d.ProductNumber, opt => opt.MapFrom(s => s.ProductNumber))
       .ReverseMap();


        CreateMap<TopGiversReportFilter, GetTopGiversReportsQuery>()
      .ForMember(d => d.DonatorName, opt => opt.MapFrom(s => s.DonatorName))
      .ForMember(d => d.Provider, opt => opt.MapFrom(s => s.Provider))
      .ForMember(d => d.MobileNumber, opt => opt.MapFrom(s => s.MobileNumber))
      .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
      .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
      .ForMember(d => d.FromDate, opt => opt.MapFrom(s => s.FromDate))
      .ForMember(d => d.ToDate, opt => opt.MapFrom(s => s.ToDate))
      .ReverseMap();



        CreateMap<List<WaqfyContentDetailDTO>, contactusDto>()
       .ForMember(d => d.AddressAr, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == "AddressAr").Select(e => e.ContentValue).FirstOrDefault()))
       .ForMember(d => d.AddressEn, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == "AddressEn").Select(e => e.ContentValue).FirstOrDefault()))
       .ForMember(d => d.phone, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == "phone").Select(e => e.ContentValue).FirstOrDefault()))
       .ForMember(d => d.location, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == "location").Select(e => e.ContentValue).FirstOrDefault()));


        CreateMap<List<WaqfyContentDetailDTO>, SocialMediaModel>()
       .ForMember(d => d.FaceBook, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == "FaceBook").Select(e => e.ContentValue).FirstOrDefault()))
       .ForMember(d => d.Instragram, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == "Twitter").Select(e => e.ContentValue).FirstOrDefault()))
       .ForMember(d => d.Twitter, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == "Instgram").Select(e => e.ContentValue).FirstOrDefault()))
        .ForMember(d => d.SnapChat, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == "SnapChat").Select(e => e.ContentValue).FirstOrDefault()))
          .ReverseMap();


        CreateMap<ApprovedProductModel, GetApprovedProductByIdQueryResult>()
      .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
      .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
      .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
      .ForMember(d => d.ForWhomIsThisProductAr, opt => opt.MapFrom(s => s.ForWhomIsThisProductAr))
      .ForMember(d => d.ForWhomIsThisProductEn, opt => opt.MapFrom(s => s.ForWhomIsThisProductEn))
      .ForMember(d => d.WhyDoISupportThemAr, opt => opt.MapFrom(s => s.WhyDoISupportThemAr))
      .ForMember(d => d.WhyDoISupportThemEn, opt => opt.MapFrom(s => s.WhyDoISupportThemEn))
      .ForMember(d => d.HowDoISupportThemAr, opt => opt.MapFrom(s => s.HowDoISupportThemAr))
      .ForMember(d => d.HowDoISupportThemEn, opt => opt.MapFrom(s => s.HowDoISupportThemEn))
      .ForMember(d => d.RegionId, opt => opt.MapFrom(s => s.CountryId))
      .ForMember(d => d.CityId, opt => opt.MapFrom(s => s.CityId))
      .ForMember(d => d.ImageId, opt => opt.MapFrom(s => s.ImageId))
      .ForMember(d => d.DesktopImageUrl, opt => opt.MapFrom(s => s.DesktopImageUrl))
      .ForMember(d => d.MobileImageUrl, opt => opt.MapFrom(s => s.MobileImageUrl))
      .ReverseMap();


       CreateMap<ApprovedProductModel, EditApprovedProductCommand>()
      .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
      .ForMember(d => d.ForWhomIsThisProductAr, opt => opt.MapFrom(s => s.ForWhomIsThisProductAr))
      .ForMember(d => d.ForWhomIsThisProductEn, opt => opt.MapFrom(s => s.ForWhomIsThisProductEn))
      .ForMember(d => d.WhyDoISupportThemAr, opt => opt.MapFrom(s => s.WhyDoISupportThemAr))
      .ForMember(d => d.WhyDoISupportThemEn, opt => opt.MapFrom(s => s.WhyDoISupportThemEn))
      .ForMember(d => d.HowDoISupportThemAr, opt => opt.MapFrom(s => s.HowDoISupportThemAr))
      .ForMember(d => d.HowDoISupportThemEn, opt => opt.MapFrom(s => s.HowDoISupportThemEn))
      .ForMember(d => d.ProductNameAr, opt => opt.MapFrom(s => s.NameAr))
      .ForMember(d => d.ProductNameEn, opt => opt.MapFrom(s => s.NameEn))
     .ForMember(d => d.RegionId, opt => opt.MapFrom(s => s.CountryId))
     .ForMember(d => d.CityId, opt => opt.MapFrom(s => s.CityId))
    .ForMember(d => d.ImageId, opt => opt.MapFrom(s => s.ImageId))
    .ForMember(d => d.MobileImageIsEdit, opt => opt.MapFrom(s => s.MobileImageIsEdit))
    .ForMember(d => d.DesktopImageIsEdit, opt => opt.MapFrom(s => s.DesktopImageIsEdit))
    .ForMember(dest => dest.MobileImage, opt => opt.Ignore())
    .ForMember(dest => dest.DesktopImage, opt => opt.Ignore())

      .ReverseMap();


        CreateMap<List<WaqfyContentDetailDTO>, AboutusDto>()
          .ForMember(d => d.AboutWagfiAr, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "AboutUs-WagFIAr").Select(e=>e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.AboutWagfiEn, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "AboutUs-WagFIEn").Select(e => e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.WagfiIdeaAr, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "AboutUs-WagfiIdeaAr").Select(e => e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.WagfiIdeaEn, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "AboutUs-WagfiIdeaEn").Select(e => e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.WagfiproductAR, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "WagfiproductAR").Select(e => e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.WagfiproductEN, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "WagfiproductEn").Select(e => e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.WagfiEffectAR, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "WagfiEffectAR").Select(e => e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.WagfiEffectEN, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "WagfiEffectEn").Select(e => e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.WagfitargetAR, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "WagfitargetAR").Select(e => e.ContentValue).FirstOrDefault()))
          .ForMember(d => d.WagfitargetEN, opt => opt.MapFrom(s => s.Where(e=>e.ContentKey== "WagfitargetEn").Select(e => e.ContentValue).FirstOrDefault()))
         .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.Where(e => e.ContentKey == null).Select(e => e.IconDto.IconUrl).FirstOrDefault()))
           .ReverseMap();





        CreateMap<CreateQualitativeClassfication, AddQualitativeClassificationsCommand>()
         .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
         .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
         .ReverseMap();

        CreateMap<EditQualitativeClassfication, EditQualitativeClassificationsCommand>()

        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
        .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
        .ReverseMap();

        CreateMap<GetQualitativeClassficationResult, EditQualitativeClassfication>()

       .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
       .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
       .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
       .ReverseMap();


        CreateMap<ProductCategoryModel, GetProductCategoryByIdQueryResult>()
           .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
           .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
           .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
           .ReverseMap();

        CreateMap<ReportTypeModel, GetReportTypeByIdQueryResult>()
           .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
           .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
           .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
           .ReverseMap();

        CreateMap<BankModel, GetBankByIdQueryResult>()
        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.NameEn))
        .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.NameAr))
        .ReverseMap();

        CreateMap<DedicatedToPaymentLookup, DedicatedToPaymentDto>()
       .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
       .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.Name.DescriptionEn))
       .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.Name.DescriptionAr))
       .ReverseMap();


        CreateMap<SigningTheDonationGift, SigningTheDonationGiftDto>()
       .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
       .ForMember(d => d.NameEn, opt => opt.MapFrom(s => s.Name.DescriptionEn))
       .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.Name.DescriptionAr))
       .ReverseMap();


        CreateMap<QuickPaymentAmount, QuickPaymentAmountDto>()
       .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
       .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
       .ReverseMap();


        CreateMap<WebUI.Client.BasicAssocationDto, WebUI.Models.Provider.BasicAssocationDto>().ReverseMap();
        CreateMap<WebUI.Client.AddressAssocationDto, WebUI.Models.Provider.AddressAssocationDto>().ReverseMap();
        CreateMap<WebUI.Client.ContactAssocationDto, WebUI.Models.Provider.ContactAssocationDto>().ReverseMap();
        CreateMap<WebUI.Client.SocialAssocationDto, WebUI.Models.Provider.SocialAssocationDto>().ReverseMap();
        CreateMap<WebUI.Client.BankAssocationDto, WebUI.Models.Provider.BankAssocationDto>().ReverseMap();
        CreateMap<WebUI.Client.BankAssociationItemDto, WebUI.Models.Provider.BankAssociationItemDto>().ReverseMap();
        CreateMap<WebUI.Client.GetAssociationDetailsForCMSEditionResult, WebUI.Models.Provider.AssociationUpdate>().ReverseMap();


        CreateMap<BasicAssocationDto_C, WebUI.Models.Provider.BasicAssocationDto>().ReverseMap();
        CreateMap<AddressAssocationDto_C, WebUI.Models.Provider.AddressAssocationDto>().ReverseMap();
        CreateMap<ContactAssocationDto_C, WebUI.Models.Provider.ContactAssocationDto>().ReverseMap();
        CreateMap<SocialAssocationDto_C, WebUI.Models.Provider.SocialAssocationDto>().ReverseMap();
        CreateMap<BankAssocationDto_C, WebUI.Models.Provider.BankAssocationDto>().ReverseMap();
        CreateMap<BankAssociationItemDto_C, WebUI.Models.Provider.BankAssociationItemDto>().ReverseMap();
        CreateMap<UpdateAssociationForCMSEditionCommand, WebUI.Models.Provider.AssociationUpdate>().ReverseMap();


        ///-------------------------------------------------------------------------------------------------------
        
        CreateMap<WebUI.Client.BasicSocietyDto, WebUI.Models.Provider.BasicSocietyDto>().ReverseMap();
        CreateMap<WebUI.Client.AddressSocietyDto, WebUI.Models.Provider.AddressSocietyDto>().ReverseMap();
        CreateMap<WebUI.Client.ContactSocietyDto, WebUI.Models.Provider.ContactSocietyDto>().ReverseMap();
        CreateMap<WebUI.Client.SocialSocietyDto, WebUI.Models.Provider.SocialSocietyDto>().ReverseMap();
        CreateMap<WebUI.Client.BankSocietyDto, WebUI.Models.Provider.BankSocietyDto>().ReverseMap();
        CreateMap<WebUI.Client.BankSocietyItemDto, WebUI.Models.Provider.BankSocietyItemDto>().ReverseMap();
        CreateMap<WebUI.Client.GetSocityDetailsForCMSEditionResult, WebUI.Models.Provider.SocietyUpdate>().ReverseMap();

        CreateMap<BasicSocityDto_Q, WebUI.Models.Provider.BasicSocietyDto>().ReverseMap();
        CreateMap<AddressSocityDto_Q, WebUI.Models.Provider.AddressSocietyDto>().ReverseMap();
        CreateMap<ContactSocityDto_Q, WebUI.Models.Provider.ContactSocietyDto>().ReverseMap();
        CreateMap<SocialSocityDto_Q, WebUI.Models.Provider.SocialSocietyDto>().ReverseMap();
        CreateMap<BankSocityDto_Q, WebUI.Models.Provider.BankSocietyDto>().ReverseMap();
        CreateMap<BankAssociationItemDto_C, WebUI.Models.Provider.BankSocietyItemDto>().ReverseMap();
        CreateMap<UpdateSocityForCMSEditionCommand, WebUI.Models.Provider.SocietyUpdate>().ReverseMap();

    }
}
