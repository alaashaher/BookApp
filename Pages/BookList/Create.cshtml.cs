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
    public class CreateModel : PageModel
    {
        private readonly ApplictionDbContext _db;
        public CreateModel(ApplictionDbContext db)
        {
            _db = db;
        }
        public Book Book { get; set; }
        public void OnGet()
        {

        }
    }
}