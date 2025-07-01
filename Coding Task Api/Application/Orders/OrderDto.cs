namespace Coding_Task_Api.Application.Orders
{
    public record OrderDto(Guid Id, DateTime OrderDate, decimal TotalPrice, int ItemCount);

}
