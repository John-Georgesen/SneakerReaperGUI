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
    /// Interaction logic for AddTasksWindow.xaml
    /// </summary>
    public partial class AddTasksWindow : Window
    {
        public static string store, size, product, profile, proxy;

        private int productX;

        public AddTasksWindow()
        {
            InitializeComponent();
        }

        private void ProductBox_Click(object sender, EventArgs e)
        {
            if (productX == 0)
                ProductBox.Clear();

            productX++;
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            store = StoreBox.Text;
            size = SizeBox.Text;
            product = ProductBox.Text;
            profile = ProfileBox.Text;
            proxy = ProxyBox.Text;

 
        }
        
        public static String getStore()
        {
            return store;
        }
        public static String getProfile()
        {
            return profile;
        }
        public static String getSize()
        {
            return size;
        }
        public static String getProxy()
        {
            return proxy;
        }
        public static String getProduct()
        {
            return product;
        }
    }
}
