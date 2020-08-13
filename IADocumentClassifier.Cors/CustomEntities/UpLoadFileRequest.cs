
namespace IADocumentClassifier.Cors.CustomEntities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UpLoadFileRequest
    {
        public int parametroSetup { get; set; }
        public string containerName { get; set; }
        public string filePath { get; set; }
        public string fileName { get; set; }
    }
}
