using gRPC.Expo.Preformance.Messages.cs.mqContracts;

namespace gRPCExpo.Performance.Client.Models;

public record MqGetItemsResponse(IEnumerable<IMqItem> Items) : IMqGetItemsResponse;