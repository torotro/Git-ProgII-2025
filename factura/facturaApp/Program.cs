// See https://aka.ms/new-console-template for more information
using facturaApp.domain;
using facturaApp.services;

productServices o = new productServices();

Console.WriteLine("obtener  los articulos - getall");

List<Product> lp = o.GetProducts();

if (lp.Count > 0)
{
    foreach(Product p in lp)
    {
        Console.WriteLine(p);
    }
    
}
else 
{
    Console.WriteLine("no hay articulos");
      
}

Console.WriteLine("obtener articulos por id - getbyid");
Product? p5 = o.GetProduct(5);


if(p5 != null)
{
    Console.WriteLine(p5);
}
else
{
    Console.WriteLine("no existe ese articulo");
}

Billservices ob= new Billservices();

Console.WriteLine("guardar factura -save");


   

