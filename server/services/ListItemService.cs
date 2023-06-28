using server.Models;
using MongoDB.Driver;
namespace server.services
{
    public class ListItemService : IListItemService
    {
        private readonly IMongoCollection<ListItem> _listItems;

        public ListItemService(IListItemStoreDatabaseSettings setting, IMongoClient mongoclient)
        {
            var database = mongoclient.GetDatabase(setting.DatabaseName);
            _listItems = database.GetCollection<ListItem>(setting.CollectionName);

        }
        public List<ListItem> Get()
        {
            return  _listItems.Find(listItem => true).ToList();
        }
        public ListItem Get(string id)
        {
            return _listItems.Find(listItem => listItem.Id == id).FirstOrDefault();
        }
        public ListItem Create(ListItem listItem)
        {
            _listItems.InsertOne(listItem);
            return listItem;
        }
        public void Update(string id, ListItem listItem)
        {
            _listItems.ReplaceOne(listItem => listItem.Id == id, listItem);
        }
        public void Remove(string id)
        {
            _listItems.DeleteOne(listItem => listItem.Id == id);
        }

    }
}
