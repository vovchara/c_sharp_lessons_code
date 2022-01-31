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
        public event Action<int> CategoryClicked = delegate { };

        public HomePage()
        {
            InitializeComponent();
        }

        public void SetUser(string nickName)
        {
            var titleTemplate = TitleTxt.Content.ToString();
            var modifiedTitle = titleTemplate.Replace("[user]", nickName);
            TitleTxt.Content = modifiedTitle;
        }

        public void SetCategories(CategoryModel[] categories)
        {
            foreach(var cat in categories)
            {
                var button = new Button();
                button.Content = cat.Name;
                button.Click += (s, e) => CategoryClicked(cat.Id);
                CategoryHolder.Children.Add(button);
            }
        }
    }
}
