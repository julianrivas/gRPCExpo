namespace Common.MassTransit.Contracts.Items;

public interface IMqGetItemsResponse
{
    IEnumerable<IMqItem> Items { get; }
}