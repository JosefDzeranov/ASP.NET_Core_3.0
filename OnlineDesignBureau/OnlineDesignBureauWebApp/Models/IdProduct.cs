using System.Collections.Generic;


namespace OnlineDesignBureauWebApp.Models
{
    public static class IdProduct
    {
        public static int GiveMeId() // запрашиваем свободный минимальный id
        {
            List<int> id_list = ProductCatalog.IdProducts;
            id_list.Sort();
            int id_temp = 0;
            for (int i = 0; i < id_list.Count; i++)
            {
                if (i != id_list[i]) id_temp = i;
                if (i == id_list.Count - 1) id_temp = i+1;
            }
            return id_temp;
        }
        public static void ReadIdInCatalog(List<Product> catalogProducts) //считываем все id из каталога
        {
            foreach (var product in catalogProducts)
            {
                ProductCatalog.IdProducts.Add(product.Id);
            }
        }
    }
}
