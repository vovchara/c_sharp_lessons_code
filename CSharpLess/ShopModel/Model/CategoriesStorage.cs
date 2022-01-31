namespace ShopModel.Model
{
    public class CategoriesStorage
    {
        private static CategoriesStorage _instance;

        public static CategoriesStorage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CategoriesStorage();
            }
            return _instance;
        }
        private CategoriesStorage()
        {
        }

        public CategoryModel[] Categories { get; internal set; }
    }
}
