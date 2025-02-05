using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinances.WebApi.Models;

namespace MyFinances.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public OperationController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
