using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FidelityGhanaApi.Models
{
    public class credentials
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string user_id { get; set; }
        public string custum_1 { get; set; }
        public string custum_2 { get; set; }
        public string custum_3 { get; set; }
        public string custum_4 { get; set; }
        public string auth_code { get; set; }

        //public string first6digits { get; set; }
        //public string last4digits { get; set; }
        //public string CardPin { get; set; }
        //public string OTP { get; set; }
        //public string auth_code { get; set; }
    }
}
