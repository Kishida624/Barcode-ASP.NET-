using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemberLog.Models
{
    [Table("member")]
    public class Member
    {
        [Key]
        public int member_id { get; set; }
        public string member_pos_id { get; set; }
        public string member_code { get; set; }

        public string member_shop_id { get; set;}
        public string member_firstname { get; set; }
        public string member_lastname { get;set; }
        public string member_firstname_kana { get; set;}
        public string member_lastname_kana { get;set; }
    }
}
