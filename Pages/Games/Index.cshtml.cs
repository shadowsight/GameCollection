using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameCollection.Model;
using GameCollection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameCollection.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly GameCollection.Models.GameCollectionContext _context;

        public IndexModel(GameCollection.Models.GameCollectionContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameGenre { get; set; }

        public SelectList Systems { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameSystem { get; set; }


        public async Task OnGetAsync()
        {

            IQueryable<string> genreQuery = from m in _context.Game
                                            orderby m.Genre
                                            select m.Genre;

            IQueryable<string> systemQuery = from m in _context.Game
                                            orderby m.System
                                            select m.System;

            var games = from g in _context.Game
                        select g;
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                games = games.Where(g => g.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(GameGenre))
            {
                games = games.Where(x => x.Genre == GameGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            if (!string.IsNullOrEmpty(GameSystem))
            {
                games = games.Where(x => x.System == GameSystem);
            }
            Systems = new SelectList(await systemQuery.Distinct().ToListAsync());

            Game = await games.OrderBy(g => g.Title).ToListAsync();
        }
    }
}
