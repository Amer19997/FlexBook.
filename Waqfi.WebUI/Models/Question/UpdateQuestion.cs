using System.ComponentModel.DataAnnotations;
using WebUI.Client;

namespace WebUI.Models.Question;

public class UpdateQuestion
{
    public Guid QuestionId { get; set;}

    [Required(ErrorMessage = "هذا الحقل إلزامي",AllowEmptyStrings =false)]
    [MaxLength(200,ErrorMessage = "اسم السؤال غير صحيح")]
    public string QuestionAr { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(200, ErrorMessage = "اسم السؤال غير صحيح")]
    public string QuestionEn { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(1000, ErrorMessage = "max length for Answer is 1000 chars")]
    public string AnswerAr { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(1000, ErrorMessage = "max length for Answer is 1000 chars")]
    public string AnswerEn { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي")]
    public int? QuestionStatues { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي")]
    public int? QuestionPriority { get; set; }
}
