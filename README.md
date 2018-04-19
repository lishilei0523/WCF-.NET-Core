A library makes .NET Core programs be able to call WCF server without proxy classes.

## Finally
    static void Main(string[] args)
    {
        //Init Container
        IContainer container = InitContainer();

        //Calling WCF
        IProductService productService = container.Resolve<IProductService>();//This is a remote interface
        string products = productService.GetProducts();

        Console.WriteLine(products);

        container.Dispose();
        Console.ReadKey();
    }
