using Blazor_cart_demo.Models;

namespace Blazor_cart_demo.Services;

public class CartState
{
    private readonly Dictionary<int, CartItem> _items = new();

    public event Action? OnChange;

    public IReadOnlyList<CartItem> Items => _items.Values.OrderBy(item => item.ProductId).ToList();

    public int TotalItems => _items.Values.Sum(item => item.Quantity);

    public decimal TotalAmount => _items.Values.Sum(item => item.Subtotal);

    public bool IsEmpty => _items.Count == 0;

    public void AddProduct(Product product)
    {
        if (_items.TryGetValue(product.Id, out var existingItem))
        {
            existingItem.Quantity++;
        }
        else
        {
            _items[product.Id] = new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Quantity = 1,
                ImageUrl = product.ImageUrl
            };
        }

        NotifyStateChanged();
    }

    public void IncreaseQuantity(int productId)
    {
        if (!_items.TryGetValue(productId, out var item))
        {
            return;
        }

        item.Quantity++;
        NotifyStateChanged();
    }

    public void DecreaseQuantity(int productId)
    {
        if (!_items.TryGetValue(productId, out var item))
        {
            return;
        }

        item.Quantity--;

        if (item.Quantity <= 0)
        {
            _items.Remove(productId);
        }

        NotifyStateChanged();
    }

    public void RemoveProduct(int productId)
    {
        if (_items.Remove(productId))
        {
            NotifyStateChanged();
        }
    }

    public void Clear()
    {
        if (_items.Count == 0)
        {
            return;
        }

        _items.Clear();
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
