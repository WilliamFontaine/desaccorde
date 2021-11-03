using Modele;
using System.Windows;
using System.Windows.Controls;

namespace desaccordeVues.Selector
{
    class OeuvreTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MorceauTemplate
        {
            get;
            set;
        }

        public DataTemplate AlbumTemplate
        {
            get;
            set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Morceau) return MorceauTemplate;
            if (item is Album) return AlbumTemplate;
            return base.SelectTemplate(item, container);
        }
    }
}
