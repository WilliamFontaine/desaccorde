﻿#pragma checksum "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "113EF2EE7118C8454496E9AB99B4A9893278F525"
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
    /// PageAlbumDetaillee_UC
    /// </summary>
    public partial class PageAlbumDetaillee_UC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 10 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal desaccordeVues.UC_windowParts.PageAlbumDetaillee_UC root;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
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
            System.Uri resourceLocater = new System.Uri("/desaccordeVues;V1.0.0.0;component/uc_windowparts/pagealbumdetaillee_uc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
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
            this.root = ((desaccordeVues.UC_windowParts.PageAlbumDetaillee_UC)(target));
            return;
            case 2:
            
            #line 47 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 62 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Ajouter_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 74 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Commentaire_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 84 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Dislike_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 94 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Like_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 110 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Play_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 115 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Random_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lv = ((System.Windows.Controls.ListView)(target));
            
            #line 125 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            this.lv.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Double_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 165 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AjouterFavorisMorceau_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 177 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AvisMorceau_Click);
            
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
            case 11:
            
            #line 172 "..\..\..\..\UC_windowParts\PageAlbumDetaillee_UC.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItemPlaylistMorceau_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

