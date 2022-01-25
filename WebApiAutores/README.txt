## 24 - Data Relacionada -Segundo Controlador

El error sería: System.Text.Json.JsonException: se detectó un posible ciclo de objeto.
Esto puede deberse a un ciclo o si la profundidad del objeto es mayor que la profundidad
máxima permitida de 32. Considere usar ReferenceHandler.Preserve en JsonSerializerOptions
para admitir ciclos.

Tienes al menos 2 opciones:

Evitar las referencias circulares
Ignorar las referencias circulares

ASP.NET Core 6+

services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

ASP.NET Core 5

services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);