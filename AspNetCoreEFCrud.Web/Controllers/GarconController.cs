using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreEFCrud.Web.ViewModel;
using Cafe.Query.Handler;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEFCrud.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Garcon")]
    public class GarconController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<GarcomViewModel> Listar()
        {
            try
            {
                using (var garcons = new GarcomListQueryHandler())
                {
                    var result = new List<int>();

                    return garcons.Handle().Select(i => new GarcomViewModel
                    {
                        Id = i.Id,
                        Nome = i.Nome,
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}