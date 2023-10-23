# Proyecto .NET Core en Mac

Este proyecto fue creado utilizando .NET Core con scaffolding en macOS. A continuación, se describe el proceso paso a paso y las herramientas necesarias para establecer el proyecto.

## 💻 Frameworks Utilizados

- Microsoft.AspNetCore.App
- Microsoft.NETCore.App

## 📦 Paquetes NuGet

- Microsoft.Entity.FrameworkCore
- Microsoft.Entity.FrameworkCore.Design
- Pomelo.Entity.FrameworkCore.MySql
- Microsoft.Entity.FrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design

## 🚀 Crear un Proyecto en Mac para .NET Core

1. **Instalación de Dependencias**: 

   Instalar los paquetes NuGet listados anteriormente.

2. **Preparación de la Base de Datos**:

   Crear la base de datos requerida para el proyecto. Para este proyecto, se utilizó MySQL versión 8.0.33.

3. **Compilar el Proyecto**:

   Ejecutar el comando de Build en Visual Studio.

4. **Generación del DbContext**:

   Ejecutar el siguiente comando en la terminal de Visual Studio (recuerda adaptar los parámetros de conexión a tu configuración local):

   ```bash
   dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=PHP.Laravel;port=3307;Database=AdminTours" "Pomelo.EntityFrameworkCore.MySql"
   
5. **Organización de Entidades**:

  Crear una carpeta llamada "Entities" y mover allí todos los archivos de entidades generados por el scaffolding.

6. **Configuración de DbContext en Program.cs**:

  Agregar el siguiente código en Program.cs para configurar el DbContext:

   ```bash
  builder.Services.AddDbContext<AdminToursContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33))));
   ```
  
7. **Generación de Controladores y Vistas**:

En la carpeta "Controllers", realizar un scaffolding del controlador y de las vistas que se deseen crear. En Visual Studio, selecciona "Add -> [New Scaffolding]" y elige la opción "MVC Controller con Views usando Entity Framework".

## 🤝 **Contribuciones** 

Las contribuciones son **bienvenidas**. Para problemas o sugerencias, por favor abre un _issue_ o realiza un _pull request_.

## 📄 **Licencia** 

Este proyecto está licenciado bajo MIT. Consulta el archivo [LICENSE.md](LICENSE.md) para obtener más detalles.
