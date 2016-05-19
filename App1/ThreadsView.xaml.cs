using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using App1.Models;
using App1.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThreadsView : Page
    {
        public ThreadsView()
        {
            this.InitializeComponent();
            ThreadsViewModel = new ThreadsViewModel();

            //Frame rootFrame = Window.Current.Content as Frame;

            //if (rootFrame.CanGoBack)
            //{
            //    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            //        AppViewBackButtonVisibility.Visible;
            //}
            //else
            //{
            //    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            //}

            //SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) =>
            //{
            //    if (rootFrame.CanGoBack)
            //    {
            //        rootFrame.GoBack();
            //    }
            //};
        }

        public ThreadsViewModel ThreadsViewModel { get; set; }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    ThreadsViewModel.CurrentBoard = (string)e.Parameter;
        //    //base.OnNavigatedTo(e);
        //}
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            ThreadsViewModel.CurrentBoard = (string)e.Parameter;

            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //ThreadsViewModel.CurrentBoard = (string)e.Parameter;
            base.OnNavigatingFrom(e);
        }

        private void ImageLoaded(object sender, RoutedEventArgs e)
        {
            var x = e.OriginalSource;
            Image img = sender as Image;
            if (img != null)
            {
                var data = (Thread)img.DataContext;

                //change in future
                var uri = new Uri(String.Concat("https://i.4cdn.org/", ThreadsViewModel.CurrentBoard, "/", data.tim, data.ext));
                img.Source = new BitmapImage(uri);
            }
        }

        private async void ImageTapped(object sender, TappedRoutedEventArgs e)
        {
            var image = sender as Image;

            //var popup = new Popup();

            //var stackPanel = new StackPanel();
            //stackPanel.VerticalAlignment = VerticalAlignment.Center;
            //stackPanel.HorizontalAlignment = HorizontalAlignment.Center;

            //var grid = new Grid();
            //grid.Children.Add(stackPanel);

            //var img = new Image();
            //img.Source = image.Source;

            //var scrollViewer = new ScrollViewer();
            //scrollViewer.Content = img;

            //var button = new Button();
            //button.Tapped += (a, b) => popup.IsOpen = false;
            //button.Content = "Close";
            //button.Height = 50;
            //button.Width = 100;

            //stackPanel.Children.Add(scrollViewer);
            //stackPanel.Children.Add(button);

            ////popup.Child = stackPanel;
            //popup.Child = grid;
            //popup.IsOpen = true;


            var dialog = new ContentDialog();

            var scrollViewer = new ScrollViewer();
            var stackPanel = new StackPanel();
            stackPanel.Children.Add(scrollViewer);

            var img = new Image();
            img.Source = image.Source;
            img.Stretch = Stretch.Fill;

            var button = new Button();
            button.Tapped += (a, b) => dialog.Hide();
            button.Content = "Close";
            button.Height = 50;
            button.Width = 100;

            stackPanel.Children.Add(button);

            scrollViewer.Content = img;

            dialog.Content = stackPanel;

            await dialog.ShowAsync();
        }

        private void SelectedThread(object sender, RoutedEventArgs routedEventArgs)
        {
            var button = sender as Button;
            var dataContext = button.DataContext as Thread;

            var frame = Window.Current.Content as Frame;

            frame.Navigate(typeof(SingleThreadView), new TransitionThreadsToPost(dataContext.no,ThreadsViewModel.CurrentBoard));
        }
    }
}
