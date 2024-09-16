using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ActionResult> CreatePageResult<T>(IGenericRepository<T> repo, ISpecification<T> spec, int pageindex, int pageSize) where T : BaseEntitiy
        {
            var item = await repo.ListAsync(spec);
            var count = await repo.CountAsync(spec);

            var pagination = new Pagination<T>(pageindex, pageSize, count, item);

            return Ok(pagination);
        }
    }
}
