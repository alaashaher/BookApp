using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Model;
using BookApp.wwwroot.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookApp.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplictionDbContext _db;
        public EditModel(ApplictionDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFormDb = await _db.Book.FindAsync(Book.Id);
                BookFormDb.Name = Book.Name;
                BookFormDb.Author = Book.Author;
                BookFormDb.ISBN = Book.ISBN;
                //await _db.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}