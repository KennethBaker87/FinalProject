using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FinalProject.Controllers
{
    public class SegaSaturnController : Controller
    {
        private readonly ISegaSaturnRepository repo;

        public SegaSaturnController(ISegaSaturnRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var games = repo.GetAllGames();
            return View(games);
        }

        public IActionResult ViewSegaSaturn(int id)
        {
            var product = repo.GetSegaSaturn(id);
            return View(product);
        }

        public IActionResult UpdateSegaSaturn(int id)
        {
             SegaSaturn game = repo.GetSegaSaturn(id);
            if (game == null)
            {
                return View("Game Not Found");
            }
            return View(game);

           
        }
        public IActionResult UpdateSegaSaturnToDatabase(SegaSaturn game, IFormFile picture)
        {
            if (picture != null && picture.Length > 0)
            {
                game.BoxArt = new byte[picture.Length];
                picture.OpenReadStream().Read(game.BoxArt, 0, (int)picture.Length);
                //--OR--
                //using (var memoryStream = new MemoryStream())
                //{
                //    picture.CopyTo(memoryStream);
                //    dogToUpdate.Picture = memoryStream.ToArray();
                //}
            }
            else
            {
                var currentGame = repo.GetSegaSaturn(game.ID);
                game.BoxArt = currentGame.BoxArt;
            }

            repo.UpdateSegaSaturn(game);

            return RedirectToAction("ViewSegaSaturn", new { id = game.ID });
        }
        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }
        public IActionResult InsertProductToDatabase(SegaSaturn productToInsert, IFormFile picture)

        {
            if (picture != null && picture.Length > 0)
            {
                productToInsert.BoxArt = new byte[picture.Length];
                picture.OpenReadStream().Read(productToInsert.BoxArt, 0, (int)picture.Length);
            }
            
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(SegaSaturn game)
        {
            repo.DeleteProduct(game);
            return RedirectToAction("Index");
        }
        

    }
}
