using System.ComponentModel.DataAnnotations;
using WebUI.Client;

namespace WebUI.Models.Provider;

public class RequestReturnModel
{
    [Required]
    public Guid RequestId { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(2500, ErrorMessage = "يجب ادخال سبب الأعادة بشكل صحيح")]
    public string Notes { get; set; }

    public List<StepDto> Steps { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    public string ListReturnItem { get; set; }
}
