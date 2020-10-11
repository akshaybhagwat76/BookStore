using System;

namespace CodeForFun.UI.WebMvcCore.Models.ViewModels
{
    public class BooksViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public decimal? Price { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
