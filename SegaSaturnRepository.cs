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
            return _conn.QuerySingle<SegaSaturn>("SELECT * FROM segasaturn WHERE ID = @ID", 
                new { id = id });
        }

        public void UpdateSegaSaturn(SegaSaturn game)
        {
            _ = _conn.Execute("UPDATE segasaturn SET name = @Name," +
                " developer = @Developer," +
                " publisher = @Publisher," +
                "genre = @Genre," +
                " rating = @Rating," +
                " numberofplayers = @NumberOfPlayers," +
                "releasedate = @ReleaseDate" +
                " WHERE id = @ID",
            new
            {
                name = game.Name,
                developer = game.Developer,
                publisher = game.Publisher,
                genre = game.Genre,
                rating = game.Rating,
                numberofplayers = game.NumberOfPlayers,
                releasedate = game.ReleaseDate,
                id = game.ID
            });
        }
        public void InsertSegaSaturn(SegaSaturn productToInsert)
        {
            _conn.Execute("INSERT INTO segasaturn (Name, Developer, Publisher, Genre,  Rating, NumberOfPlayers, ReleaseDate)" +
                " VALUES (@Name, @Developer, @Publisher, @Genre, @Rating, @NumberOfPlayers, @ReleaseDate Where ID = @ID);",
                new { name = productToInsert.Name, developer = productToInsert.Developer, publisher = productToInsert.Publisher, genre = productToInsert.Genre,
                rating = productToInsert.Rating, numberofplayer = productToInsert.NumberOfPlayers, 
                    releasedate = productToInsert.ReleaseDate});
        }


        public void InsertProduct(SegaSaturn productToInsert)
        {
            _conn.Execute("INSERT INTO segasaturn (NAME, DEVELOPER, PUBLISHER, " +
                "GENRE, RATING, NUMBEROFPLAYERS, RELEASEDATE) " +
                "VALUES (@Name, @Developer, @Publisher, " +
                "@Genre, @Rating, @NumberOfPlayers, @ReleaseDate);",
        new { name = productToInsert.Name, developer = productToInsert.Developer, 
            publisher = productToInsert.Publisher, genre = productToInsert.Genre, 
            rating = productToInsert.Rating, numberofplayers = productToInsert.NumberOfPlayers,
        releasedate = productToInsert.ReleaseDate});
        }

        public void DeleteProduct(SegaSaturn game)
        {
            _conn.Execute("DELETE FROM segasaturn WHERE ID = @id;", new { id = game.ID });
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
    }
}
