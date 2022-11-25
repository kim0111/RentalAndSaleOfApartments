using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalAndSaleOfApartments.Data;
using RentalAndSaleOfApartments.Models;
using System.Diagnostics;
using System.Web;

namespace RentalAndSaleOfApartments.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //////////////////
        [HttpGet]
        public async Task<IActionResult> GetRent()
        {
            var response = await _dbContext.Rents.ToListAsync();

            return View(response);
        }



        //////////////////
        [HttpGet]
        public async Task<IActionResult> GetSale()
        {
            var response = await _dbContext.Sales.ToListAsync();

            return View(response);
        }



        //////////////////
        [HttpPost]
        public async Task<IActionResult> PostRent([Bind("Address,Rooms,SizeInM,Price,RentalPeriodInMounth,OwnersPhone,isRenovation,PostedOnSite")] Rent model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Rents.Add(model);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Get");
                }
            }

            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again or call system admin");
            }

            return View(model);

        }


        public async Task<IActionResult> PostRent()
        {

            return View();
        }


        //////////////////
        [HttpPost]
        public async Task<IActionResult> PostSale([Bind("Address,Rooms,SizeInM,Price,OwnersPhone,isRenovation,PostedOnSite")] Sale model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Sales.Add(model);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Get");
                }
            }

            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again or call system admin");
            }

            return View(model);

        }


        public async Task<IActionResult> PostSale()
        {

            return View();
        }




        //////////////////
        [HttpPost, ActionName("EditR")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPostRent(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var ren = await _dbContext.Rents.FirstOrDefaultAsync(s => s.Id == Id);


            if (await TryUpdateModelAsync<Rent>(
                ren, "", s => s.Address, s => s.Rooms, s => s.SizeInM, s => s.Price, s => s.RentalPeriodInMounth, s => s.OwnersPhone, s => s.isRenovation, s => s.PostedOnSite))
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again or call system admin");
                }
            }

            return View(ren);
        }

        public async Task<IActionResult> EditR(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var rent = await _dbContext.Rents.FirstOrDefaultAsync(m => m.Id == Id);

            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        //////////////////
        [HttpPost, ActionName("EditS")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPostSale(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var sal = await _dbContext.Sales.FirstOrDefaultAsync(s => s.Id == Id);


            if (await TryUpdateModelAsync<Sale>(
                sal, "", s => s.Address, s => s.Rooms, s => s.SizeInM, s => s.Price, s => s.OwnersPhone, s => s.isRenovation, s => s.PostedOnSite))
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again or call system admin");
                }
            }

            return View(sal);
        }

        public async Task<IActionResult> EditS(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var sale = await _dbContext.Sales.FirstOrDefaultAsync(m => m.Id == Id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        //////////////////
        public async Task<IActionResult> DeleteRent(int? id, bool? Savechangeserror = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _dbContext.Rents.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (rent == null)
            {
                return NotFound();
            }

            if (Savechangeserror.GetValueOrDefault())
            {
                ViewData["DeleteError"] = "Delete failed, please try again later ... ";
            }

            return View(rent);
        }


        [HttpPost, ActionName("DeleteRent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteRent(int id)
        {
            var rent = await _dbContext.Rents.FindAsync(id);

            if (rent == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _dbContext.Rents.Remove(rent);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(DeleteRent), new { id = id, Savechangeserror = true });
            }

        }




        //////////////////
        public async Task<IActionResult> DeleteSale(int? id, bool? Savechangeserror = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _dbContext.Sales.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (sale == null)
            {
                return NotFound();
            }

            if (Savechangeserror.GetValueOrDefault())
            {
                ViewData["DeleteError"] = "Delete failed, please try again later ... ";
            }

            return View(sale);
        }


        [HttpPost, ActionName("DeleteSale")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteSale(int id)
        {
            var sale = await _dbContext.Sales.FindAsync(id);

            if (sale == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _dbContext.Sales.Remove(sale);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(DeleteSale), new { id = id, Savechangeserror = true });
            }

        }


/*
        public string Context()
        {
            HttpContext.Response.Write("<h1>HELLO IT STEP</h1>");
            string browser = HttpContext.Request.Browser.Browser;
            string ip = HttpContext.Request.UserHostAddress;

            HttpContext.Request.Cookies["Name"].Value = "Yura";

            string cookies = HttpContext.Request.Cookies["Name"].Value;

            return "<p> Browser: " + browser + "<br> IP:" + ip + "Cookie:" + cookies + "</p>";
        }*/




    }
}