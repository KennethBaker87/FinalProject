using FinalProject.Models;

namespace FinalProject
{
    public interface ISegaSaturnRepository
    {
        public IEnumerable<SegaSaturn> GetAllGames();
        public SegaSaturn GetSegaSaturn(int id);
        public void UpdateSegaSaturn(SegaSaturn game);
        public void InsertProduct(SegaSaturn productToInsert);
        public IEnumerable<Category> GetCategories();
        public SegaSaturn AssignCategory();
        public void DeleteProduct(SegaSaturn game);
    }
}
