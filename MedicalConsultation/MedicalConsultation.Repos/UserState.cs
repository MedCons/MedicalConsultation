namespace MedicalConsultation.Repos
{
    public static class UserState
    {
        public static bool IsLoggedIn { get; set; }
        public static byte Role { get; set; }
    }
}
