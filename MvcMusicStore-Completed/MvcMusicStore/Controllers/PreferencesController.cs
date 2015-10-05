using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class PreferencesController : Controller
    {
        // GET: Preferences
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Preferences/SetPreferencesAjax

        [HttpPost]
        [ActionName("SetPreferencesAjax")]
        public ActionResult SetPreferencesAjax()
        {
            //Some Code--Some Code-- - Some Code
            return View();
        }
    }
}

/*


    todo

    using System.Web

public class Controller

{

public static Person person

{

 
get
{
    if(HttpContext.session["xyzperson"]==null)
    {
        Person p = new Person()
        HttpContext.session["xyzperson"] = p;
        return p;   
    }
    else
    {
        return (Person)HttpContext.session["xyzperson"];
    }
}

} 

} 


    */
