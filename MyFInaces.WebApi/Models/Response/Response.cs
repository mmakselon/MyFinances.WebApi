using System.ComponentModel;

namespace MyFinances.WebApi.Models.Response
{
    public class Response
    {
        public List<Error> Errors { get; set; }

        public bool IsSuccess {  get; set; }

    }
}
