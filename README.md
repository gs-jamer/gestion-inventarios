# gestion-inventarios
1. Título del proyecto
------------------------------------------------------------------------------

Prueba de nivel Web para Goal.
Se trata de un proyecto de gestión de inventarios cuyas funcionalidades principales son añadir y quitar elementos de dicho inventario.


2. Comenzando
------------------------------------------------------------------------------
Para descargar el proyecto hay que ir a https://github.com/gs-jamer/gestion-inventarios y clonarlo en el directorio local.


3. Pre-requisitos
------------------------------------------------------------------------------
Tener instalado Visual Studio 2015 o superior y ISS Express o algún servidor donde compilarlo.


4. Instalación
------------------------------------------------------------------------------
Para abrir el proyecto y ver el código, basta abrir la solución "Prueba Web.sln" y el proyecto se abrirá en Visual Studio, listo para compilar y ejecutar mediante ISS Express.


5. Desarrollo
------------------------------------------------------------------------------
El desarrollo de esta aplicación web se ha hecho a través de Visual Studio 2017, creando un proyecto de ASP.NET MVC 5 usando el lenguaje de programación C#.
La implementación del Controlador y de los Modelos se han hecho utilizando C#.
La implementación de las vistas se ha hecho usando HTML y C# con sintaxis Razor y Materialize CSS para dar un aspecto visual más cómodo.


6. Wiki
------------------------------------------------------------------------------
A continuación, una breve descripción sobre diseño, estructura del código y algún razonamiento.


6.1 Diseño
------------------------------------------------------------------------------
El diseño es bastante simple, para lo que se pide, consta de:

· Tres vistas:
	· Un índice con los datos del inventario en forma de tabla.
	· Un formulario para añadir un elemento.
	· Un formulario para borrar un elemento.
· Un único Controlador, que realiza las operaciones básicas de la aplicación.
· Un Modelo con los datos del Elemento de un inventario {Nombre, Tipo, F.Cad.}
· Un Modelo para cada vista de la Aplicación para la transferencia de datos entre las vistas y el controlador.
· Una clase Inventario como capa de Integración con los datos del Inventario.


6.2 Estructura del código
------------------------------------------------------------------------------
La estructura es bastante simple, en general, es la generada por defecto y automáticamente por Visual Studio al crear el proyecto.

· App_Data: Carpeta vacía.
· App_Start: Configuraciones.
· Content: Con un solo elemento, Site.css con los estilos propios para la web.
· Controllers: Con el controlador, InventarioController.cs
· fonts: Con las fuentes, pero que no uso.
· img: Con la imagen del logo que aparece en la barra de navegación.
· Integration: Con la clase Inventario.cs con los datos del inventario.
· Models: Con un solo modelo, los datos de cada Elemento del inventario se definen en la clase InventarioElem.cs.
· Scripts: Con los scripts de la web en Javascript.
· Test: Con las pruebas unitarias del proyecto.
· ViewModels: Modelos de cada una de las vistas para facilitar la transferencia de datos entre el Controlador y las Vistas.
· Views: Con las Vistas.


6.3. Estructura de datos
------------------------------------------------------------------------------
Los datos de los elementos del inventario se almacenan en memoria y, por comodidad, se encuentran en un TreeMap/Diccionario_Ordenado para que se visualicen los elementos en el Índice de forma ordenada por nombre, que es la clave, e implementado como un Singleton, ya que solo me interesa una única instancia de la estructura de datos.


6.4. Desarrollo de los requisitos
------------------------------------------------------------------------------
Para cada uno de los requisitos, he implementado su Vista, Modelo de Vista y Operación en el Controlador. 


6.4.1. Añadir un elemento al inventario
------------------------------------------------------------------------------
Para añadir un elemento, he diseñado un formulario muy simple con cada uno de los atributos que componen el elemento y que viajan al controlador a través del modelo de la vista (o modelo del formulario). En el controlador, si no existe el elemento, lo inserta y, si existe, no lo actualiza.


6.4.2. Sacar un elemento del inventario
------------------------------------------------------------------------------
Para sacar un elemento, el procedimiento no es tan simple. Primero, se debe elegir el elemento que queremos borrar a través de un ComboBox, que al fin y al cabo se trata de un formulario de tipo GET cuya acción en el controlador, devuelve los datos del elemento seleccionado para proporcionar más información al usuario y habilitando el botón de borrar elemento. El borrado del elemento se realiza a través de una acción del controlador donde se le pasa como parámetro su nombre.


6.4.3. Notificar que un elemento se ha sacado del inventario
------------------------------------------------------------------------------
No tiene nada del otro mundo, cuando se saca un elemento del inventario, la acción del controlador de borrar elemento redirige al índice y, además, se abre una ventana de diálogo (modal) indicando que el elemento X se ha borrado.


6.4.4. Notificar cuando un elemento caduca
------------------------------------------------------------------------------
Para las notificaciones, he implementado un Sidebar (aunque en la vida real no se use para hacer este tipo de cosas) con un listado de los elementos que han caducado. Por tanto, el usuario tiene siempre visible el botón de notificaciones en la barra de navegación y ver si tras insertar, borrar o simplemente entrar a ver el índice, existen elementos caducados o no.


6.5. Versión móvil
------------------------------------------------------------------------------
Gracias a las teconologías responsive de la librería CSS de Materialize, el proyecto también es visible como aplicación móvil.
