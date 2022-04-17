using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre

{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Book genre is not found");
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower()))
                throw new InvalidOperationException("a genre with this name already exist");

            genre.Name = String.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name: Model.Name ;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        
    }
}

