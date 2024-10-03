namespace Waqfi.LocalNIC.Entities;

public class ProviderFile
{ 
    private ProviderFile()
    {
        IsDeleted = false;
        Id = Guid.NewGuid();
    }
    private ProviderFile(Guid id)
    {
        IsDeleted = false;
        Id = id;
    }
    internal ProviderFile(Guid providerId, Guid fileId, string fileName, string displayName, string extension, decimal size, DateTime uploadDate) : this(fileId)
    {
        SocietyId = providerId;
        FileId = fileId;
        FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
        Extension = extension;
        Size = size;
        UploadDate = uploadDate;
    }

    public ProviderFile(Guid fileId, decimal size, string fileName, string extension, string displayName, DateTime uploadDate) : this(fileId)
    {
        FileId= fileId;
        Size = size;
        FileName = fileName;
        Extension = extension;
        DisplayName = displayName;
        UploadDate = uploadDate;
    }
    public Guid? SocietyId { get; set; }
    public Society? Society { get; set; }

    public Guid Id { get; set; }
    public Guid FileId { get; private set; }
    public string? DisplayName { get; private set; }
    public string? FileName { get; private set; }
    public string? Extension { get; private set; }
    public decimal? Size { get; private set; }
    public DateTime? UploadDate { get; private set; }
    public bool? IsDeleted { get; private set; }

    internal void Delete() => IsDeleted = true;

    public static List<ProviderFile> CreateList()
    {
        return new List<ProviderFile>();
    }

    public static List<ProviderFile> CreateList(IReadOnlyCollection<ProviderFile> files)
    {
        return files.ToList();
    }
    public static ProviderFile Init(Guid fileId, decimal size, string fileName, string extension, string displayName, DateTime uploadDate)
    {
        return new ProviderFile(fileId, size, fileName, extension, displayName, uploadDate);
    }
    
}
