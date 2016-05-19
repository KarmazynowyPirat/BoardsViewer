using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App1.Models;
using App1.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Boards = new BoardsViewModel();
            ContentFrame.Navigate(typeof (BoardsView));
        }

        public BoardsViewModel Boards { get; set; }

        private void HamburgerMenu_Click(object sender, RoutedEventArgs e)
        {
            HamburgerSplitView.IsPaneOpen = !HamburgerSplitView.IsPaneOpen;
        }

        private void LoadBoards(object sender, TappedRoutedEventArgs e)
        {
            HamburgerSplitView.IsPaneOpen = false;

            ContentFrame.Navigate(typeof(BoardsView));
        }
    }
}
