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
            var model = await this.GetFullAndPartialViewModel();
            return this.View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetCategoryProducts(string categoryId)
        {
            var lookupId = int.Parse(categoryId);
            var model = await this.GetFullAndPartialViewModel(lookupId);
            return PartialView("CategoryResults", model);
        }

        private async Task<StoreIndexViewModel> GetFullAndPartialViewModel(int categoryId = 0)
        {
            // populate the viewModel and return it
            var viewModel = new StoreIndexViewModel();
            viewModel.Genres = storeDB.Genres.Include(g => g.Albums).OrderByDescending(g => g.Albums.Count()).ToList();
            //todo create method get default!
            viewModel.SortMethods = new List<SortMethod> { new SortMethod(1, "Name"), new SortMethod(2, "Number of Albums")  };
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