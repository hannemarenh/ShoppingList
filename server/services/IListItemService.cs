using server.Models;

namespace server.services
{
    public interface IListItemService
    {
        List<ListItem> Get();
        ListItem Get(string id);
        ListItem Create(ListItem item);
        void Update(string id, ListItem item);
        void Remove(string id);

    }
}
