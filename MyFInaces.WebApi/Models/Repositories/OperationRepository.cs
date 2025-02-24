using Azure;
using MyFinances.WebApi.Models.Domains;
using Operations = MyFinances.WebApi.Models.Domains.Operations;

namespace MyFinances.WebApi.Models.Repositories
{
    public class OperationRepository
    {
        private readonly MyFinancesContext _context;

        public OperationRepository(MyFinancesContext context)
        {
                _context = context;
        }
        public IEnumerable<Operations> Get()
        {
            return _context.Operations;
        }

        public Operations Get(int id)
        {
            return _context.Operations.FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<Operations> GetPaged(int recordsPerPage, int pageNumber)
        {
            // Obliczamy liczbę rekordów do pominięcia (Skip)
            var skipCount = (pageNumber - 1) * recordsPerPage;

            // Pobieramy odpowiednią stronę danych
            //return _context.Operations.Skip(skipCount).Take(recordsPerPage);
            return _context.Operations
               .AsQueryable()     // Upewniamy się, że jest to IQueryable
               .Skip(skipCount)
               .Take(recordsPerPage)
               .ToList();
        }

        public void Add(Operations operation)
        {
            operation.Date = DateTime.Now;
            _context.Operations.Add(operation);
        }

        public void Update(Operations operation)
        {
            var operationToUpdate = _context.Operations
                .First(x=>x.Id== operation.Id);

            operationToUpdate.CategoryId = operation.CategoryId;
            operationToUpdate.Description = operation.Description; 
            operationToUpdate.Name = operation.Name;
            operationToUpdate.Value = operation.Value;
        }

        public void Delete(int id)
        {
            var operationToDelete = _context.Operations
                .First(x => x.Id == id);

            _context.Operations.Remove(operationToDelete);
        }
    }
}
