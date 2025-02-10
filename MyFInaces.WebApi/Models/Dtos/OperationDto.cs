using MyFinances.WebApi.Models.Domains;

namespace MyFinances.WebApi.Models.Dtos
{
    public class OperationDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
    }
}
