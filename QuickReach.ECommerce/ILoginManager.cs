namespace QuickReach.ECommerce
{
    public interface ILoginManager
    {
        bool Validate(string username, string password);
    }
}