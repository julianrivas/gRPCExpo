﻿using gRPC.Expo.Preformance.Messages.cs.mqContracts;

namespace Benchmark.Models;

public record MqItem(
    string Id,
    string Descripcion,
    decimal Factor,
    bool FueraDeNomina,
    bool RequiereFondo,
    decimal Orden,
    bool AgruparEnLiquidacion,
    DateTime FechaRegistro,
    string IdUsuarioRegistro,
    bool Activo,
    bool GeneraCuentaPorPagar) 
    : IMqItem;