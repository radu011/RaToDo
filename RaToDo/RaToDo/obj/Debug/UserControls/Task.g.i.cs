﻿#pragma checksum "..\..\..\UserControls\Task.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "65169B1572908818EC5193E38E43809B3AE6F9E80FF33D9697964A32C851F1AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.Sharp;
using RaToDo.UserControls;
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


namespace RaToDo.UserControls {
    
    
    /// <summary>
    /// Task
    /// </summary>
    public partial class Task : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal RaToDo.UserControls.Task task;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderMain;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCheck;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.Sharp.IconImage btnCheckIcon;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtblockTitle;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtblockCategory;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtblockDescription;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtblockDeadline;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtblockTypeOfTask;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\UserControls\Task.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.Sharp.IconImage btnEditImage;
        
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
            System.Uri resourceLocater = new System.Uri("/RaToDo;component/usercontrols/task.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\Task.xaml"
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
            this.task = ((RaToDo.UserControls.Task)(target));
            return;
            case 2:
            this.borderMain = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.btnCheck = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\UserControls\Task.xaml"
            this.btnCheck.Click += new System.Windows.RoutedEventHandler(this.btnCheck_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCheckIcon = ((FontAwesome.Sharp.IconImage)(target));
            return;
            case 5:
            this.txtblockTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtblockCategory = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtblockDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtblockDeadline = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.txtblockTypeOfTask = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 153 "..\..\..\UserControls\Task.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 164 "..\..\..\UserControls\Task.xaml"
            this.btnEdit.Click += new System.Windows.RoutedEventHandler(this.btnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnEditImage = ((FontAwesome.Sharp.IconImage)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

