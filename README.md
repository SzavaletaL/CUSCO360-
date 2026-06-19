# Cusco 360: Experiencia Turística Inmersiva

## 📌 Descripción del Proyecto
**Cusco 360** es una solución tecnológica interactiva diseñada para dispositivos móviles que permite a los usuarios y turistas explorar de manera virtual distintos atractivos históricos y arqueológicos de la región del Cusco. El proyecto mitiga la limitada difusión de sitios de valor cultural mediante el uso de entornos interactivos tridimensionales, facilitando el acceso a información relevante y mejorando la experiencia del usuario (UX) mediante una perspectiva inmersiva de tipo *Magic Window*.

Este entregable se enfoca específicamente en el modelado interactivo del **Templo del Mono (Kusilluchayoc)**, optimizado exclusivamente para smartphones (Android) sin requerir visores de Realidad Virtual externos, promoviendo un turismo inclusivo y accesible.

---

## 🏛️ Caso de Estudio: Templo del Mono (Kusilluchayoc)
Para este prototipo se integró el modelo 3D optimizado en formato `glTF` de la zona arqueológica, implementando múltiples capas de interacción:
* **Sector del Mono:** Adoratorio inca tallado en roca viva con información histórica integrada.
* **Sector del Corazón:** Altar ceremonial y zona de ofrendas místicas con efectos visuales dinámicos.

---

## 🚀 Características Principales
* **Control de Navigation Híbrido:** Rotación libre de la perspectiva (360°) mediante el **Giroscopio** físico del celular o arrastre con un dedo, y traslación por el mapa mediante gestos táctiles multitouch (dos dedos).
* **Entorno Dinámico (Skybox):** Reemplazo del fondo plano por un cielo procedural realista en 360° que dota de atmósfera a la escena arqueológica.
* **Sistema de Puntos de Interés (Hotspots):** Esferas interactivas en 3D que despliegan paneles informativos de la interfaz de usuario (UI CANVAS) al ser pulsadas.
* **Paisaje Sonoro Inmersivo (Audio Espacializado 3D):** Audio de ambiente continuo (naturaleza y fauna andina) acompañado de Audio Guías independientes para cada sector con atenuación tridimensional en Unity.
* **Animación de Efectos Especiales:** Sistema de partículas optimizado para móviles para recrear el Fuego Ceremonial inca en el altar del corazón.
* **Simulador de Pasarela de Pago:** Flujo de monetización premium integrado en la interfaz que simula el cobro con tarjeta para desbloquear contenidos exclusivos.

---

## 🛠️ Tecnologías y Herramientas Utilizadas
* **Motor de Desarrollo:** Unity (Versión 2022.3 LTS o superior)
* **Pipeline de Renderizado:** Universal Render Pipeline (URP) para la optimización en dispositivos móviles.
* **Paquetes Complementarios:** `glTFast` para la importación eficiente de modelos glTF/GLB.
* **Lenguaje de Programación:** C# (.NET Core)
* **Plataforma Objetivo:** Android OS (Compilación APK nativa)

---

## 📖 Manual de Implementación Paso a Paso (Guía Técnica)

A continuación se detalla el proceso técnico seguido para la construcción de la aplicación:

### Paso 1: Configuración de la Plataforma y Gráficos (URP)
1. Se cambió la plataforma objetivo de desarrollo a **Android** desde *File -> Build Settings*.
2. Se configuró el proyecto para utilizar **Universal Render Pipeline (URP)** con el fin de optimizar el rendimiento de luces y texturas en procesadores móviles.
3. Se instaló el paquete **glTFast** a través del *Package Manager* usando su Git URL para permitir la lectura nativa de formatos de modelado modernos en la aplicación.

### Paso 2: Importación y Optimización del Modelo 3D
1. Se importó el modelo en formato `.gltf` del Templo del Mono junto a su carpeta de texturas.
2. Para evitar el sobrecalentamiento del celular, se aplicó una optimización estricta de texturas en el Inspector bajo la pestaña Android: se limitó el tamaño máximo a **2048px** y se activó el formato de compresión **ASTC**.
3. El modelo se marcó como **Static** y se ejecutó un "horneado" de luces estáticas (*Window -> Rendering -> Lighting -> Generate Lighting*) para desactivar las sombras en tiempo real y asegurar una tasa fluida de 60 FPS en móviles.

### Paso 3: Programación del Control Híbrido (Giroscopio y Táctil)
1. Se implementó un script en C# asignado a la **Main Camera** que realiza las siguientes tres funciones lógicas simultáneas en el método `Update()`:
   * **Giroscopio:** Activa el sensor del celular mediante `Input.gyro.enabled = true` en el `Start()` y rota la cámara mapeando físicamente los movimientos del usuario en el espacio real.
   * **Un dedo (Fallback):** Permite rotar la vista usando el arrastre tradicional de la pantalla por si el dispositivo no posee sensor físico.
   * **Dos dedos (Traslación):** Calcula el promedio de desplazamiento (`deltaPosition`) de ambos dedos para trasladar la posición de la cámara horizontalmente en el mapa.

### Paso 4: Construcción de la Interfaz Interactiva (UI Canvas)
1. Se creó un objeto **Canvas** configurado en modo *Scale With Screen Size (1080x1920)* para garantizar que la interfaz sea *responsive* en cualquier resolución de pantalla móvil.
2. Se crearon los contenedores ocultos `PanelInformacion` y `PanelCorazon` con sus respectivos textos descritivos en *TextMeshPro* y botones de cierre ("X").
3. Se crearon esferas 3D en la escena para que actúen como **Hotspots**. Se les asignó un script de detección de toques (*Raycasting*), encargándose de activar (`SetActive(true)`) sus respectivos paneles de interfaz al recibir un *tap* en la pantalla táctil.

### Paso 5: Implementación de la Capa de Audio de Entorno y Audio Guías
1. Se insertó un componente *Audio Source* en la cámara para la música/sonido de ambiente (fauna andina), configurado en **Play On Wake** y **Loop**.
2. Se insertaron componentes *Audio Source* independientes en cada Hotspot 3D con la propiedad **Spatial Blend configurada en 3D (1.0)** para simular audio espacializado con audífonos.
3. Se vinculó el botón de cierre ("X") de la UI con el método `.Stop()` de los Hotspots para apagar la narración inmediatamente si el usuario decide cerrar el panel.

### Paso 6: Configuración del Fuego de Partículas y Simulador de Pagos
1. Se añadió un objeto de **Sistema de Partículas (Particle System)** en el altar del corazón, configurando la forma en hemisferio con un radio de `0.1` y aplicando un gradiente de color (Rojo-Amarillo-Gris) con desvanecimiento de *Alpha* a lo largo del tiempo de vida.
2. Se programó una simulación de pasarela de cobro bancario mediante una corrutina en C# que valida los 16 dígitos de una tarjeta ficticia, congela la pantalla 2.5 segundos emulando la comunicación de red, despliega un aviso de "Pago Exitoso" y desbloquea funciones premium en la interfaz.
