using System.Drawing;
using System.Windows.Forms;

namespace Parser.Models
{
    public class Configuration
    {
        public FormWindowState? WindowState { get; set; }

        public Point? WindowLocation { get; set; }

        public string GameUILanguage { get; set; } = "English";
        public Size? Size { get; set; }

        public bool? UploadToServer { get; set; }
        public string Region { get; set; }
        public string Server { get; set; }

    }
}