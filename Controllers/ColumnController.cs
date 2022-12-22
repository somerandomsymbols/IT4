using Microsoft.AspNetCore.Mvc;
using IT4.Data;
using IT4.Models;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace IT4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColumnController : Controller
    {
        private readonly IT4DBContext dbContext;
        public ColumnController(IT4DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetColumn()
        {
            return Ok(dbContext.Column.ToList());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetColumn([FromRoute] Guid id)
        {
            var column = await dbContext.Column.FindAsync(id);

            if(column == null)
            {
                return NotFound();
            }
            return Ok(column);
        }

        [HttpPost]
        public async Task<IActionResult> PostColumn(AddColumnRequest addColumnRequest)
        {
            var column = new Column()
            {
                Id = Guid.NewGuid(),
                Name = addColumnRequest.Name,
                Type= addColumnRequest.Type,
                TableId = addColumnRequest.TableId
            };

            await dbContext.Column.AddAsync(column);
            await dbContext.SaveChangesAsync();

            return Ok(column);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateColumn([FromRoute] Guid id, UpdateColumnRequest updateColumnRequest)
        {
            var column = await dbContext.Column.FindAsync(id);
            if (column != null)
            {
                column.Name = updateColumnRequest.Name;
                column.Type = updateColumnRequest.Type;
                column.TableId = updateColumnRequest.TableId;
                await dbContext.SaveChangesAsync();

                return Ok(column);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteColumn([FromRoute] Guid id)
        {
            var column = await dbContext.Column.FindAsync(id);

            if(column != null)
            {
                dbContext.Remove(column);
                await dbContext.SaveChangesAsync();
                return Ok(column);
            }
            return NotFound();
        }
    }
}
