using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TestSample
{
    public partial class PictureControl : UserControl
    {
        public PictureControl()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get { return ctrlPicture.Image; }
            set { ctrlPicture.Image = value; }
        }
    }
}
