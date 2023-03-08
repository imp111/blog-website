namespace Blog_Website.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        string SaveImage(IFormFile image);
    }
}
