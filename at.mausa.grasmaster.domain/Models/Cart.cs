using System.Collections.Generic;

namespace At.Mausa.Grasmaster.Domain.Models {
    public class Cart : Entity {
        public Cart(Guid? guid) : base(guid) {
            products = new List<Product>();
        }

        public virtual User User { get; set; }
        public ulong UserId { get; set; }
        public IReadOnlyList<Product> Products => products as IReadOnlyList<Product>;

        private readonly List<Product> products;

        public Product AddProductToCart(Product product) {

            if(product == null)
                throw new ArgumentNullException("Product cant be NULL");

            products.Add(product);
            return product;
        }

    }
}