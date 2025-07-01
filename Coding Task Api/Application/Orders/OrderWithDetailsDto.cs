namespace Coding_Task_Api.Application.Orders
{
    // Represents a single item within a detailed order view
    public record OrderItemDetailDto(
        Guid ProductId,
        string ProductName,
        int Quantity,
        decimal Price);

    // Represents the full, detailed order for display
    public record OrderWithDetailsDto(
        Guid Id,
        DateTime OrderDate,
        decimal TotalPrice,
        List<OrderItemDetailDto> Items);
}
