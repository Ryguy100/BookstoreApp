namespace BookstoreApp.Models
{
    public interface IBookRepo
    {
        public IQueryable<Book> Books { get; }
    }
}
