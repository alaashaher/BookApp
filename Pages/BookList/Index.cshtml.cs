using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Model;
using BookApp.wwwroot.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplictionDbContext _db;
        public IndexModel(ApplictionDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var BookFormDb = await _db.Book.FindAsync(id);
            if (BookFormDb == null)
            {
                return NotFound();
            }
            _db.Book.Remove(BookFormDb);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}