using MvcMusicStore.Models;
using System.Collections.Generic;

namespace MvcMusicStore.ViewModels
{
    public class StoreIndexViewModel
    {
        public List<SortMethod> SortMethods { get; set; }
        public List<Genre> Genres { get; set; }
        public int SelectedItemId { get; set; }
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