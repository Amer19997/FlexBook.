namespace WebUI.Models.Banner;

public class FileDto
{
    public string Name { get; set; }
    public double Size { get; set; }
    public string Extension { get; set; }
    public string ContentType { get; set; }
    public byte[] Data { get; set; }
}
