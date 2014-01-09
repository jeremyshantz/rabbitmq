
namespace Messages
{    
    using System;
    using System.IO;
    using System.Text;

    public class AttachmentV2
    {
        public string FileName { get; set; }

        public string Base64 { get; set; }

        public void Save(string path)
        {
            var savepath = Path.Combine(path, this.FileName);

            File.WriteAllBytes(savepath, Convert.FromBase64String(this.Base64));
        }

        public static AttachmentV2 FromFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Missing path", "path");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }

            return new AttachmentV2
            {
                FileName = Path.GetFileName(path),
                Base64 = Convert.ToBase64String(File.ReadAllBytes(path))
            };
        }
    }
}
