using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public float GetShippingCost()
    {
        return _customer.LivesInUSA() ? 5 : 35;
    }

    public float GetTotalCost()
    {
        float productTotal = 0;

        foreach (Product p in _products)
        {
            productTotal += p.GetTotalCost();
        }

        return productTotal + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        string result = "PACKING LABEL:\n";

        foreach (Product p in _products)
        {
            result += $"{p.GetName()} - ID: {p.GetProductId()}\n";
        }

        return result;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }

    public bool IsUSA()
    {
        return _customer.LivesInUSA();
    }
}
