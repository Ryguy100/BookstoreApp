namespace BookstoreApp.Models
{
    public class EFBookRepo : IBookRepo
    {
        private BookstoreContext _context;
        public EFBookRepo(BookstoreContext context) 
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
