using Shop.Models;

namespace Shop.Helpers
{
    public static class CartHelper
    {
        private static List<CartItem> _cartItems = new();

        public static List<CartItem> GetCartItems()
        {
            return _cartItems.ToList();
        }

        public static void AddToCart(Product product, int quantity = 1)
        {
            var existingItem = _cartItems.FirstOrDefault(c => c.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public static void RemoveFromCart(int productId)
        {
            var item = _cartItems.FirstOrDefault(c => c.Product.Id == productId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        public static void UpdateQuantity(int productId, int quantity)
        {
            var item = _cartItems.FirstOrDefault(c => c.Product.Id == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    _cartItems.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
            }
        }

        public static void ClearCart()
        {
            _cartItems.Clear();
        }

        public static int GetCartItemsCount()
        {
            return _cartItems.Sum(c => c.Quantity);
        }

        public static decimal GetCartTotal()
        {
            return _cartItems.Sum(c => c.Product.Price * c.Quantity);
        }

        public static bool IsProductInCart(int productId)
        {
            return _cartItems.Any(c => c.Product.Id == productId);
        }

        public static CartItem? GetCartItem(int productId)
        {
            return _cartItems.FirstOrDefault(c => c.Product.Id == productId);
        }
    }
}
