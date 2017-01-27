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
    public sealed partial class TaskView : Page
    {
        private Dashboard _context;
        private Task _task;

        public TaskView()
        {
            this.InitializeComponent();
        }

        private void UpdateTask(object sender, RoutedEventArgs e)
        {
            _task.Deadline = DatePicker.Date.ToString();
            Frame.Navigate(typeof(SelectedDashboard), _context);
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            _context.RemoveTask(_task);
            Frame.Navigate(typeof(SelectedDashboard), _context);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = (ContextTask)e.Parameter;
            _context = parameter.Context;
            _task = parameter.Task;
            base.OnNavigatedTo(e);

            nameText.DataContext = _task;
            descText.DataContext = _task;
            stateText.DataContext = _task;
            DatePicker.Date = Convert.ToDateTime(_task.Deadline);
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
