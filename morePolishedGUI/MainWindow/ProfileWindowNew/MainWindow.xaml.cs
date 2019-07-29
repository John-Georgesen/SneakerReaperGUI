using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //shipping fields for user click
        private int profileXS = 0, firstXS = 0, lastXS = 0, emailXS = 0, phoneXS = 0, a1XS = 0, a2XS = 0, stateXS = 0, cityXS = 0, zipXS = 0, countryXS = 0, cNumberX = 0, cNameX = 0, cDateX = 0, cvvX = 0;

        //billing for the same thing
        private int profileXB = 0, firstXB = 0, lastXB = 0, emailXB = 0, phoneXB = 0, a1XB = 0, a2XB = 0, stateXB = 0, cityXB = 0, zipXB = 0, countryXB = 0;

        //addTasks for the same thing
        private int IDBoxX = 0, ProductX = 0, TaskNumberX = 0, MonitorDelayX = 0, RetryDelayX = 0, PasswordX = 0, UsernameX = 0;

        //stores profile info
        String profileNameS, firstNameS, lastNameS, emailS, phoneS, addressOneS, addressTwoS, stateS, cityS, zipS, countryS;
        String profileNameB, firstNameB, lastNameB, emailB, phoneB, addressOneB, addressTwoB, stateB, cityB, zipB, countryB;
        String cardNumber, cardName, cardDate, CVV, cardType;

        //stores add task info
        private String TaskID = null, storeName = null, sizeFromGUI = null, typeOfTask = null, usernameFromGUI = null, passwordFromGUI = null, productName = null, profile = null, proxy = null, numberOfTasks = null,
            mode = null, reDelay = null, monDelay = null;

        private int reDelayInt, monDelayInt;

        private Boolean Userlogin = false;

        private Boolean checkMarked = false;
        private Boolean loginCheckMarked = false;
        private ObservableCollection<Task> tasks = new ObservableCollection<Task>();


        //init method
        public MainWindow()
        {
            InitializeComponent();
            shippingShow();
            SetWindowsInit();
            hideLoginFields();
            InitializeComponent();
            tasksListView.ItemsSource = tasks;
        }

        //start and stop all tasks buttons
        private void stopAllTasks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All tasks stopped");
        }
        private void startAllTasks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All tasks started");
        }

        //onClick for save task button
        //add payments field
        private void SaveTasks_Click(object sender, EventArgs e)
        {
            TaskID = IDBox.Text;
            storeName = StoreBox.Text;
            sizeFromGUI = SizeBox.Text;
            typeOfTask = TaskTypeBox.Text;
            usernameFromGUI = UsernameBox.Text;
            passwordFromGUI = PasswordBox.Text;
            productName = ProductBox.Text;
            profile = ProfileBox.Text;
            proxy = ProxyBox.Text;
            numberOfTasks = TaskNumberBox.Text;
            mode = ModeBox.Text;
            reDelay = RetryDelayBox.Text;
            monDelay = MonitorDelayBox.Text;

            Boolean IDExists = false;

            //check if id is already taken
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].getID().Equals(TaskID))
                {
                    IDExists = true;
                }
            }

            if (IDExists.Equals(false))
            {
                //convert the strings to int
                Int32.TryParse(reDelay, out reDelayInt);
                Int32.TryParse(monDelay, out monDelayInt);

                tasks.Add(new Task()
                {
                    Website = storeName,
                    ProductName = productName,
                    TypeOfTask = typeOfTask,
                    Profile = profile,
                    Size = sizeFromGUI,
                    MonitorDelay = monDelayInt,
                    Username = usernameFromGUI,
                    Password = passwordFromGUI,
                    ID = TaskID,
                    RetryDelay = reDelayInt,
                    Proxy = proxy
                });

                MessageBox.Show("Tasks Successfully Added");

                showTasksPage();
            }
            else
            {
                MessageBox.Show("That ID already exists, please enter a new one");
            }
        }

        private void ClearTasks_Click(object sender, EventArgs e)
        {
            tasks.Clear();
        }

        //Show shipping or billing boxes depending on user input
        private void shippingShow()
        {
            BillingLabel.TextDecorations = null;
            ShippingLabel.TextDecorations = TextDecorations.Underline;

            //set shipping boxes to visible
            ProfileBoxS.Visibility = Visibility.Visible;
            FirstNameBoxS.Visibility = Visibility.Visible;
            LastNameBoxS.Visibility = Visibility.Visible;
            EmailBoxS.Visibility = Visibility.Visible;
            PhoneBoxS.Visibility = Visibility.Visible;
            Add1BoxS.Visibility = Visibility.Visible;
            Add2BoxS.Visibility = Visibility.Visible;
            CityBoxS.Visibility = Visibility.Visible;
            StateBoxS.Visibility = Visibility.Visible;
            ZipBoxS.Visibility = Visibility.Visible;
            CountryBoxS.Visibility = Visibility.Visible;

            //set shipping labels to visible
            ProfileLabelS.Visibility = Visibility.Visible;
            FirstNameLabelS.Visibility = Visibility.Visible;
            LastNameLabelS.Visibility = Visibility.Visible;
            EmailLabelS.Visibility = Visibility.Visible;
            PhoneLabelS.Visibility = Visibility.Visible;
            Add1LabelS.Visibility = Visibility.Visible;
            Add2LabelS.Visibility = Visibility.Visible;
            CityLabelS.Visibility = Visibility.Visible;
            StateLabelS.Visibility = Visibility.Visible;
            ZipLabelS.Visibility = Visibility.Visible;
            CountryLabelS.Visibility = Visibility.Visible;

            //set billing boxes to invisible
            ProfileBoxB.Visibility = Visibility.Hidden;
            FirstNameBoxB.Visibility = Visibility.Hidden;
            LastNameBoxB.Visibility = Visibility.Hidden;
            EmailBoxB.Visibility = Visibility.Hidden;
            PhoneBoxB.Visibility = Visibility.Hidden;
            Add1BoxB.Visibility = Visibility.Hidden;
            Add2BoxB.Visibility = Visibility.Hidden;
            CityBoxB.Visibility = Visibility.Hidden;
            StateBoxB.Visibility = Visibility.Hidden;
            ZipBoxB.Visibility = Visibility.Hidden;
            CountryBoxB.Visibility = Visibility.Hidden;

            //set billing labels to invisible
            ProfileLabelB.Visibility = Visibility.Hidden;
            FirstNameLabelB.Visibility = Visibility.Hidden;
            LastNameLabelB.Visibility = Visibility.Hidden;
            EmailLabelB.Visibility = Visibility.Hidden;
            PhoneLabelB.Visibility = Visibility.Hidden;
            Add1LabelB.Visibility = Visibility.Hidden;
            Add2LabelB.Visibility = Visibility.Hidden;
            CityLabelB.Visibility = Visibility.Hidden;
            StateLabelB.Visibility = Visibility.Hidden;
            ZipLabelB.Visibility = Visibility.Hidden;
            CountryLabelB.Visibility = Visibility.Hidden;
        }
        private void billingShow()
        {
            ShippingLabel.TextDecorations = null;
            BillingLabel.TextDecorations = TextDecorations.Underline;

            //set billing boxes to visible
            ProfileBoxB.Visibility = Visibility.Visible;
            FirstNameBoxB.Visibility = Visibility.Visible;
            LastNameBoxB.Visibility = Visibility.Visible;
            EmailBoxB.Visibility = Visibility.Visible;
            PhoneBoxB.Visibility = Visibility.Visible;
            Add1BoxB.Visibility = Visibility.Visible;
            Add2BoxB.Visibility = Visibility.Visible;
            CityBoxB.Visibility = Visibility.Visible;
            StateBoxB.Visibility = Visibility.Visible;
            ZipBoxB.Visibility = Visibility.Visible;
            CountryBoxB.Visibility = Visibility.Visible;

            //set billing labels to visible
            ProfileLabelB.Visibility = Visibility.Visible;
            FirstNameLabelB.Visibility = Visibility.Visible;
            LastNameLabelB.Visibility = Visibility.Visible;
            EmailLabelB.Visibility = Visibility.Visible;
            PhoneLabelB.Visibility = Visibility.Visible;
            Add1LabelB.Visibility = Visibility.Visible;
            Add2LabelB.Visibility = Visibility.Visible;
            CityLabelB.Visibility = Visibility.Visible;
            StateLabelB.Visibility = Visibility.Visible;
            ZipLabelB.Visibility = Visibility.Visible;
            CountryLabelB.Visibility = Visibility.Visible;

            //set Shipping boxes to invisible
            ProfileBoxS.Visibility = Visibility.Hidden;
            FirstNameBoxS.Visibility = Visibility.Hidden;
            LastNameBoxS.Visibility = Visibility.Hidden;
            EmailBoxS.Visibility = Visibility.Hidden;
            PhoneBoxS.Visibility = Visibility.Hidden;
            Add1BoxS.Visibility = Visibility.Hidden;
            Add2BoxS.Visibility = Visibility.Hidden;
            CityBoxS.Visibility = Visibility.Hidden;
            StateBoxS.Visibility = Visibility.Hidden;
            ZipBoxS.Visibility = Visibility.Hidden;
            CountryBoxS.Visibility = Visibility.Hidden;

            //set shipping labels to invisible
            ProfileLabelS.Visibility = Visibility.Hidden;
            FirstNameLabelS.Visibility = Visibility.Hidden;
            LastNameLabelS.Visibility = Visibility.Hidden;
            EmailLabelS.Visibility = Visibility.Hidden;
            PhoneLabelS.Visibility = Visibility.Hidden;
            Add1LabelS.Visibility = Visibility.Hidden;
            Add2LabelS.Visibility = Visibility.Hidden;
            CityLabelS.Visibility = Visibility.Hidden;
            StateLabelS.Visibility = Visibility.Hidden;
            ZipLabelS.Visibility = Visibility.Hidden;
            CountryLabelS.Visibility = Visibility.Hidden;
        }

        //methods to switch pages
        private void showTasksPage()
        {
            ProfileGrid.Visibility = Visibility.Hidden;
            TasksGrid.Visibility = Visibility.Visible;
            AddTasksGrid.Visibility = Visibility.Hidden;
            ProxiesGrid.Visibility = Visibility.Hidden;
        }
        private void showAddTasksPage()
        {
            ProfileGrid.Visibility = Visibility.Hidden;
            TasksGrid.Visibility = Visibility.Hidden;
            AddTasksGrid.Visibility = Visibility.Visible;
            ProxiesGrid.Visibility = Visibility.Hidden;
        }
        private void showProfilePage()
        {
            ProfileGrid.Visibility = Visibility.Visible;
            TasksGrid.Visibility = Visibility.Hidden;
            AddTasksGrid.Visibility = Visibility.Hidden;
            ProxiesGrid.Visibility = Visibility.Hidden;
        }
        private void showProxyPage()
        {
            ProfileGrid.Visibility = Visibility.Hidden;
            TasksGrid.Visibility = Visibility.Hidden;
            AddTasksGrid.Visibility = Visibility.Hidden;
            ProxiesGrid.Visibility = Visibility.Visible;
        }

        //OnClick for add tasks page
        private void IDBoxClick_Click(object sender, EventArgs e)
        {
            if (IDBoxX == 0)
                IDBox.Clear();

            IDBoxX++;
        }
        private void ProductName_Click(object sender, EventArgs e)
        {
            if (ProductX == 0)
                ProductBox.Clear();

            ProductX++;
        }
        private void TaskNumber_Click(object sender, EventArgs e)
        {
            if (TaskNumberX == 0)
                TaskNumberBox.Clear();

            TaskNumberX++;
        }
        private void RetryDelay_Click(object sender, EventArgs e)
        {
            if (RetryDelayX == 0)
                RetryDelayBox.Clear();

            RetryDelayX++;
        }
        private void MonitorDelay_Click(object sender, EventArgs e)
        {
            if (MonitorDelayX == 0)
                MonitorDelayBox.Clear();

            MonitorDelayX++;
        }
        private void Username_Click(object sender, EventArgs e)
        {
            if (PasswordX == 0)
                PasswordBox.Clear();

            PasswordX++;
        }
        private void Password_Click(object sender, EventArgs e)
        {
            if (UsernameX == 0)
                PasswordBox.Clear();

            UsernameX++;
        }

        //checkbox methods for add tasks page
        private void hideLoginFields()
        {
            UsernameLabel.Visibility = Visibility.Hidden;
            UsernameRect.Visibility = Visibility.Hidden;
            UsernameBox.Visibility = Visibility.Hidden;

            PasswordLabel.Visibility = Visibility.Hidden;
            PasswordRect.Visibility = Visibility.Hidden;
            PasswordBox.Visibility = Visibility.Hidden;
        }
        private void LoginBoxChecked(object sender, RoutedEventArgs e)
        {
            UsernameLabel.Visibility = Visibility.Visible;
            UsernameRect.Visibility = Visibility.Visible;
            UsernameBox.Visibility = Visibility.Visible;

            PasswordLabel.Visibility = Visibility.Visible;
            PasswordRect.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Visible;

            loginCheckMarked = true;
        }
        private void LoginBoxUnchecked(object sender, RoutedEventArgs e)
        {
            UsernameLabel.Visibility = Visibility.Hidden;
            UsernameRect.Visibility = Visibility.Hidden;
            UsernameBox.Visibility = Visibility.Hidden;

            PasswordLabel.Visibility = Visibility.Hidden;
            PasswordRect.Visibility = Visibility.Hidden;
            PasswordBox.Visibility = Visibility.Hidden;

            loginCheckMarked = false;
        }

        //OnClick for shipping boxes
        private void ProfileBoxS_Click(object sender, EventArgs e)
        {
            if (profileXS == 0)
                ProfileBoxS.Clear();

            profileXS++;
        }
        private void FirstNameBoxS_Click(object sender, EventArgs e)
        {
            if (firstXS == 0)
                FirstNameBoxS.Clear();

            firstXS++;
        }
        private void LastNameBoxS_Click(object sender, EventArgs e)
        {
            if (lastXS == 0)
                LastNameBoxS.Clear();

            lastXS++;
        }
        private void EmailBoxS_Click(object sender, EventArgs e)
        {
            if (emailXS == 0)
                EmailBoxS.Clear();

            emailXS++;
        }
        private void PhoneBoxS_Click(object sender, EventArgs e)
        {
            if (phoneXS == 0)
                PhoneBoxS.Clear();

            phoneXS++;
        }
        private void Add1BoxS_Click(object sender, EventArgs e)
        {
            if (a1XS == 0)
                Add1BoxS.Clear();

            a1XS++;
        }
        private void Add2BoxS_Click(object sender, EventArgs e)
        {
            if (a2XS == 0)
                Add2BoxS.Clear();

            a2XS++;
        }
        private void StateBoxS_Click(object sender, EventArgs e)
        {
            if (stateXS == 0)
                StateBoxS.Clear();


            stateXS++;
        }
        private void CityBoxS_Click(object sender, EventArgs e)
        {
            if (cityXS == 0)
                CityBoxS.Clear();

            cityXS++;
        }
        private void ZipBoxS_Click(object sender, EventArgs e)
        {
            if (zipXS == 0)
                ZipBoxS.Clear();

            zipXS++;
        }
        private void CountryBoxS_Click(object sender, EventArgs e)
        {
            if (countryXS == 0)
                CountryBoxS.Clear();

            countryXS++;
        }

        //OnClick for billing boxes
        private void ProfileBoxB_Click(object sender, EventArgs e)
        {
            if (profileXB == 0)
                ProfileBoxB.Clear();

            profileXB++;
        }
        private void FirstNameBoxB_Click(object sender, EventArgs e)
        {
            if (firstXB == 0)
                FirstNameBoxB.Clear();

            firstXB++;
        }
        private void LastNameBoxB_Click(object sender, EventArgs e)
        {
            if (lastXB == 0)
                LastNameBoxB.Clear();

            lastXB++;
        }
        private void EmailBoxB_Click(object sender, EventArgs e)
        {
            if (emailXB == 0)
                EmailBoxB.Clear();

            emailXB++;
        }
        private void PhoneBoxB_Click(object sender, EventArgs e)
        {
            if (phoneXB == 0)
                PhoneBoxB.Clear();

            phoneXB++;
        }
        private void Add1BoxB_Click(object sender, EventArgs e)
        {
            if (a1XB == 0)
                Add1BoxB.Clear();

            a1XB++;
        }
        private void Add2BoxB_Click(object sender, EventArgs e)
        {
            if (a2XB == 0)
                Add2BoxB.Clear();

            a2XB++;
        }
        private void StateBoxB_Click(object sender, EventArgs e)
        {
            if (stateXB == 0)
                StateBoxB.Clear();


            stateXB++;
        }
        private void CityBoxB_Click(object sender, EventArgs e)
        {
            if (cityXB == 0)
                CityBoxB.Clear();

            cityXB++;
        }
        private void ZipBoxB_Click(object sender, EventArgs e)
        {
            if (zipXB == 0)
                ZipBoxB.Clear();

            zipXB++;
        }
        private void CountryBoxB_Click(object sender, EventArgs e)
        {
            if (countryXB == 0)
                CountryBoxB.Clear();

            countryXB++;
        }

        private void CardNumberBox_Click(object sender, EventArgs e)
        {
            if (cNumberX == 0)
                CardNumberBox.Clear();

            cNumberX++;
        }
        private void CardNameBox_Click(object sender, EventArgs e)
        {
            if (cNameX == 0)
                CardNameBox.Clear();

            cNameX++;
        }
        private void ExDateBox_Click(object sender, EventArgs e)
        {
            if (cDateX == 0)
                ExDateBox.Clear();

            cDateX++;
        }
        private void CVVBox_Click(object sender, EventArgs e)
        {
            if (cvvX == 0)
                CVVBox.Clear();

            cvvX++;
        }
        private void CardBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            txtBox.MaxLength = 19;

            try
            {
                txtBox.Text = CardNumberBox.Text.Substring(0, 4) + "-" + CardNumberBox.Text.Substring(4, 4) + "-"
                    + CardNumberBox.Text.Substring(8, 4) + "-" + CardNumberBox.Text.Substring(12, 4);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Write("ERROR");
            }
        }
        private void MonthBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            txtBox.MaxLength = 7;

            try
            {
                txtBox.Text = ExDateBox.Text.Substring(0, 2) + "/" + ExDateBox.Text.Substring(2);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Write("ERROR");
            }
        }
        private void PhoneBoxS_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            txtBox.MaxLength = 7;

            try
            {
                txtBox.Text = "(" + PhoneBoxS.Text.Substring(0, 3) + ")" + PhoneBoxS.Text.Substring(3, 3) + "-" + PhoneBoxS.Text.Substring(6, 4);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Write("ERROR");
            }
        }
        private void PhoneBoxB_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            txtBox.MaxLength = 7;

            try
            {
                txtBox.Text = "(" + PhoneBoxB.Text.Substring(0, 3) + ")" + PhoneBoxB.Text.Substring(3, 3) + "-" + PhoneBoxB.Text.Substring(6, 4);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Write("ERROR");
            }
        }
        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            BillingLabel.Visibility = Visibility.Hidden;
            ShippingLabel.TextDecorations = TextDecorations.Underline;
            shippingShow();
            checkMarked = true;
        }
        private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            BillingLabel.Visibility = Visibility.Visible;
            checkMarked = false;
        }
        private void ShippingLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            shippingShow();
        }
        private void BillingLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            billingShow();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkMarked == true)
            {
                profileNameS = ProfileBoxS.Text;
                firstNameS = FirstNameBoxS.Text;
                lastNameS = LastNameBoxS.Text;
                emailS = EmailBoxS.Text;
                phoneS = PhoneBoxS.Text;
                addressOneS = Add1BoxS.Text;
                addressTwoS = Add2BoxS.Text;
                countryS = CountryBoxS.Text;
                cityS = CityBoxS.Text;
                stateS = StateBoxS.Text;
                zipS = ZipBoxS.Text;

                cardType = CardDropDown.Text;
                cardNumber = CardNumberBox.Text;
                cardName = CardNameBox.Text;
                CVV = CVVBox.Text;
                cardDate = ExDateBox.Text;

                profileNameB = profileNameS;
                firstNameB = firstNameS;
                lastNameB = lastNameS;
                emailB = emailS;
                phoneB = phoneS;
                addressOneB = addressOneS;
                addressTwoB = addressTwoS;
                countryB = countryS;
                cityB = cityS;
                stateB = stateS;
                zipB = zipS;

                MessageBox.Show("Profile Saved");
            }
            else if (checkMarked == false)
            {
                //get data from shipping boxes
                profileNameS = ProfileBoxS.Text;
                firstNameS = FirstNameBoxS.Text;
                lastNameS = LastNameBoxS.Text;
                emailS = EmailBoxS.Text;
                phoneS = PhoneBoxS.Text;
                addressOneS = Add1BoxS.Text;
                addressTwoS = Add2BoxS.Text;
                countryS = CountryBoxS.Text;
                cityS = CityBoxS.Text;
                stateS = StateBoxS.Text;
                zipS = ZipBoxS.Text;

                //get data from billing boxes
                profileNameB = ProfileBoxB.Text;
                firstNameB = FirstNameBoxB.Text;
                lastNameB = LastNameBoxB.Text;
                emailB = EmailBoxB.Text;
                phoneB = PhoneBoxB.Text;
                addressOneB = Add1BoxB.Text;
                addressTwoB = Add2BoxB.Text;
                countryB = CountryBoxB.Text;
                cityB = CityBoxB.Text;
                stateB = StateBoxB.Text;
                zipB = ZipBoxB.Text;

                cardNumber = CardNumberBox.Text;
                cardName = CardNameBox.Text;
                CVV = CVVBox.Text;
                cardDate = ExDateBox.Text;

                MessageBox.Show("Profile Saved");
            }
            else
            {
                MessageBox.Show("Irrational Response from check mark");
            }
        }
        private void AddTasks_Click(object sender, RoutedEventArgs e)
        {

        }

        //Navigation Menu Buttons
        private void TasksIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            showTasksPage();
        }
        private void ProfileIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            showProfilePage();
        }
        private void AddTasksIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            showAddTasksPage();
        }
        private void ProxiesIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            showProxyPage();
        }

        //Play, pause, and stop buttons for tasks page
        private void StartIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Started");
        }
        private void PauseIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Paused");
        }
        private void StopIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Stopped");
        }

        //addTasksButton
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            showAddTasksPage();
        }

        //call this on start to show the correct windows
        private void SetWindowsInit()
        {
            ProfileGrid.Visibility = Visibility.Hidden;
            TasksGrid.Visibility = Visibility.Visible;
            AddTasksGrid.Visibility = Visibility.Hidden;
            ProxiesGrid.Visibility = Visibility.Hidden;
        }
    }

    public class Task
    {
        public String ID { get; set; }
        public String Profile { get; set; }
        public String Proxy { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Website { get; set; }
        public String TypeOfTask { get; set; }
        public String ProductName { get; set; }
        public String Mode { get; set; }
        public int RetryDelay { get; set; }
        public int MonitorDelay { get; set; }
        public String Size { get; set; }
        public String NumberOfTasks { get; set; }

        public String getID()
        {
            return ID;
        }
    }
}
