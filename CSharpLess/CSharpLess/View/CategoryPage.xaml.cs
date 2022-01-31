using ShopModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpLess.View
{
    /// <summary>
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public event Action<GoodsItemModel> AddGoodClicked = delegate { };
        public event Action BackClicked = delegate { };

        public CategoryPage()
        {
            InitializeComponent();
            BackBtn.Click += (s, e) => BackClicked();
        }

        public void SetData(CategoryModel model)
        {
            TitleTxt.Content = model.Name;

            foreach (var good in model.Goods)
            {
                var btn = new Button();
                btn.Content = $"{good.Name} : {good.Price} UAH";
                btn.Click += (s, e) => AddGoodClicked(good);
                ItemsHolder.Children.Add(btn);
            }
        }
    }
}
