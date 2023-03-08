namespace ReactAndAspNetTutorial.Auth
{
    public class Allow : Permissions
    {
        //***************ADMIN PERMISSIONS*********************//
        //LEAD PERMISSIONS//
        public const string Lead_Create = "100";
        public const string Lead_Delete = "101";
        public const string Lead_Update = "102";
        
        //CONTACT PERMISSIONS//
        public const string Contact_Create = "110";
        public const string Contact_Delete = "111";
        public const string Contact_Update = "112";
    }
}
