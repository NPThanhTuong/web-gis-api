namespace WebApiGIS.Utils
{
    public static class ConstConfig
    {
        // Default code
        public const int NoRoomCode = 1;
        public const int NoUserCode = 1;

        // Field's Length
        public const int DisplayNameLength = 32;
        public const int ShortNameLength = 32;
        public const int MediumNameLength = 64;
        public const int LongNameLength = 128;
        public const int ImagePathLength = 256;
        public const int MinPasswordLength = 8;
        public const int MaxPasswordLength = 20;
        public const int DescriptionLength = 4096;
        public const int LongDescriptionLength = 8000;

        // CORS
        public const string AllowAllOrigins = "AllowAll";

        // Claim type
        public const string UserIdClaimType = "userId";
        public const string AvatarClaimType = "avatar";

        // JWT
        public const int ExperyTimeJwtToken = 60 * 24 * 15;

        // Role
        public const string AdminRoleName = "ADMIN";
        public const string UserRoleName = "USER";
        public const string OwnerRoleName = "OWNER";


    }
}
