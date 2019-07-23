using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileWindowNew
{ 
    public class Tasks
    {
        public static List<User> items = new List<User>();

        public static void ChangeTexts(WpfApp1.MainWindow window)
        {
            window.tasksListView.ItemsSource = items;
        }

        //Add tasks to listview
        public void addTask(String store, String product, String size, String profile, String proxy)
        {
            int idNum = 0;

            items.Add(new User() { ID = idNum, Store = store, Product = product, Size = size, Profile = profile, Proxy = proxy, Status = "Success" });
        }
    }
    public class User
    {
        public int ID { get; set; }

        public string Store { get; set; }

        public string Product { get; set; }

        public String Size { get; set; }

        public string Profile { get; set; }

        public string Proxy { get; set; }

        public string Status { get; set; }
    }
}
