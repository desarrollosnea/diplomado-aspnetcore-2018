CREATE PROCEDURE [equipo].[Equipo_Eliminar](
	@EquipoId INT

)
AS
BEGIN
	DECLARE @Exito INT = 0,
			@Mensaje VARCHAR(1000)

	BEGIN TRY

		BEGIN TRANSACTION
			DELETE [equipo].[EquipoInfo]
			WHERE EquipoId = @EquipoId

			DELETE [equipo].[Equipo]
			WHERE EquipoId = @EquipoId

		COMMIT TRANSACTION

		SET @Exito = 1
		SET @Mensaje = 'Se eliminó el equipo correctamente'

	END TRY
	BEGIN CATCH

		SET @Exito = 0
		SET @Mensaje = ERROR_MESSAGE()

		IF (XACT_STATE()) = -1
		BEGIN
			ROLLBACK TRANSACTION
		END
		

		IF (XACT_STATE()) = 1
		BEGIN
			COMMIT TRANSACTION
		END

		--EXEC auditoria.Log_ElmahError @ObjectID = @@PROCID;


	END CATCH;

	--SELECT Exito = @Exito,
	--	   Mensaje = @Mensaje
END
GO
/*
--------------------------------------------------------------------------------------
-- TEST
-------------------------------------------------------------------------------------

EXEC [equipo].[Equipo_Eliminar]	@EquipoId = 16



-------------------------------------------------------------------------------------
*/