A library make .NET Core programs be able to call WCF server without proxy classes.

## Finally
    static void Main(string[] args)
    {
        //Init Container
        IContainer container = InitContainer();//This is a remote interface

        //Calling WCF
        IProductService productService = container.Resolve<IProductService>();
        string products = productService.GetProducts();

        Console.WriteLine(products);

        container.Dispose();
        Console.ReadKey();
    }
