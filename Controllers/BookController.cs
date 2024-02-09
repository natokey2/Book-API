using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookapi;


[Route("api/[controller]")]
[ApiController]
public class BookController:ControllerBase
{

    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]

    public async Task<IActionResult> GetBooks()
    {
        var books = await _context.Books.ToListAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetBooks(int id)
    {
        var books = await _context.Books.FindAsync(id);

        if (books == null)
        {
            return NotFound();
        }
        return Ok(books);
    }
     [HttpPost]

     public async Task<IActionResult> CreatBooks( Book  book)
     {
         _context.Books.Add(book);
         await _context.SaveChangesAsync();

         return CreatedAtAction("GetBooks" , new {id = book.Id},book);
     }

     [HttpDelete]

     public async Task<IActionResult> DeleteBooks(int id)
      {
        var books = await _context.Books.FindAsync(id);
        if (books == null)
        {
              return NotFound();
        }
          _context.Books.Remove(books);
          await _context.SaveChangesAsync();
          return Ok (books);
      }

}
