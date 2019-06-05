﻿using Microsoft.AspNetCore.Http;

namespace Assassins.DataModels.Misc
{
    public class FileUploadViewModel
    {
        public IFormFile File { get; set; }
        public string Source { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Extension { get; set; }
    }
}
