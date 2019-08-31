using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreForReqManager.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Display(Name = "标题")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "至少三个字符")]
        [Required(ErrorMessage = "标题不能为空")]
        public string Title { get; set; }
        [Display(Name = "上映时间")]
        //[DataType(DataType.Date,ErrorMessage = "时间格式不正确")]
        
        [Required(ErrorMessage = "上映时间不能为空")]
        [RegularExpression(@"^(?:(?:1[6-9]|[2-9][0-9])[0-9]{2}([-/.]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:(?:1[6-9]|[2-9][0-9])(?:0[48]|[2468][048]|[13579][26])|(?:16|[2468][048]|[3579][26])00)([-/.]?)0?2\2(?:29))$", ErrorMessage = "日期格式不正确")]
    public DateTime ReleaseDate { get; set; }
        [Display(Name = "类型")]
        public string Genre { get; set; }
        [Display(Name = "票价")]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "票价不能为空")]
        public decimal Price { get; set; }
        /// <summary>
        /// 分级
        /// </summary>
        [Display(Name ="分级")]
        [RegularExpression(@"^[A-D]{1}$",ErrorMessage ="分级只能是ABCD中的一个")]
        public string Rating { get; set; }
    }
}
