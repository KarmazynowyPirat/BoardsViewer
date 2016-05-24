﻿#pragma checksum "C:\Users\Krzys\Documents\App1\App1\SingleThreadView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BEA85C2D64F80C4AA3D682133C923F30"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1
{
    partial class SingleThreadView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        private class SingleThreadView_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ISingleThreadView_Bindings
        {
            private global::App1.SingleThreadView dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ItemsControl obj2;

            public SingleThreadView_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2:
                        this.obj2 = (global::Windows.UI.Xaml.Controls.ItemsControl)target;
                        break;
                    default:
                        break;
                }
            }

            // ISingleThreadView_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // SingleThreadView_obj1_Bindings

            public void SetDataRoot(global::App1.SingleThreadView newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::App1.SingleThreadView obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_SingleThreadViewModel(obj.SingleThreadViewModel, phase);
                    }
                }
            }
            private void Update_SingleThreadViewModel(global::App1.ViewModels.SingleThreadViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_SingleThreadViewModel_Posts(obj.Posts, phase);
                    }
                }
            }
            private void Update_SingleThreadViewModel_Posts(global::System.Collections.Generic.List<global::App1.Models.Post> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj2, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Image element3 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 22 "..\..\..\SingleThreadView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element3).Loaded += this.ImageLoaded;
                    #line 22 "..\..\..\SingleThreadView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element3).Tapped += this.ImageTapped;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Image element4 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 26 "..\..\..\SingleThreadView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)element4).Loaded += this.ImageLoaded;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    SingleThreadView_obj1_Bindings bindings = new SingleThreadView_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

