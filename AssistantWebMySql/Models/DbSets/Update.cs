using System.ComponentModel.DataAnnotations;

namespace AssistantWebMySql.Models.DbSets
{
    public class Update
    {
        [Key]
        [Display(Name = "№, пп")]
        public int Id { get; set; }

        [Display(Name = "Версия")]
        public string Version { get; set; }

        [Display(Name = "Русский")]
        public string RussianDescription { get; set; }

        [Display(Name = "Английский")]
        public string EnglishDescription { get; set; }

        [Display(Name = "Немецкий")]
        public string DeutschDescription { get; set; }

        [Display(Name = "Китайский")]
        public string ChineseDescription { get; set; }

        [Display(Name = "Ссылка на скачивание")]
        public string DownLoadLink { get; set; }
    }

    public class UpdateJson
    {
        public int Language { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string DownLoadLink { get; set; }
    }
}