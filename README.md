# Caronte

## 1. Descripción del Proyecto
Caronte es una aplicación de escritorio desarrollada para automatizar la gestión y el envío de notificaciones por correo electrónico a las Entidades Promotoras de Salud (EPS). El sistema se encarga de obtener datos de pacientes de forma periódica desde un servicio web, procesarlos, listarlos en una interfaz gráfica y enviar correos electrónicos de notificación consolidados sobre los ingresos de los pacientes a las distintas EPS. Adicionalmente, cuenta con compresión de datos y un sistema para el registro de eventos.

## 2. Pila Tecnológica (Tech Stack)
* **Lenguaje:** VB.NET (Visual Basic .NET)
* **Framework:** .NET Framework 4.5
* **Interfaz de Usuario:** Windows Forms (WinForms)
* **Integración y Servicios:** WCF (Windows Communication Foundation) para el consumo del servicio `wsCaronte`
* **Protocolos:** SMTP para el envío seguro de correos electrónicos (Soporte SSL)
* **Librerías Adicionales:**
  * `AppCompresion.dll`: Utilizada para descomprimir los datasets recibidos desde el servicio.
  * `AppGeneral.dll`: Utilizada para el registro de eventos y errores del sistema.

## 3. Instrucciones de Instalación y Configuración del Entorno

### Prerrequisitos
1. **Visual Studio 2015** (o una versión superior compatible) con soporte para desarrollo de aplicaciones de escritorio con .NET.
2. **.NET Framework 4.5** instalado en el equipo.
3. Credenciales de una cuenta de correo o un servidor SMTP (ej. Office 365, Gmail) para el envío de notificaciones.
4. El servicio WCF `wsCaronte` debe estar expuesto y accesible en la red o servidor correspondiente para que la aplicación obtenga los datos.

### Pasos de Instalación
1. **Clonar o descargar** el repositorio completo en el entorno local.
2. **Abrir la solución** (`Caronte.sln`) en Visual Studio.
3. Asegurarse de que las librerías `AppCompresion.dll` y `AppGeneral.dll` ubicadas en el directorio `Caronte/App_Code/` o `Caronte/Libs/` estén correctamente enlazadas y referenciadas en las dependencias del proyecto. Si muestran una advertencia, será necesario reasignarlas manualmente en el explorador de soluciones.
4. **Editar el archivo `Caronte/App.config`** para configurar las variables de entorno, endpoints y credenciales de acceso.

### Configuración del archivo `App.config`
Es estrictamente necesario configurar el archivo `App.config` antes de compilar y ejecutar el proyecto por primera vez. Configura las siguientes secciones según corresponda:

**1. Configuración del Endpoint WCF:**
Asegúrate de cambiar la IP y el puerto de ejemplo (`1.1.1.1:0`) por la dirección URL correcta donde reside tu servicio web:
```xml
<client>
  <endpoint address="http://[URL_DEL_SERVICIO]/wsCaronte/wsCaronte.svc"
    binding="basicHttpBinding" bindingConfiguration="MainBnd" contract="IwsCaronte"
    name="Basic" />
</client>
```

**2. Configuración del Servidor de Correo (SMTP):**
Reemplaza los valores en la sección `<appSettings>` por tus credenciales de correo real (en este caso el código está preconfigurado para Office 365):
```xml
<add key="smtp_host" value="smtp.office365.com"/>
<add key="smtp_port" value="587"/>
<add key="smtp_user" value="TU_CORREO"/>
<add key="smtp_password" value="TU_CONTRASEÑA"/>
<add key="from_email" value="TU_CORREO"/>
<add key="email_admisiones" value="CORREO_DE_ADMISIONES"/>
```
> **Nota:** Si usas un proveedor de correo que requiere autenticación moderna o medidas de seguridad extra (por ejemplo, Google o Microsoft con Autenticación de Dos Factores), es probable que necesites generar una "Contraseña de Aplicación" para usarla en lugar de tu contraseña habitual.

**3. Compilar:**
Una vez realizados estos cambios, puedes compilar la solución desde Visual Studio mediante el atajo `Ctrl + Shift + B` o haciendo clic en el menú `Compilar -> Compilar solución`.

## 4. Estructura Principal de Carpetas
* `Caronte.sln`: Archivo de solución de Visual Studio que agrupa y contiene las configuraciones generales del proyecto.
* `Caronte/`: Directorio principal y raíz del proyecto en Visual Basic.
  * `App.config`: Archivo maestro de configuración donde se definen variables globales, plantillas para correos, credenciales SMTP y el endpoint del cliente WCF.
  * `Caronte.vb` y `Caronte.Designer.vb`: Clases de la interfaz gráfica donde se define toda la estructura lógica y visual del formulario (WinForms).
  * `App_Code/`: Directorio que contiene el `ModuleMain.vb` que define clases base de datos, constantes, estructuras y modelos del sistema. Adicionalmente, puede contener los binarios y `.dlls` referenciados.
  * `Connected Services/`: Almacena la configuración auto-generada por Visual Studio para interactuar y consumir el servicio web `wsCaronte` mediante WCF.
  * `My Project/`: Carpeta nativa del proyecto de Visual Basic que contiene los ajustes del ensamblado (Assembly), manifiestos, recursos y configuraciones.

## 5. Guía Básica de Uso

1. **Ejecución inicial:**
   * Inicia el proyecto desde Visual Studio (presionando `F5`).
   * De forma alternativa, ejecuta el programa compilado navegando a `Caronte/bin/Debug/Caronte.exe` (o `Release`).
2. **Carga y control de concurrencia:**
   * Al iniciar, un "Mutex" valida internamente que no exista otra instancia de la aplicación ejecutándose al mismo tiempo de forma duplicada.
   * Acto seguido, la función `CargarDatos()` se encarga de contactar al servicio web, pedir la información pendiente de procesar, descomprimirla en un `DataSet` e incrustarla en la grilla (`DataGridView`).
   * La interfaz se actualizará sola automáticamente cada 30 segundos a través de un "Timer".
3. **Manejo de Correos:**
   * Presiona el botón que indica `Enviar correos EPS´s`.
   * El sistema agrupará a los pacientes por su EPS correspondiente, elaborará los cuerpos de mensaje y enviará la notificación utilizando el formato provisto en tu archivo de configuración `App.config`.
   * Tras notificar de manera exitosa a una EPS, se llamará a la función `set_paciente_enviado(...)` en el WebService para marcar los registros y que no se vuelvan a traer en la próxima consulta.
4. **Monitoreo:**
   * La etiqueta de texto en la parte inferior notificará en tiempo real a quién y sobre qué paciente o EPS se está realizando el envío en ese preciso instante.
