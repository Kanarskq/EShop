namespace EShop.Api.Common;

public record CreatedResponse<T>
{
    public T Id { get; init; }
}
