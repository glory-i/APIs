namespace ProductsApi.DTOS
{
    public class CreateProductDto
    {
        //since we are updating only product name and price, we h=will have only those 2 attributes

        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}