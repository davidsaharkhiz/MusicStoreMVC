using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /Store/

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await this.GetViewModel();
            return this.View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetCategoryProducts(string categoryId)
        {
            var lookupId = int.Parse(categoryId);
            var model = await this.GetViewModel(lookupId);
            return PartialView("CategoryResults", model);
        }

        private async Task<StoreIndexViewModel> GetViewModel(int categoryId = 0)
        {
            // populate the viewModel and return it
            var viewModel = new StoreIndexViewModel();
            switch (viewModel.SelectedSortMethod)
            {
                case StoreIndexViewModel.sortByNumberOfAlbums:
                    viewModel.Genres = storeDB.Genres.Include(g => g.Albums).OrderByDescending(g => g.Albums.Count()).ToList();
                    break;
                case StoreIndexViewModel.sortByName:
                    viewModel.Genres = storeDB.Genres.Include(g => g.Albums).OrderBy(g => g.Name).ToList();
                    break;
                default:
                    viewModel.Genres = storeDB.Genres.Include(g => g.Albums).OrderBy(g => g.Name).ToList();
                    break;
            }
            
            return viewModel;
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);

            return View(album);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            List<Genre> genres = storeDB.Genres.ToList<Genre>();
            return PartialView(genres);
        }

    }
}