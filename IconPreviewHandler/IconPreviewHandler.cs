using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpShell.Attributes;
using SharpShell.SharpPreviewHandler;
using System.Runtime.InteropServices;

namespace IconPreviewHandler
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".ico", ".icl")]
    [DisplayName("Ib Icon Preview Handler")]
    [Guid("5FEB09C1-B322-4926-A2FA-614997858578")]
    [PreviewHandler(DisableLowILProcessIsolation = false)]
    public class IconPreviewHandler : SharpPreviewHandler
    {
        protected override PreviewHandlerControl DoPreview()
        {
            var handler = new IconHandlerPreviewControl();

            if (!string.IsNullOrEmpty(SelectedFilePath))
                handler.DoPreview(SelectedFilePath);

            return handler;
        }
    }
}