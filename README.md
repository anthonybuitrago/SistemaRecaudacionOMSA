# SistemaRecaudacionOMSA
🚍 Sistema de Gestión de Recaudación OMSA
Este proyecto es una solución integral para la gestión operativa y financiera de la Oficina Metropolitana de Servicios de Autobuses (OMSA). Desarrollado en C# con una arquitectura de 3 Capas, el sistema permite administrar rutas, conductores, vehículos y la venta de tickets de forma eficiente y segura.

👥 Integrantes del Grupo
Anthony

Elvis

Eduardo

🚀 Requisitos del Sistema
Para ejecutar este proyecto, necesitas tener instalado:

Visual Studio 2022 o superior.

SQL Server (Express o LocalDB).

.NET Framework 4.7.2 o superior.

🛠️ Configuración e Instalación
1. Preparación de la Base de Datos
Abre SQL Server Management Studio (SSMS).

Abre el archivo Script_Maestro.sql incluido en este repositorio.

Ejecuta el script completo. Esto creará la base de datos OMSA_Recaudacion, las tablas, las relaciones y cargará los datos de prueba (Seed Data).

2. Configuración del Proyecto en Visual Studio
Abre el archivo de solución .sln.

Dirígete al archivo App.config en el proyecto de la Capa de Presentación.

Asegúrate de que la cadena de conexión coincida con tu instancia local de SQL Server:

XML
<connectionStrings>
  <add name="ConexionOMSA" connectionString="Data Source=TU_SERVIDOR;Initial Catalog=OMSA_Recaudacion;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
📖 Guía de Uso
🔐 Acceso al Sistema (Login)
Usuario: admin

Contraseña: Admin123
(Nota: El campo de contraseña está protegido y no es legible por seguridad).

🖥️ Navegación Principal
Al ingresar, verás el Formulario Principal con un Menú de navegación organizado en 5 secciones:

Entrada: Acceso a los formularios CRUD para agregar datos:

Choferes: Registro de conductores con validación de cédula.

Rutas: Gestión de trayectos, tarifas y distancias.

Vehículos: Registro de unidades por ficha y placa.

Consulta: Visualización de datos guardados:

Viajes: Programación de rutas asignadas a choferes y buses.

Tickets: Registro de ventas de pasajes.

Dashboard: Panel visual con métricas en tiempo real (Recaudación total, tickets vendidos, etc.).

Reportes: Consultas avanzadas que cruzan información de choferes, rutas y recaudación.

Sistema: Sección "Acerca de" con la información de los desarrolladores.

📝 Cómo realizar un registro (CRUD)
Selecciona una opción de Entrada (ej. Choferes).

El formulario abrirá deshabilitado por defecto.

Haz clic en el botón "Editar" o "Nuevo" para habilitar los campos.

Completa la información y haz clic en "Guardar".

🏗️ Detalles Técnicos y Arquitectura
El sistema se construyó siguiendo los estándares más exigentes de la programación moderna:

Arquitectura N-Capas: Separación total de responsabilidades (Presentación, Negocio, Datos).

Programación Orientada a Objetos (POO):

Herencia: Clases derivadas de una clase base Persona.

Abstracción: Uso de clases y métodos abstractos para definir comportamientos obligatorios.

Polimorfismo: Sobrescritura de métodos (override) para adaptar funciones según la entidad.

Interfaces: Implementación de ICrud para estandarizar el acceso a datos.

Asincronía: Uso de Task, async y await para garantizar que la interfaz de usuario nunca se bloquee durante consultas pesadas a la base de datos.

Seguridad SQL: Uso de comandos parametrizados para prevenir ataques de Inyección SQL.

Procedimientos Almacenados: Optimización de lógica compleja directamente en el motor de base de datos.

📂 Estructura de Carpetas
CapaPresentación: Formularios de Windows, recursos visuales e iconos.

CapaNegocio: Lógica de validación, entidades y modelos de dominio.

CapaDatos: Clases de conexión a SQL, interfaces y métodos de persistencia.

BaseDeDatos: Script SQL maestro para recrear el entorno.
