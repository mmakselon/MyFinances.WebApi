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

        [HttpGet("{id}")]
        public DataResponse<Operations> Get(int id)
        {
            var response = new DataResponse<Operations>();

            try
            {
                response.Data = _unitOfWork.Operation.Get(id);
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpPost]
        public DataResponse<int> Add(Operations operation)
        { 
            var response = new DataResponse<int>();

            try
            {
                _unitOfWork.Operation.Add(operation);
                _unitOfWork.Complete();
                response.Data = operation.Id;
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpPut]
        public Response Update(Operations operation)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Operation.Update(operation);
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {
                //logowanie do pliku...
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        [HttpDelete("{id}")]
        public Response Update(int id)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Operation.Delete(id);
                _unitOfWork.Complete();
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
