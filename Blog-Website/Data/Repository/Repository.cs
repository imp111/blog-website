using Blog_Website.Controllers;
using Blog_Website.Models;

namespace Blog_Website.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Post> GetAllPosts()
        {
            return _db.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return _db.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _db.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            _db.Posts.Update(post);
        }

        public void AddPost(Post post)
        {
            _db.Posts.Add(post);
        }

        public bool SaveChanges()
        {
            if (_db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
