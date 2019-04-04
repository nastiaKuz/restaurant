﻿#pragma checksum "..\..\..\Provider\ProviderWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0F37EEA93920870130984F0D78DE9F81"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Restaurant.Provider;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Restaurant.Provider {
    
    
    /// <summary>
    /// ProviderWindow
    /// </summary>
    public partial class ProviderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 16 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl ProviderMenu;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem storageTab;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddStorageItemBtn;
        
        #line default
        #line hidden
        
        /// <summary>
        /// StorageGrid Name Field
        /// </summary>
        
        #line 29 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.DataGrid StorageGrid;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem providersTab;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProviderBtn;
        
        #line default
        #line hidden
        
        /// <summary>
        /// ProvidersGrid Name Field
        /// </summary>
        
        #line 68 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.DataGrid ProvidersGrid;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem orderIngredientsTab;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddOrderIngr;
        
        #line default
        #line hidden
        
        /// <summary>
        /// ordIngrGrid Name Field
        /// </summary>
        
        #line 99 "..\..\..\Provider\ProviderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.DataGrid ordIngrGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/wpf-test;component/provider/providerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Provider\ProviderWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Change_User);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Help_Item);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 13 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.About_Item);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 14 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Program);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ProviderMenu = ((System.Windows.Controls.TabControl)(target));
            return;
            case 6:
            this.storageTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 7:
            this.AddStorageItemBtn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Provider\ProviderWindow.xaml"
            this.AddStorageItemBtn.Click += new System.Windows.RoutedEventHandler(this.AddStorageItemBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StorageGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.providersTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 12:
            this.AddProviderBtn = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Provider\ProviderWindow.xaml"
            this.AddProviderBtn.Click += new System.Windows.RoutedEventHandler(this.AddProviderBtn_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ProvidersGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 16:
            this.orderIngredientsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 17:
            this.AddOrderIngr = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\Provider\ProviderWindow.xaml"
            this.AddOrderIngr.Click += new System.Windows.RoutedEventHandler(this.AddOrderIngr_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.ordIngrGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 49 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateStorageBtn_Click);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 50 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteStorageBtn_Click);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 80 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateProviderBtn_Click);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 81 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteProviderBtn_Click);
            
            #line default
            #line hidden
            break;
            case 19:
            
            #line 124 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateOrderIngredientsBtn_Click);
            
            #line default
            #line hidden
            break;
            case 20:
            
            #line 125 "..\..\..\Provider\ProviderWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteOrderIngredientsBtn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
