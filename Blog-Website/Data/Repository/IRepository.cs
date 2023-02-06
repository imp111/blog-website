using Blog_Website.Models;

namespace Blog_Website.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        bool SaveChanges();
    }
}
