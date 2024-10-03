namespace WebUI.Models.AwqafProduct;

public class RequestDetaliesDto
{
    public Guid RequestId { get; set; }

    public string DonatorName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public string ProductName { get; set; }
    public string MasarName { get; set; }
    public string Amount { get; set; }
    public string SendRequest { get; set; }

    public int statues { get; set; }
    public string StatusAsString { get; set; }
}
