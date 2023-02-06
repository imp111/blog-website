using Blog_Website.Models;

namespace Blog_Website.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts(int id);
        bool AddPost(Post post);
        bool UpdatePost(Post post);
        bool RemovePost(int id);
    }
}
