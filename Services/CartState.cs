namespace Blazor_cart_demo.Services;

public class CartState
{
    public int TotalItems { get; private set; }

    public event Action? OnChange;

    public void AddProduct()
    {
        TotalItems++;
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
