using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Net48MvcRenshu.Models
{
    public class UploadFilesModel
    {
        public HttpPostedFileWrapper[] File { get; set; }

        public string StoredFileJson { get; set; }

        public string FileIdToRemove { get; set; }
    }
}