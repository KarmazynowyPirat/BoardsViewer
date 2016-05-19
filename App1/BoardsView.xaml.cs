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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BoardsView : Page
    {
        public BoardsView()
        {
            this.InitializeComponent();
            Boards = new BoardsViewModel();
        }

        public BoardsViewModel Boards { get; set; }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Board;

            //var frame = Window.Current.Content as Frame;

            //frame.Navigate(typeof(ThreadsView), item.board);
            this.Frame.Navigate(typeof(ThreadsView), item.board);
        }
    }
}
