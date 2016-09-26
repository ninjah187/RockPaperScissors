using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RockPaperScissors.Services;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
    [Route("api/[controller]")]
    public abstract class ApiBaseController<TModel> : Controller
        where TModel : class, IModelEntity
    {
        protected IRepository<TModel> Repository { get; }

        public ApiBaseController(IRepository<TModel> repository)
        {
            Repository = repository;
        }

        public virtual async Task<IActionResult> GetAll()
        {
            var items = await Repository.GetAllAsync();

            return Json(items);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var item = await Repository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Json(item);
        }

        [Route("count")]
        public virtual async Task<IActionResult> Count()
            => Json(await Repository.CountAsync());

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TModel item)
        {
            try
            {
                await Repository.CreateAsync(item);
                await Repository.CommitAsync();
            }
            catch (Exception ex) when (ex is ArgumentException ||
                                       ex is ArgumentNullException)
            {
                return BadRequest();
            }

            return CreatedAtRoute(
                    new { controller = ControllerContext.RouteData.Values["controller"].ToString(), id = item.Id },
                    JsonConvert.SerializeObject(item)
                );
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] TModel item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            try
            {
                await Repository.UpdateAsync(item);
                await Repository.CommitAsync();
            }
            catch (Exception ex) when (ex is InvalidOperationException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await Repository.DeleteAsync(id);
            await Repository.CommitAsync();

            return NoContent();
        }
    }
}
