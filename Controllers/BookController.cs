using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Model;
using BookApp.wwwroot.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplictionDbContext _db;
        public BookController(ApplictionDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var BookObj = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if(BookObj == null)
            {
                return Json(new { success = false, massage = "Error While Deleteing" });
            }
            _db.Book.Remove(BookObj);
            await _db.SaveChangesAsync();
            return Json(new { success = false, massage = "Error While Deleteing" });
        }
    }
}