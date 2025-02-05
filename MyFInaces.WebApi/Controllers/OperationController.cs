using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using MyFinances.WebApi.Models;
using MyFinances.WebApi.Models.Domains;
using MyFinances.WebApi.Models.Response;

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

        /*[HttpGet]
        public IEnumerable<Operations> Get()
        {
            return _unitOfWork.Operation.Get();
        }*/

        [HttpGet]
        public DataResponse<IEnumerable<Operations>> Get()
        {
            var response = new DataResponse<IEnumerable<Operations>>();
            try
            {
                response.Data = _unitOfWork.Operation.Get();
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));    
            }

            return response;
        }
    }
}
