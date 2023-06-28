namespace server.Models
{
    public interface IListItemStoreDatabaseSettings
    {
        string CollectionName {get; set; }
        string ConnectionString {get; set; }
        string DatabaseName { get; set; }
    }
}
