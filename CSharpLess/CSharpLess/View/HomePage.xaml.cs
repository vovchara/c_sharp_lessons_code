using ShopModel.Model;
using System;
using System.Windows.Controls;

namespace CSharpLess.View
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public Action<int> CategorySelected = delegate { };

        public HomePage()
        {
            InitializeComponent();
        }

        public void SetUserName(string name)
        {
            var txt = TitleTxt.Content.ToString();
            TitleTxt.Content = txt.Replace("[user]", name);
        }

        public void SetCategories(CategoryModel[] categories)
        {
            foreach (var cat in categories)
            {
                var btn = new Button();
                btn.Content = cat.Name;
                btn.Click += (s, e) => CategorySelected(cat.Id);
                CategoryHolder.Children.Add(btn);
            }
        }
    }
}
