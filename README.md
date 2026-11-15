# Sistema de Gestión de Inventario

**Tema asignado (Grupo 1):** Relación uno a muchos entre 
**Categoría** (entidad principal) 
**Producto** (entidad dependiente).

**Materia:** Desarrollo web para la integración de tecnologías · **NRC:** 36754 · **Universidad de las Fuerzas Armadas ESPE**

Aplicación web desarrollada con **ASP.NET Core MVC (.NET 10)**, **Entity Framework Core** y **SQL Server Express**. Implementa dos CRUD completos, validaciones con DataAnnotations en español y una relación uno a muchos: una categoría tiene muchos productos y cada producto pertenece a una sola categoría.

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

## Migraciones

1. `InitialCreate`: creación inicial de la tabla Productos.
2. `ValidacionesProducto`: restricciones de longitud y tipos de datos.
3. `AgregarCategoria`: tabla Categoria y clave foránea `CategoriaId` en Productos.

## Componente autónomo

En el formulario de Producto, la categoría se elige desde una **lista desplegable** (por nombre) en lugar de escribir el número, y se eliminó el campo duplicado de la propiedad de navegación. El listado y el detalle muestran el nombre de la categoría. La lista se vuelve a cargar cuando hay errores de validación.

Archivos modificados: `Controllers/ProductosController.cs` y `Views/Productos/` (`Create`, `Edit`, `Index`, `Details`).

## Requisitos

- Visual Studio 2026 Community
- .NET 10 SDK
- SQL Server 2025 Express (instancia `localhost\SQLEXPRESS`)
- SQL Server Management Studio (SSMS) 22

## Pasos para ejecutar el proyecto

1. Clonar el repositorio:
