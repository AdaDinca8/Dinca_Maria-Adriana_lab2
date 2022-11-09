using Dinca_Maria_Adriana_lab2.Models;

namespace Dinca_Maria_Adriana_lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; }

    }
}
