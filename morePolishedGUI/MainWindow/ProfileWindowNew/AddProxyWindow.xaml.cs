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
    /// <summary>
    /// Interaction logic for AddProxyWindow.xaml
    /// </summary>
    public partial class AddProxyWindow : Window
    {
        private int nameX = 0;
        private String name = null;

        public AddProxyWindow()
        {
            InitializeComponent();
        }
        private void NameBox_Click(object sender, EventArgs e)
        {
            if (nameX == 0)
                NameBox.Clear();

            nameX++;
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            name = NameBox.Text;

        }
        public String getName()
        {
            return name;
        }
    }
}

