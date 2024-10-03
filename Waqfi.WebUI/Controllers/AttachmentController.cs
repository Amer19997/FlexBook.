using Microsoft.AspNetCore.Mvc;
using WebUI.Client;

namespace WebUI.Controllers;

public class AttachmentController: Controller
{
    public IAssociationsClient _associationsClient { get; set; }
    public AttachmentController(IAssociationsClient associationsClient)
    {
        _associationsClient= associationsClient;
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAttachment(string id)
    //{
    //  var result = await _associationsClient.FilesAsync(Guid.Parse(id));
      
    //    return Ok();

    //}
}
