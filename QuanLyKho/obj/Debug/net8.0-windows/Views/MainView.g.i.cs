﻿#pragma checksum "..\..\..\..\Views\MainView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1F8603D9C14C5BF3D3D83A39709B9C9082DCE881"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ManageKho.UserControlAT;
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


namespace ManageKho.Views {
    
    
    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEmployee;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSupplier;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCustomer;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObject;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInput;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOutput;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTimeKeeping;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\MainView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/QuanLyKho;V1.0.0.0;component/views/mainview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\MainView.xaml"
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
            this.btnEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Views\MainView.xaml"
            this.btnEmployee.Click += new System.Windows.RoutedEventHandler(this.btnEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnSupplier = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Views\MainView.xaml"
            this.btnSupplier.Click += new System.Windows.RoutedEventHandler(this.btnSupplier_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Views\MainView.xaml"
            this.btnCustomer.Click += new System.Windows.RoutedEventHandler(this.btnCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnObject = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Views\MainView.xaml"
            this.btnObject.Click += new System.Windows.RoutedEventHandler(this.btnObject_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnInput = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Views\MainView.xaml"
            this.btnInput.Click += new System.Windows.RoutedEventHandler(this.btnInput_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOutput = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Views\MainView.xaml"
            this.btnOutput.Click += new System.Windows.RoutedEventHandler(this.btnOutput_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnTimeKeeping = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Views\MainView.xaml"
            this.btnTimeKeeping.Click += new System.Windows.RoutedEventHandler(this.btnTimeKeeping_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Views\MainView.xaml"
            this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.btnLogout_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ContentArea = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

