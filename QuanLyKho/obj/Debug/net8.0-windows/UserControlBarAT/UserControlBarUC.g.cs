﻿#pragma checksum "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "615E7B5BE1DC009E4377969D5E1E0D6F6BE31BE6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using QuanLyKho.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace QuanLyKho.UserControlAT {
    
    
    /// <summary>
    /// UserControlBarUC
    /// </summary>
    public partial class UserControlBarUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MaximizeButton;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton MenuToggleButton;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitle;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup OptionMenu;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ContentArea;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyKho;component/usercontrolbarat/usercontrolbaruc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 37 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinimizeButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MaximizeButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            this.MaximizeButton.Click += new System.Windows.RoutedEventHandler(this.MaximizeButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 83 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MenuToggleButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 109 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            this.MenuToggleButton.Click += new System.Windows.RoutedEventHandler(this.MenuToggleButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.OptionMenu = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 7:
            
            #line 123 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StatisticsButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 126 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 146 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnInput_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 159 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnOutput_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 172 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnObject_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 185 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSupplier_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 198 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 211 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnUnit_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 224 "..\..\..\..\UserControlBarAT\UserControlBarUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnCategory_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.ContentArea = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

