namespace GameBlog.Models.Users
{
    public enum Moderation
    {
        Wait = 0,
        New = 1,
        Blocked = 2,
        Removed = 3,
        Archive = 4,
        Active = 5,
        BlockedByUser = 6
    }
}