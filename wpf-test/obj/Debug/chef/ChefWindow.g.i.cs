﻿#pragma checksum "..\..\..\chef\ChefWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E66B1FD040F523389F80CFCB1F129771"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using wpf_test.chef;


namespace wpf_test.chef {
    
    
    /// <summary>
    /// ChefWindow
    /// </summary>
    public partial class ChefWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 10 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl ChefMenu;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem currentChecksTab;
        
        #line default
        #line hidden
        
        /// <summary>
        /// CurrentChecksGrid Name Field
        /// </summary>
        
        #line 20 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.DataGrid CurrentChecksGrid;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem allChecksTab;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock2_Copy;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker;
        
        #line default
        #line hidden
        
        /// <summary>
        /// AllChecksGrid Name Field
        /// </summary>
        
        #line 56 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.DataGrid AllChecksGrid;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabletsTab;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addRecipeBtn;
        
        #line default
        #line hidden
        
        /// <summary>
        /// RecipesGrid Name Field
        /// </summary>
        
        #line 78 "..\..\..\chef\ChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.DataGrid RecipesGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/wpf-test;component/chef/chefwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\chef\ChefWindow.xaml"
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
            this.ChefMenu = ((System.Windows.Controls.TabControl)(target));
            return;
            case 2:
            this.currentChecksTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 3:
            this.CurrentChecksGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.allChecksTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.textBlock2_Copy = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.datePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 55 "..\..\..\chef\ChefWindow.xaml"
            this.datePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.datePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AllChecksGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.tabletsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 10:
            this.addRecipeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\chef\ChefWindow.xaml"
            this.addRecipeBtn.Click += new System.Windows.RoutedEventHandler(this.AddRecipeBtn_OnClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.RecipesGrid = ((System.Windows.Controls.DataGrid)(target));
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
            case 4:
            
            #line 35 "..\..\..\chef\ChefWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateStatusBtn_Click);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 90 "..\..\..\chef\ChefWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateBtn_Click);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 91 "..\..\..\chef\ChefWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteBtn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
