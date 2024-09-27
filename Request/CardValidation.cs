namespace FidelityGhanaApi.Request
{
    public class CardValidation
    {
        public string user_id { get; set; }
        //public string custum_1 { get; set; }
        //public string custum_2 { get; set; }
        //public string custum_3 { get; set; }

        public string first6digits { get; set; }
        public string last4digits { get; set; }
        public string CardPin { get; set; }
        public string OTP { get; set; }
    }
}
