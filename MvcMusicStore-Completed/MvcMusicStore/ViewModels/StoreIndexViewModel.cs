using MvcMusicStore.Models;
using System.Collections.Generic;

namespace MvcMusicStore.ViewModels
{
    public class StoreIndexViewModel
    {
        public List<SortMethod> SortMethods { get; set; }
        public List<Genre> Genres { get; set; }
        public int SelectedSortMethod { get; set; }

        public const int sortByName = 1;
        public const int sortByNumberOfAlbums = 2;

        public StoreIndexViewModel()
        {
            this.SortMethods = new List<SortMethod> { new SortMethod(sortByName, "Name"), new SortMethod(sortByNumberOfAlbums, "Number of Albums ") };
            SelectedSortMethod = sortByName;
        }

    }


    public class SortMethod
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public SortMethod(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

    }
}