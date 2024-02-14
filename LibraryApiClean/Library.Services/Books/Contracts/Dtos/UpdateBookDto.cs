namespace Library.Services.Books.Contracts.Dtos
{
    public class UpdateBookDto
    {
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int Inventory { get; set; }
        public int WriterId { get; set; }
        public int ShelfId { get; set; }
    }
}
