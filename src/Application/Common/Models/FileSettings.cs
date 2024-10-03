namespace FlexBook.Application.Common.Models;
public class FileSettings
{
    public int MaxAllowedFileSizeInBytes { set; get; }
    public string AllowedExtensions { set; get; }
    public string FolderAssociationName { set; get; }
    public string FolderSocietyName { get; set; }
    public string BaseApiUrl { get; set; }
    public string CMSCPUrl { get;  set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string BaseFileURl { get; set; }
    public string PortalURL { get; set; }
    public string TemplateDelegationLetterFloder { get; set; }
    public string TemplateDelegationLetterName { get; set; }
    public string SocietyFileApiUrl { get;  set; }
    public string FolderMasaratName { get; set; }
    public string FolderProdcutName { get; set; }
    public string TemplateDelegationLetterApi { get; set; }
    public string AssociationFileApiUrl { get;  set; }

    public string MasaratFileApiUrl { get; set; }
    public string ProductFileApiUrl { get; set; }
    public string FileBaseURLLates { get; set; }
    public string FilePublicURLLates { set; get; }
    public string NewsFileApiUrl { get; set; }
    public string FolderBannerName { get; set; }

    public string Templatecombinedamount { get; set; }
    public string BaseFileUrlPublic { get; set; }
}
