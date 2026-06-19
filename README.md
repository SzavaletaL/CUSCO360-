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
* **Control de Navegación Híbrido:** * Rotación libre de la perspectiva (360°) mediante el **Giroscopio** físico del celular o arrastre con un dedo.
  * Desplazamiento y traslación por el mapa mediante gestos táctiles multitouch (arrastre con dos dedos).
* **Entorno Dinámico (Skybox):** Reemplazo del entorno base por un cielo procedural realista en 360° que dota de atmósfera a la escena arqueológica.
* **Sistema de Puntos de Interés (Hotspots):** Esferas interactivas en 3D que, al ser pulsadas por el usuario, despliegan paneles informativos de la interfaz de usuario (UI CANVAS).
* **Paisaje Sonoro Inmersivo (Audio Espacializado 3D):** * Audio de ambiente continuo (sonidos de la naturaleza y fauna andina) en segundo plano.
  * Audios explicativos independientes (Audio Guías) que se activan al interactuar con cada sector y aprovechan las matemáticas de atenuación 3D en Unity.
* **Animación de Efectos Especiales:** Sistema de partículas optimizado para móviles para recrear el Fuego Ceremonial inca en el altar del corazón.
* **Simulador de Pasarela de Pago:** Flujo de monetización premium integrado en la interfaz que simula el cobro con tarjeta para desbloquear contenidos exclusivos del recorrido, validando el modelo de sostenibilidad del proyecto.

---

## 🛠️ Tecnologías y Herramientas Utilizadas
* **Motor de Desarrollo:** Unity (Versión 2022.3 LTS o superior)
* **Pipeline de Renderizado:** Universal Render Pipeline (URP) para la optimización geométrica y de materiales en dispositivos móviles.
* **Paquetes Complementarios:** `glTFast` para la importación y procesamiento eficiente de modelos glTF/GLB.
* **Lenguaje de Programación:** C# (.NET Core)
* **Plataforma Objetivo:** Android OS (Compilación APK nativa)

---

## 📈 Vinculación con los Objetivos de Desarrollo Sostenible (ODS)
El proyecto se alinea directamente con el **ODS 11: Ciudades y Comunidades Sostenibles**, respondiendo específicamente a la meta de **"Fortalecer los esfuerzos para proteger y salvaguardar el patrimonio cultural y natural del mundo"**. A través de la digitalización y virtualización del patrimonio, se fomenta un turismo más inclusivo, sostenible y de bajo impacto físico para los monumentos arqueológicos del Cusco.

---

## 📁 Estructura del Repositorio (Clave en Unity)
```text
├── Assets/
│   ├── Modelos/          # Modelado 3D del Templo del Mono y texturas asociadas
│   ├── Materials/        # Materiales URP (Cielo Skybox, Fuego, etc.)
│   ├── Audio/            # Clips de audio (Ambiente natural y Audio Guías)
│   ├── Scripts/          # Código fuente en C# (Controles, Hotspots, Pagos)
│   └── Scenes/           # Escena principal de la experiencia turística
├── ProjectSettings/      # Configuraciones del Input System y compilación de Android
└── README.md             # Documentación general del proyecto
