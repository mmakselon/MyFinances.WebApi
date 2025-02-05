using System.ComponentModel;

namespace MyFinances.WebApi.Models.Response
{
    public class Response
    {
        public Response()
        {
            Errors = new List<Error>();
        }
        public List<Error> Errors { get; set; }

        public bool IsSuccess
        {
            get
            {
                return Errors == null || !Errors.Any();
            }
        }

        //public bool IsSuccess => Errors == null || !Errors.Any(); //to samo co wyżej tylko zwięźlej


    }
}
