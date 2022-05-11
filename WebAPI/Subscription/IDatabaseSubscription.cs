namespace WebAPI.Subscription
{
    public interface IDatabaseSubscription
    {
        void Configure(string tableName);
    }
}
