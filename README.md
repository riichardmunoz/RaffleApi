# Introduction 
El objetivo principal de este proyecto es desarrollar una API robusta que aborde los retos a los que se enfrentan varios clientes a la hora de asignar números únicos de 5 dígitos a los usuarios que participan en sistemas de lotería. Actualmente, los clientes se integran con una API gratuita que asigna números dentro de un rango común (00001 a 99999), pero este sistema carece de la capacidad de garantizar la unicidad por cliente. Esta limitación provoca posibles conflictos cuando varios clientes operan simultáneamente, poniendo en peligro la integridad de sus sistemas de lotería.

Para hacer frente a este problema, la API está diseñada para asignar números únicos de 5 dígitos específicos para cada cliente, lo que permite la participación fluida de los usuarios en diversas aplicaciones basadas en la lotería, como sistemas de bingo, sistemas de punto de venta, soluciones ERP y plataformas de comercio electrónico. La solución se adhiere a los principios de diseño SOLID y Arquitectura Limpia, garantizando la escalabilidad y la facilidad de mantenimiento.

Mediante la aplicación de una arquitectura en forma de cebolla (o arquitectura hexagonal), el proyecto separa eficazmente las preocupaciones, lo que permite establecer límites claros entre las distintas capas de la aplicación. Esta estructura mejora la capacidad de prueba y promueve una base de código más limpia. La API está protegida con una clave de autenticación y bien documentada mediante Swagger, lo que facilita su integración y uso por parte de los clientes.

Además de la API backend desarrollada en .NET 8 con C#, utilizando ADO.NET (Dapper) para la gestión de productos y Entity Framework para la asignación de números, se ha desarrollado una interfaz front-end fácil de usar utilizando Angular. Esta interfaz permite a los clientes gestionar sus productos y números asignados sin esfuerzo.

El proyecto también hace hincapié en el aseguramiento de la calidad, incorporando pruebas unitarias para asegurar una cobertura mínima del 80%, garantizando así la fiabilidad y robustez de las funcionalidades implementadas. En general, esta API tiene como objetivo proporcionar una solución fiable y eficiente para los clientes, mejorando sus capacidades operativas en la gestión de sistemas de lotería, al tiempo que se adhiere a las mejores prácticas en el desarrollo de software.

# Getting Started
1.	Clonar el repositorio "RaffleApi" del boton "Clone" y la url HTTPS.
2.	Una vez clonado localmente, ya se puede correr el proyecto.
3.	El proyecto iniciará con Swagger y se visualizarán 2 enpoints.

# Migrate database
El proyecto implementa Code First para el contexto que maneja de BD, además se implementó un AutoMigrate para migrar una vez se haga Debug, se debe tener en cuenta lo siguiente:

1. La cadena de conexión esta establecida para que tome el servidor local (Server=.) si se desea cambiar, por favor ajuste el arhcivo appsettings.json de la capa Api por el servidor local que usted decida.
2. Una vez configurada la cadena de conexión, solo queda correr el proyecto (Establecer la capa Api como proyecto de inicio) y la BD se ha migrado al servidor de SQL Server.
3. La base de datos se llama dbRaffle y ya contiene unas semillas para iniciar las pruebas. (Semillas en Product, Client y User).

# JWT ApiKey
1. El ApiKey es "Bearer JwtRaffle", con esto puede realizar pruebas en Swagger.
