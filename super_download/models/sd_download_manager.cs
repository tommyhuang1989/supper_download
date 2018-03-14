using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace super_download.models
{
    public class sd_download_manager
    {
        public string[] path_array { get; set; }
        public List<sd_file> file_list = new List<sd_file>();
        public sd_download_manager(string[] download_path_array)
        {
            path_array = download_path_array;
        }

        public void init_download_files() {
            foreach (string path in path_array) {
                if (!is_valid_file(path))
                    continue;

                string type = get_file_type(path);
                if (type.Equals(sd_file_type.http.ToString(), StringComparison.OrdinalIgnoreCase)) {
                    file_list.Add(new sd_http_file(path));
                }
                else if (type.Equals(sd_file_type.https.ToString(), StringComparison.OrdinalIgnoreCase)) {
                    file_list.Add(new sd_http_file(path));
                }
                else if (type.Equals(sd_file_type.ftp.ToString(), StringComparison.OrdinalIgnoreCase)) {
                    file_list.Add(new sd_ftp_file(path));
                }
            }
        }

        private bool is_valid_file(string path) {
            if (String.IsNullOrEmpty(path) || path.IndexOf(':') < 0) {
                return false;
            }

            string type = get_file_type(path);
            if (Enum.IsDefined(typeof(sd_file_type), type)) {
                return true;
            }

            return false;
        }

        public string get_file_type(string path) {
            if (String.IsNullOrEmpty(path) || path.IndexOf(':') < 0) {
                return null;
            }

            return path.Split(':')[0];
        }

        public void download() {
            foreach (sd_file file in file_list) {
                file.download();
            }
        }
    }
}
