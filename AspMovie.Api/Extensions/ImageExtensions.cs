using System.Collections.Generic;

namespace AspMovie.Api.Extensions
{
    public static class ImageExtensions
    {
        public static IEnumerable<string> AllowedExtensions =>
          new List<string> { ".jpg", ".png", ".jpeg" };

    }
}
