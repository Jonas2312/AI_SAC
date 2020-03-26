﻿#pragma checksum "..\..\..\..\View\EditorView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0E25B9400C99489EC9EE7C96A6ACC973CF22DF2C9042DCA130C8F52C864EB417"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AI_SAC.View;
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


namespace AI_SAC.View {
    
    
    /// <summary>
    /// EditorView
    /// </summary>
    public partial class EditorView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewDatabase;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadDatabase;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartProgramButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StopProgramButton;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddItemButton;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveItemButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProgramRunningText;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProgramNotRunningText;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\View\EditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AI_SAC.View.ExcelTableView XMLData;
        
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
            System.Uri resourceLocater = new System.Uri("/AI_SAC;component/view/editorview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\EditorView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.NewDatabase = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\View\EditorView.xaml"
            this.NewDatabase.Click += new System.Windows.RoutedEventHandler(this.NewDataBaseButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LoadDatabase = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\View\EditorView.xaml"
            this.LoadDatabase.Click += new System.Windows.RoutedEventHandler(this.LoadDataBaseButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.StartProgramButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\View\EditorView.xaml"
            this.StartProgramButton.Click += new System.Windows.RoutedEventHandler(this.StartProgramButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.StopProgramButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\View\EditorView.xaml"
            this.StopProgramButton.Click += new System.Windows.RoutedEventHandler(this.StopProgramButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\View\EditorView.xaml"
            this.AddItemButton.Click += new System.Windows.RoutedEventHandler(this.AddItemButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RemoveItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\View\EditorView.xaml"
            this.RemoveItemButton.Click += new System.Windows.RoutedEventHandler(this.RemoveItemButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ProgramRunningText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.ProgramNotRunningText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.XMLData = ((AI_SAC.View.ExcelTableView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

