namespace gRPC.Expo.Preformance.Messages.cs.mqContracts;

public interface IMqGetItemsResponse
{
    IEnumerable<IMqItem> Items { get; }
}