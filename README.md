# Proyecto-Aprendizaje-2021  
Aprendizaje progresivo en Unity – Animación, Arquitectura, Patrones y Sistemas

Este proyecto es un **compendio de prácticas**, ejercicios y prototipos creados para aprender diversos conceptos fundamentales de Unity y programación avanzada en C#.  
El objetivo principal fue evolucionar paso a paso desde conceptos básicos hasta arquitecturas más robustas utilizando animación, IA, patrones de diseño, delegados, eventos y optimización.

Cada módulo representa una clase o etapa de aprendizaje distinta, aplicada directamente dentro del proyecto.

---

# 📘 Contenidos del Proyecto

## 🎮 **Root Motion**
Se trabajó con animaciones basadas en Root Motion:
- Movimiento controlado por la animación y no por código.
- Corrección de deslizamientos en el personaje.
- Entendimiento de cómo Unity combina Animator + Físicas + Transform.

---

## 🧩 **Clase 5 – Abstracción**
Se aplicó abstracción para:
- Simplificar comportamientos complejos en clases base.
- Crear personajes, enemigos o ítems con estructura común.
- Ocultar detalles internos para reducir acoplamiento.
  
Ejemplo conceptual:  
Clases base como `Entidad`, `Interactuable`, `Arma`, etc., que luego se heredan y expanden.

---

## 🔌 **Clase 6 – Interfaces**
Uso de interfaces para:
- Definir comportamientos obligatorios sin herencia múltiple.
- Unificar acciones como **IInteract**, **IDamageable**, **IMove**, etc.
- Separar el “qué hace” del “cómo lo hace”.

Esto permitió código más limpio, escalable y modular.

---

## 🏛️ **Clase 7 – Patrones de Diseño**
Se implementaron varios patrones:
- **Singleton** (para managers globales)
- **Factory** (creación de objetos con variaciones)
- **Strategy** (múltiples comportamientos de IA o ataque)
- **Observer/Event** (suscripción entre sistemas)

El objetivo fue aprender a estructurar proyectos amplios y evitar código duplicado.

---

## 🎥 **Clase 8 – Corrutinas y Cinemachine**
En este módulo:
- Se usaron **Coroutines** para temporizadores, llamadas asíncronas de forma ordenada y procesos escalonados.
- Se integró **Cinemachine** para cámaras profesionales sin tener que programarlas desde cero:
  - Freelook
  - FollowCam
  - Alineación suave
  - Transiciones dinámicas

---

## 🚜 **Clase 9 – NavMeshAgent Tipo Tanque**
Se probó un movimiento diferente al estándar del agente, implementando:
- Rotación y movimiento diferenciados.
- Giros lentos y dirección fija tipo tanque.
- Reinterpretación completa del NavMeshAgent default.

Fue un ejercicio para comprender profundamente la navegación y las limitaciones del agente tradicional.

---

## 🔔 **Clase 10 – Delegados y Eventos**
Se trabajó con:
- **Delegates**
- **Eventos C#**
- **UnityEvent**

Objetivo:
- Entender cuándo usar cada uno.
- Desacoplar sistemas (por ejemplo, UI que escucha al Player).
- Crear interacciones seguras y escalables.

---

# 🔬 Investigación Extra

## ⚙️ **Uso Óptimo de Threads**
Se investigó:
- Cuándo usar hilos en Unity.
- Problemas con el acceso al Main Thread.
- Tareas paralelas seguras para cálculos pesados.
- Riesgos de condiciones de carrera y sincronización.

---

## ⚡ **Async / Await en Unity**
Se probó el uso de async:
- Carga en background sin framerate drop.
- Lógica secuencial sin bloquear el juego.
- Comparación Vs. Coroutines.

Se determinó cuándo es mejor cada sistema según el caso.

---

# 📌 Estado del Proyecto
- Proyecto 100% educativo.
- Contiene múltiples escenas pequeñas de prueba.
- No está pensado como juego final, sino como repositorio de conceptos y sistemas implementados para aprender.

---
