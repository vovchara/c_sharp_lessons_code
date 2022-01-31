using ShopModel.Model;
using System;
using System.Windows.Controls;

namespace CSharpLess.View
{
    /// <summary>
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public event Action BackClicked = delegate { };

        public CategoryPage()
        {
            InitializeComponent();
            BackBtn.Click += (s,e) => BackClicked();
        }

        internal void SetData(CategoryModel category)
        {
            foreach(var good in category.Goods)
            {
                var button = new Button();
                button.Content = $"{good.Name} : {good.Price}";
                ItemsHolder.Children.Add(button);
            }

            TitleTxt.Content = category.Name;
        }
    }
}
