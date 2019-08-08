using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProfileWindowNew
{
    public partial class CustomShopifyWindow : Window
    {
        private int nameX = 0, linkX = 0;
        private String name = null, link = null;

        public CustomShopifyWindow()
        {
            InitializeComponent();
        }

        private void NameBox_Click(object sender, EventArgs e)
        {
            if (nameX == 0)
                NameBox.Clear();

            nameX++;
        }
        private void LinkBox_Click(object sender, EventArgs e)
        {
            if (linkX == 0)
                LinkBox.Clear();

            linkX++;
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            name = NameBox.Text;
            link = LinkBox.Text;
            
        }
        public String getName()
        {
            return name;
        }
        public String getLink()
        {
            return link;
        }
    }
}
