using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace TaskList.src
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class TaskAdd : Page
    {
        private Dashboard _context;

        public TaskAdd()
        {
            this.InitializeComponent();
            Task task = new Task();
            nameText.DataContext = task;
            descText.DataContext = task;
            Submit.DataContext = task;
            stateText.DataContext = task;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = (Dashboard)e.Parameter;
            _context = parameter;
            base.OnNavigatedTo(e);
        }

        private void SubmitTask(object sender, RoutedEventArgs e)
        {
            if (sender == null)
                return;
            Task task = (Task) ((Button) sender).DataContext;

            task.Created = DateTime.Now.ToString();
            task.Deadline = DatePicker.Date.ToString();
            _context.AddTask(task);
            Frame.Navigate(typeof(SelectedDashboard), _context);
        }

        private void PaneDashboardOpen(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = true;
        }

        private void PaneDashboardClose(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
        }

        private void CreateDashboardView(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DashboardAdd), null);
        }

        private void CreateTaskView(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TaskAdd), null);
        }

        private void GoToHomeView(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DashboardView), null);
        }

        private void LeaveTaskList(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
    }
}
