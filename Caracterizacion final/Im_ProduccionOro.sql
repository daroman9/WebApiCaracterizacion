
    
CREATE PROCEDURE dw.IM_ProduccionOro 
AS    

DECLARE
@consulta AS NVARCHAR(4000)
, @idPlantilla INT
, @condicion VARCHAR(4000)

BEGIN
	SET @idPlantilla = 4

	SET @consulta = 'SELECT ' + CHAR(10)
							  + 'nombre_zona, '
							  + CHAR(10)
							  + 'tipo_grafica, '
							  + CHAR(10)
							  + 'dato, '
							  + CHAR(10)
							  + 'cantidad '
							  + CHAR(10)
							  + CHAR(10)
							  + 'FROM '
							  + CHAR(10)
							  + 'dw.vProduccionOroBarequero '
							  + CHAR(10)
							  + CHAR(10)
							  + 'ORDER BY '
							  + CHAR(10)
							  + 'nombre_zona, '
							  + CHAR(10)
							  + 'orden, '
							  + CHAR(10)
							  + 'dato'

	EXEC sp_executesql @consulta
END


