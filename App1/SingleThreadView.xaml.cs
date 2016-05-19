using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class SingleThreadView : Page
    {
        public SingleThreadView()
        {
            this.InitializeComponent();
            this.SingleThreadViewModel = new SingleThreadViewModel();

            //Frame rootFrame = Window.Current.Content as Frame;
            //SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) =>
            //{
            //    if (rootFrame.CanGoBack)
            //    {
            //        rootFrame.GoBack();
            //    }
            //};
        }

        public SingleThreadViewModel SingleThreadViewModel { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = e.Parameter as TransitionThreadsToPost;

            SingleThreadViewModel.CurrentBoard = parameters.CurrentBoard;
            SingleThreadViewModel.ThreadNumber = parameters.ThreadId.ToString();

            //Frame rootFrame = Window.Current.Content as Frame;
            var rootFrame = Frame;
            if (rootFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().BackRequested += (s, x) =>
                {
                    if (rootFrame.CanGoBack)
                    {
                        //rootFrame.Navigate(typeof (ThreadsView), SingleThreadViewModel.CurrentBoard);
                        rootFrame.GoBack();
                    }
                };
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
            SystemNavigationManager.GetForCurrentView().BackRequested -= null;
            //disabling posibility of backing on other pages
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            base.OnNavigatingFrom(e);
        }

        private void ImageLoaded(object sender, RoutedEventArgs e)
        {
            var x = e.OriginalSource;
            Image img = sender as Image;
            if (img != null)
            {
                var data = (Post)img.DataContext;

                //if post do not have image, collapse space for image
                if (data.tim == 0)
                {
                    img.Visibility = Visibility.Collapsed;
                    return;
                }

                //change in future
                var uri = new Uri(String.Concat("https://i.4cdn.org/", SingleThreadViewModel.CurrentBoard, "/", data.tim, data.ext));
                img.Source = new BitmapImage(uri);
            }
        }

        private async void ImageTapped(object sender, TappedRoutedEventArgs e)
        {
            var image = sender as Image;

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
    }
}
