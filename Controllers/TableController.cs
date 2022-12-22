using Microsoft.AspNetCore.Mvc;
using IT4.Data;
using IT4.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace IT4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : Controller
    {
        private readonly IT4DBContext dbContext;
        public TableController(IT4DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetTable()
        {
            return Ok(dbContext.Table.ToList());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTable([FromRoute] Guid id)
        {
            var table = await dbContext.Table.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

        [HttpPost]
        public async Task<IActionResult> PostTable(AddTableRequest addTableRequest)
        {
            var table = new Table()
            {
                Id = Guid.NewGuid(),
                Name= addTableRequest.Name,
                DbId = addTableRequest.DbId
            };

            await dbContext.Table.AddAsync(table);
            await dbContext.SaveChangesAsync();

            return Ok(table);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTable([FromRoute] Guid id, UpdateTableRequest updateTableRequest)
        {
            var table = await dbContext.Table.FindAsync(id);
            if (table != null)
            {
                table.Name = updateTableRequest.Name;
                table.DbId= updateTableRequest.DbId;
                await dbContext.SaveChangesAsync();

                return Ok(table);
            }

            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTable([FromRoute] Guid id)
        {
            var table = await dbContext.Table.FindAsync(id);

            if (table != null)
            {
                dbContext.Remove(table);
                await dbContext.SaveChangesAsync();
                return Ok(table);
            }
            return NotFound();
        }
    }
}
