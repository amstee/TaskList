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
    public sealed partial class SelectedDashboard : Page
    {
        private Dashboard _context;

        public SelectedDashboard()
        {
            this.InitializeComponent();
        }

        private void DeleteDashboard(object sender, RoutedEventArgs e)
        {
            Dashboard.RemoveDashboard(_context);
            Frame.Navigate(typeof(DashboardView), null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = (Dashboard)e.Parameter;
            _context = parameter;
            base.OnNavigatedTo(e);

            Title.DataContext = _context;
            TasksContainer.ItemsSource = _context.FirstHalfTask();
            TasksContainer2.ItemsSource = _context.SecondHalfTask();
        }

        private void TaskViewNavigation(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;
            var code = (Task)button.DataContext;
            var codePass = new ContextTask(_context, code);
            Frame.Navigate(typeof(TaskView), codePass);
        }

        private void TaskAddNavigation(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaskAdd), _context);
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
