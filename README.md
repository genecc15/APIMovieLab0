# APIMovieLab0
Esta API cuenta con 
Agregar, Visualizar, Eliminar y Modificar.
El método Eliminar, elimina TODOS los campos de la película específica, más no el resto de películas ya agregadas.
Para poder agregar películas a la API deberá seguir el siguiente formato Json:
 "Id": " ",
 "Nombre": " ",
 "Anio": " ",
 "Director": " "
 Ejemplo:
"Id": "2368",
"Nombre": "Frozen",
"Anio": "2003",
"Director": "Jennifer Lee"

Para poder ver las películas ya agregadas se usa la dirección:  [Route("api/[controller]")].
Para poder agregar películas:  [Route("api/[controller]")].
Para modificar algun campo de una película:  [Route("api/[controller]/id")].
Para eliminar alguna película:  [Route("api/[controller]/id")].
