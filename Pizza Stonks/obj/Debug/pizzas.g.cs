#pragma checksum "..\..\pizzas.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5F2349B7D00A941FC48A25CAA09D4455B59AB0E786874061A487C893CEB37E4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Pizza_Stonks;
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


namespace Pizza_Stonks {
    
    
    /// <summary>
    /// pizzas
    /// </summary>
    public partial class pizzas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\pizzas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvpizza;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\pizzas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbSelectedPizza;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\pizzas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deletePizza;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\pizzas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddPizza;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\pizzas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btUpdatePizza;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\pizzas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddIngr;
        
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
            System.Uri resourceLocater = new System.Uri("/Pizza Stonks;component/pizzas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\pizzas.xaml"
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
            
            #line 8 "..\..\pizzas.xaml"
            ((Pizza_Stonks.pizzas)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lvpizza = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.tbSelectedPizza = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.deletePizza = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\pizzas.xaml"
            this.deletePizza.Click += new System.Windows.RoutedEventHandler(this.deletePizza_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btAddPizza = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\pizzas.xaml"
            this.btAddPizza.Click += new System.Windows.RoutedEventHandler(this.btAddPizza_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btUpdatePizza = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\pizzas.xaml"
            this.btUpdatePizza.Click += new System.Windows.RoutedEventHandler(this.btUpdatePizza_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btAddIngr = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\pizzas.xaml"
            this.btAddIngr.Click += new System.Windows.RoutedEventHandler(this.btAddIngr_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

