# Sistema de Gestión de Inventario

*Tema asignado (Grupo 1):* Relación uno a muchos entre 
*Categoría* (entidad principal) 
*Producto* (entidad dependiente).

## Integrantes y aportes

| Integrante | Aporte |
|---|---|
| Anthony Damian Aguilar Oyana | Creación del proyecto ASP.NET Core MVC, configuración de SQL Server, modelo Producto, CRUD inicial y migración `InitialCreate`. |
| Sheyla Daniela Bernal Correa | Validaciones de Producto con DataAnnotations, mensajes de error en español y migración `ValidacionesProducto`. |
| María José Haro Velasco | Entidad Categoría y su CRUD, relación uno a muchos, clave foránea y migración `AgregarCategoria`. |
| Diego David Baque Quishpe | Regeneración y corrección del CRUD de Producto: lista desplegable de categorías y nombre de la categoría en las vistas (componente autónomo). |

## Modelo de datos

**Categoria** (principal): `Id`, `Nombre` (obligatorio, máx. 100), `Descripcion` (opcional, máx. 250), `Productos` (colección de navegación).

**Producto** (dependiente): `Id`, `Nombre` (obligatorio, máx. 100), `Descripcion` (opcional, máx. 250), `Precio` (decimal(10,2)), `Stock` (0 a 10000), `CategoriaId` (FK hacia Categoria), `Categoria` (navegación).

## Pasos para ejecutar el proyecto

1. Clonar el repositorio:
git clone https://github.com/Sh4d0wM/SistemaGestionInventario.git

2. Abrir `SistemaGestionInventario.slnx` en Visual Studio.
   
3. Verificar la cadena de conexión en `appsettings.json`:
   ```json
   "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=InventarioDB;Trusted_Connection=True;TrustServerCertificate=True;"
   ```
4. En la **Consola del Administrador de paquetes** ejecutar:
Update-Database
Esto crea la base de datos `InventarioDB` con las tablas `Categoria` y `Productos`.

5. Ejecutar con **F5**. Desde el menú principal se accede a **Productos** y **Categorías**.
