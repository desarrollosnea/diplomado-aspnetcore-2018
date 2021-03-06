
CREATE PROCEDURE [partido].[Partido_Buscar]
	@PalabrasABuscar VARCHAR(4000) = NULL,
	@FaseId INT = NULL,
	@TorneoId INT = NULL,
	@TemporadaId INT = NULL
AS
BEGIN
	SELECT 
	PartidoCompletoId = P.PartidoId, 
		P.Fecha,
		Local = Local.Nombre,
		Visitante = Visitante.Nombre,
		Fase = F.Nombre,
		Torneo = T.Nombre,
		Temporada = Temp.Nombre,
		GolesLocal = LocalIndicadores.Goles,
		GolesVisitante = VisitanteIndicadores.Goles,
		TarjetaAmarillaLocal = LocalIndicadores.TarjetaAmarilla,
		TarjetaAmarillaVisitante = VisitanteIndicadores.TarjetaAmarilla,
		TarjetaRojaLocal = LocalIndicadores.TarjetaRoja,
		TarjetaRojaVisitante = VisitanteIndicadores.TarjetaRoja
	FROM partido.Partido P
		INNER JOIN equipo.Equipo Local
			ON P.EquipoIdLocal = Local.EquipoId
		INNER JOIN equipo.Equipo Visitante
			ON P.EquipoIdVisitante = Visitante.EquipoId
		INNER JOIN torneo.Fase F
			ON P.FaseId = F.FaseId
		INNER JOIN torneo.Torneo T
			ON F.TorneoId = T.TorneoId
		INNER JOIN torneo.Temporada Temp
			ON T.TemporadaId = Temp.TemporadaId
		CROSS APPLY [dbo].[PartidoEquipoEventosIndicador](P.PartidoId, P.EquipoIdLocal) LocalIndicadores
		CROSS APPLY [dbo].[PartidoEquipoEventosIndicador](P.PartidoId, P.EquipoIdVisitante) VisitanteIndicadores

	
END