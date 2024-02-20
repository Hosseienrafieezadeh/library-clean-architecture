namespace Library.Services.Books.Contracts.Dtos
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WriterName { get; set; }
        public string ShelfTitle { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int Inventory { get; set; }
        public int RentInventory { get; set; }
    }
}
