using Dapper;
using FinalProject.Models;
using System.Data;

namespace FinalProject
{
    public class SegaSaturnRepository : ISegaSaturnRepository
    {
        private readonly IDbConnection _conn;

        public SegaSaturnRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<SegaSaturn> GetAllGames()
        {
            return _conn.Query<SegaSaturn>("SELECT * FROM segasaturn");
        }

        public SegaSaturn GetSegaSaturn(int id)
        {
            return _conn.QuerySingle<SegaSaturn>("SELECT * FROM segasaturn WHERE ID = @id", 
                new { id = id });
        }

        public void UpdateSegaSaturn(SegaSaturn game)
        {
            _conn.Execute("UPDATE segasaturn SET Name = @name, Developer = @developer, Publisher = @publisher," +
                "Genre = @genre, Raiting = @raiting, NumberOfPlayers = @numberofplayers," +
                "ReleaseDate = @releasedate WHERE ID = @id",
            new { name = game.Name, Developer = game.Developer, Publisher = game.Publisher,
                genre = game.Genre, raiting = game.Raiting, numberofplayers = game.NumberOfPlayers,
                releasedate = game.ReleaseDate, id = game.ID });
        }
        public void InsertSegaSaturn(SegaSaturn productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, developer = productToInsert.Developer, publisher = productToInsert.Publisher, genre = productToInsert.Genre,
                raiting = productToInsert.Raiting, numberofplayer = productToInsert.NumberOfPlayers, 
                    releasedate = productToInsert.ReleaseDate});
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM segasaturn;");
        }

        public SegaSaturn AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new SegaSaturn();
            product.Categories = categoryList;
            return product;
        }

        public void InsertProduct(SegaSaturn productToInsert)
        {
            _conn.Execute("INSERT INTO segasaturn (NAME, DEVELOPER, PUBLISHER, " +
                "GENRE, RAITING, NUMBEROFPLAYERS, RELEASEDATE) " +
                "VALUES (@name, @developer, @publisher, " +
                "@genre, @raiting, @numberofplayers, @releasedate);",
        new { name = productToInsert.Name, developer = productToInsert.Developer, 
            publisher = productToInsert.Publisher, genre = productToInsert.Genre, 
            raiting = productToInsert.Raiting, numberofplayers = productToInsert.NumberOfPlayers,
        releasedate = productToInsert.ReleaseDate});
        }

        public void DeleteProduct(SegaSaturn game)
        {
            _conn.Execute("DELETE FROM segasaturn WHERE ID = @id;", new { id = game.ID });
        }
    }
}
