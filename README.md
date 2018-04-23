A library makes .NET Core programs be able to call WCF server without proxy classes.

## Finally
    static void Main(string[] args)
    {
        //Init Container
        IServiceProvider serviceProvider = InitServiceProvider();
		
		//Calling WCF
        using (IServiceScope serviceScope = serviceProvider.CreateScope())
        {
            IProductService productService = serviceScope.ServiceProvider.GetService<IProductService>();//This is a remote interface
            string products = productService.GetProducts();
            Console.WriteLine(products);
        }
        
        Console.ReadKey();
    }
