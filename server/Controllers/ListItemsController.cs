using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListItemsController : ControllerBase
    {
        private readonly IListItemService listItemService;

        public ListItemsController(IListItemService listItemService)
        {
            this.listItemService = listItemService;
        }

        // GET: api/ListItems
        [HttpGet]
        public ActionResult<List<ListItem>> Get()
        {
            return listItemService.Get();
        }

        // GET: api/ListItems/5
        [HttpGet("{id}")]
        public ActionResult<ListItem> Get(string id)
        {
            var listItem = listItemService.Get(id);
            if(listItem == null)
            {
                return NotFound($"List item with Id = {id} was not found");
            }
            return listItem;
        }

        // PUT: api/ListItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] ListItem listItem)
        {
            var existingListItem = listItemService.Get(listItem.Id);
            if(existingListItem == null)
            {
                return NotFound($"List item with name = {listItem.Name} was not found");
            }
            listItemService.Update(listItem.Id, listItem);
            return NoContent();

        }

        // POST: api/ListItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ListItem> Post([FromBody] ListItem listItem)
        {
            listItemService.Create(listItem);
            return CreatedAtAction(nameof(Get), new { id = listItem.Id }, listItem);
        }

        // DELETE: api/ListItems/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            listItemService.Remove(id);
            return Ok($"List item with Id = {id} was deleted");
        }
    }
}
