using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Question;

public class CreateQuestionViewModel
{
    public Guid QuestionId { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(200, ErrorMessage = "اسم السؤال غير صحيح")]
    [RegularExpression(@"^[^<>]+$", ErrorMessage = " برجاء عدم ادخال رموز")]
    public string QuestionAr { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(200, ErrorMessage = "اسم السؤال غير صحيح")]
    [RegularExpression(@"^[^<>]+$", ErrorMessage = "برجاء عدم ادخال رموز")]
    public string QuestionEN { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(1000, ErrorMessage = "The max chars on asnwer field is 1000")]
    [RegularExpression(@"^[^<>]+$", ErrorMessage = "برجاء عدم ادخال رموز")]
    public string AnswerAR { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي", AllowEmptyStrings = false)]
    [MaxLength(1000, ErrorMessage = "The max chars on asnwer field is 1000")]
    [RegularExpression(@"^[^<>]+$", ErrorMessage = "برجاء عدم ادخال رموز")]
    public string AnswerEN { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي")]
    public int? QuestionStatues { get; set; }

    [Required(ErrorMessage = "هذا الحقل إلزامي")]
    public int? QuestionPriority { get; set; }
}
