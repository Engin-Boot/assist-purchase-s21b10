﻿#pragma checksum "..\..\..\AddProductForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E18D73601595B5F6821666459C0BE5ADF7601877"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AssistPurchaseFrontend;
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


namespace AssistPurchaseFrontend {
    
    
    /// <summary>
    /// AddProductForm
    /// </summary>
    public partial class AddProductForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ProductImage;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageViewer;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductId;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Features;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Services;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DisplaySize;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\AddProductForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AssistPurchaseFrontend;component/addproductform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddProductForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProductImage = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ImageViewer = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.ProductId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ProductName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Features = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Services = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DisplaySize = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\AddProductForm.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.AddProduct_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\AddProductForm.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

