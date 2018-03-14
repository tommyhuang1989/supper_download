using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace super_download.models {
    public abstract class sd_file {
        public string name { get; set; }
        public string url { get; set; }
        public string local_path { get; set; }
        public double download_progress { get; set; }
        public sd_file_type file_type { get; set; }

        public sd_file(string url) {
            this.url = url;
            this.name = url.Split('/').Last();
            this.local_path = System.IO.Path.Combine(Environment.CurrentDirectory, name);
        }

        public abstract void download();
    }
}
