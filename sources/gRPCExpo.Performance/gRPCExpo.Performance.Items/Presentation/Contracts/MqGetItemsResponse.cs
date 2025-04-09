using gRPC.Expo.Preformance.Messages.cs.mqContracts;

namespace gRPCExpo.Performance.Items.Presentation.Contracts;

public record MqGetItemsResponse(IEnumerable<IMqItem> Items) : IMqGetItemsResponse;