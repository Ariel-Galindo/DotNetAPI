using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext context)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            Context = context;
        }

        public NZWalksDbContext Context { get; }

        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.Filename}");

            // Upload Image to Local Path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // https://localhost:1234/images/image.jpg
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.Filename}";
            image.FilePath = urlFilePath;

            // Add Image to the Images table
            await Context.Images.AddAsync(image);
            await Context.SaveChangesAsync();

            return image;
        }
    }
}
