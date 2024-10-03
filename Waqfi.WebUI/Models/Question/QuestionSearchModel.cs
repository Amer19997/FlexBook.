using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Question;

public class QuestionSearchModel
{
    [MaxLength(200, ErrorMessage = "اسم السؤال غير صحيح")]
    public string QuestionSearch { get; set; }
}
