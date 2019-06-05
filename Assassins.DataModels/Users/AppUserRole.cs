namespace Assassins.DataModels.Users
{
    public class AppUserRole
    {
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int RoleId { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
