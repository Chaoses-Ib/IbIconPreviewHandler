using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpShell.SharpPreviewHandler;
using System.Drawing.IconLib;

namespace IconPreviewHandler
{
    public partial class IconHandlerPreviewControl : PreviewHandlerControl
    {
        public IconHandlerPreviewControl()
        {
            InitializeComponent();
        }

        private void AddIconsToControl()
        {
            BackColor = Color.White;

            DoubleBuffered = true;

            int yPos = 12;
            foreach (var iconImage in iconImages)
            {
                var descriptionLabel = new Label
                {
                    Location = new Point(12, yPos),
                    Text = $"{iconImage.Size.Width}x{iconImage.Size.Height} - {iconImage.PixelFormat}",
                    AutoSize = true,
                    BackColor = Color.White
                };
                yPos += 20;

                var pictureBox = new PictureBox
                {
                    Location = new Point(12, yPos),
                    Image = iconImage.Icon.ToBitmap(),
                    Width = iconImage.Size.Width,
                    Height = iconImage.Size.Height
                };
                yPos += iconImage.Size.Height + 20;
                panelImages.Controls.Add(descriptionLabel);
                panelImages.Controls.Add(pictureBox);

                generatedLabels.Add(descriptionLabel);
            }
        }

        public void DoPreview(string selectedFilePath)
        {
            try
            {
                var multiIcon = new MultiIcon();
                multiIcon.Load(selectedFilePath);

                foreach (var iconImage in multiIcon.SelectMany(singleIcon => singleIcon))
                    iconImages.Add(iconImage);

                AddIconsToControl();
            }
            catch
            {

            }
        }

        private readonly List<Label> generatedLabels = new List<Label>();

        private readonly List<IconImage> iconImages = new List<IconImage>();
    }
}