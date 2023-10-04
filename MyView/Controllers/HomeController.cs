using Microsoft.AspNetCore.Mvc;
using MyView.Models;
using MyView.MyViewData;

namespace MyView.Controllers
{
    public class HomeController : Controller
    {
      private readonly DatabaseContext _databaseContext;

        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index(UrunViewModel urunViewModel)
        {
       var urunler= _databaseContext.Urunler.ToList();
        var satislar=_databaseContext.Satislar.ToList();
         var satisdetaylar= _databaseContext.SatisDetaylari.ToList();

            urunViewModel.satislar = satislar;
            urunViewModel.urunler= urunler;
            urunViewModel.satisDetaylari= satisdetaylar;    
           
            return View(urunViewModel);
        }
    }
}
