# Sistema de Gestión de Exploración Espacial 

## Contexto

La organización AstroNova Mission Control necesita un sistema para gestionar sus operaciones espaciales, incluyendo astronautas, naves, misiones y exploraciones interplanetarias.

El objetivo es construir un sistema completo utilizando C#, LINQ y Entity Framework Core, aplicando buenas prácticas y modelado de datos realista.

---

## Entidades

### 1. Astronautas
- id  
- nombre  
- apellido  
- rango (novato, piloto, comandante)  
- horas_experiencia  

---

### 2. Ingenieros
- id  
- nombre  
- apellido  
- especialidad (propulsión, sistemas, IA, etc.)  
- años_experiencia  

---

### 3. Naves
- id  
- nombre  
- modelo  
- capacidad_tripulación  
- estado (operativa, en mantenimiento, retirada)  

---

### 4. Misiones (Entidad Relacionada)
- id  
- nombre_mision  
- fecha_lanzamiento  
- estado (planificada, en curso, completada, fallida)  
- astronauta_id  
- nave_id  

#### Relaciones:
- Un astronauta puede participar en muchas misiones  
- Una nave puede ser usada en muchas misiones  
- Cada misión tiene un astronauta principal y una nave asignada  

---

### 5. RegistrosDeExploracion
- id  
- planeta_destino  
- descripcion  
- nivel_riesgo (bajo, medio, alto)  
- mision_id  

#### Relación:
- Una misión puede tener múltiples registros de exploración  
- Cada registro pertenece a una sola misión  

---

## Requerimientos Técnicos

### CRUD Completo

Implementar operaciones de:
- Crear
- Leer
- Actualizar
- Eliminar

Para las siguientes entidades:
- Astronautas  
- Ingenieros  
- Naves  
- Misiones  
- RegistrosDeExploracion  

---

## Relaciones Obligatorias

- Astronautas → Misiones (1:N)  
- Naves → Misiones (1:N)  
- Misiones → RegistrosDeExploracion (1:N)  

---

## Validaciones

- Horas de experiencia deben ser mayores a 0  
- Capacidad de nave debe ser mayor a 0  
- Nivel de riesgo debe ser válido (bajo, medio, alto)  
- Estado de misión debe ser válido  
- Años de experiencia no pueden ser negativos  

---

## Mensajes del Sistema

Cada acción debe devolver un mensaje claro al usuario:

Ejemplos:
- "Astronauta creado correctamente"
- "Misión actualizada correctamente"
- "Registro de exploración eliminado correctamente"

---

## Uso Obligatorio de LINQ

### Consultas Básicas
- Listar todas las misiones  
- Buscar naves operativas  
- Filtrar astronautas por rango  

---

### Consultas con Relaciones (Include / ThenInclude)
- Obtener misiones con su astronauta y nave  
- Obtener registros de exploración por misión  

---

### Proyecciones (Select)
Mostrar información personalizada, por ejemplo:
- Nombre de misión  
- Nombre del astronauta  
- Nombre de la nave  

---

### Agrupaciones
- Agrupar misiones por estado  
- Contar misiones por astronauta  

---

### Consultas Avanzadas
- Astronautas con más de 3 misiones  
- Naves no utilizadas  
- Misiones con nivel de riesgo alto  
- Misiones en curso con registros asociados  

---

## Requisitos de Implementación (EF Core)

Debe incluir:

- DbContext  
- DbSet<> por cada entidad  
- Configuración de relaciones (Fluent API o Data Annotations)  
- Migraciones:
  - Add-Migration InitialCreate
  - Update-Database  

---


## Entregable

- Proyecto funcional en .NET  
- Base de datos creada con migraciones  
- CRUD completo

---
