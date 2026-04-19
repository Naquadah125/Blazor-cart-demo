# Blazor Cart Demo

Minimal Blazor WebAssembly demo for component-based cart management.

## Component structure (Part 2.3)

- Main Layout: global shell, nav menu, cart item counter.
- Product List: parent component, receives product data and renders grid.
- Product Card: child component, renders image, price, and add-to-cart action.

## Quick run

```powershell
dotnet run
```

Open URL shown in terminal.

## Screenshot checklist

1. Before click: header shows `Cart items: 0`.
2. Click any `Add to cart` button once.
3. After click: header shows `Cart items: 1` without full page reload.

## Scope note

This is demo-only implementation for UI/state flow. It does not include quantity decrement, total amount calculation, or persistent storage.