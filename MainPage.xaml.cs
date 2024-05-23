namespace MAUIReflectionTask
{
    class Product
    {
        private static int Products = 0;

        private int ID { get; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public Product()
        {
            this.Name = "";
            this.Price = 0.0f;
            this.ID = Products++;
            this.Description = "";
        }
    }

    public partial class MainPage : ContentPage
    {
        List<Product> products = new List<Product>();
        public MainPage()
        {
            InitializeComponent();

            // Store the type of product class
            Type productType = ___;

            // Get all the properties of the Product class
            ___ properties = ___;

            // Loop through all the properties
            foreach (___ property in ___)
            {
                Entry entryBox = new Entry();
                entryBox.Placeholder = property.Name;
                fields.Children.Add(entryBox);
            }

            createBtn.Clicked += CreateProduct;
        }

        void CreateProduct(object? sender, EventArgs e)
        {
            try
            {
                Product product = new Product();

                // Store the type of product class
                Type productType = ___;

                foreach (Entry entryBox in fields.Children)
                {
                    // The the property reference from the Product class, which has the same name as 'entryBox.Placeholder'.
                    // The excalamation mark ensures the compiler that the retrieved reference is not going to be null. 
                    // It is to suppress the warning.
                    PropertyInfo property = ___!;

                    object value = Convert.ChangeType(entryBox.Text, property.PropertyType);
                    property.SetValue(product, value);
                }

                products.Add(product);
            }
            catch
            {
                infoLabel.Text = $"ERROR: Invalid value in one of the fields.";
                return;
            }

            infoLabel.Text = $"Product {products.Count} created successfully.";

            ClearEntryBoxes();
            UpdateProductsList();
        }

        void UpdateProductsList()
        {
            productsList.Children.Clear();

            // Store the type of Product class
            Type productType = ___;

            foreach (Product product in products)
            {
                Label dataLabel = new Label();

                // Retrieve all the properties of productType
                ___ properties = ___;

                // Loop through all the properies
                foreach (___ property in ___)
                {
                    // Get the value of 'property' from the 'product' object.
                    // The exclamation mark is to supresses the compiler warning since we know that the property exists,
                    // and it cannot return null.
                    object value = ___!;

                    dataLabel.Text += $"{property.Name}: {value.ToString()}\t";
                    PropertyInfo property;
                }

                productsList.Children.Add(dataLabel);
            }
        }

        void ClearEntryBoxes()
        {
            foreach (Entry entryBox in fields.Children)
            {
                entryBox.Text = "";
            }
        }
    }
}