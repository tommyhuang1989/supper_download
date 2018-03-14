using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace super_download.models {
    public class sd_ftp_file : sd_file{
        public sd_ftp_file(string url) : base(url){

        }

        public override void download() {
            System.Windows.MessageBox.Show("ftp file downloading...");
        }
    }
}
