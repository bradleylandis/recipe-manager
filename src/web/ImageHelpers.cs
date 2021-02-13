using System;

namespace recipemanager.web
{
    public static class ImageHelpers
    {
        public static string GetImageSource(byte[] modelImage)
        {
            return modelImage?.Length > 0 ? $"data:image/png;base64,{Convert.ToBase64String(modelImage)}" : null;
        }
    }
}