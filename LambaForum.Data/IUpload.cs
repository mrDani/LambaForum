using System;
using System.Collections.Generic;
using System.Text;

namespace LambaForum.Data
{
    public interface IUpload
    {
        object GetBlobContainer(string connectionString);
    }
}
