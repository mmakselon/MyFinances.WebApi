using Azure;
using MyFinances.WebApi.Models.Domains;
using Operation = MyFinances.WebApi.Models.Domains.Operation;

namespace MyFinances.WebApi.Models.Repositories
{
    public class OperationRepository
    {
        private readonly MyFinancesContext _context;

        public OperationRepository(MyFinancesContext context)
        {
                _context = context;
        }
        public IEnumerable<Operation> Get()
        {
            return _context.Operations;
        }

        public Operation Get(int id)
        {
            return _context.Operations.FirstOrDefault(x=>x.Id==id);
        }

        public void Add(Operation operation)
        {
            operation.Date = DateTime.Now;
            _context.Operations.Add(operation);
        }

        public void Update(Operation operation)
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
