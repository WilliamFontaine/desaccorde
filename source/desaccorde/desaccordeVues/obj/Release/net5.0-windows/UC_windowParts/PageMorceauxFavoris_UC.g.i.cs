﻿#pragma checksum "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F7E90BF64A1EC53F6F572A73B7035F3B33B19219"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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
using desaccordeVues.UC_windowParts;


namespace desaccordeVues.UC_windowParts {
    
    
    /// <summary>
    /// PageMorceauxFavoris_UC
    /// </summary>
    public partial class PageMorceauxFavoris_UC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 10 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal desaccordeVues.UC_windowParts.PageMorceauxFavoris_UC root;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lv;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/desaccordeVues;V1.0.0.0;component/uc_windowparts/pagemorceauxfavoris_uc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.root = ((desaccordeVues.UC_windowParts.PageMorceauxFavoris_UC)(target));
            return;
            case 2:
            
            #line 31 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Play_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 36 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Random_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lv = ((System.Windows.Controls.ListView)(target));
            
            #line 46 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            this.lv.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Double_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 67 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.TitreSort_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 73 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.AuteurSort_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 79 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.DateSort_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 93 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SupprimerFavoris_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 99 "..\..\..\..\UC_windowParts\PageMorceauxFavoris_UC.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItemPlaylistMorceau_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

