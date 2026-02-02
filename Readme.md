# Task Track System

Aplicación web para la **gestión de tareas académicas**, que permite a los estudiantes organizar sus actividades mediante vistas de **lista**, **calendario** y **kanban**, con autenticación segura y personalización básica de la experiencia de usuario.

El proyecto está desarrollado con **ASP.NET Core 8 (Web API)** en el backend y **Angular** en el frontend, siguiendo principios de **Clean Architecture** para asegurar mantenibilidad, escalabilidad y separación de responsabilidades.

<!-- --- -->

## Arquitectura del Proyecto

El backend está organizado en cuatro capas principales:

```
/src
 ├── Domain
 ├── Application
 ├── Persistence
 └── WebApi

```

### Domain

Contiene el **núcleo del negocio**:

<!-- - Entidades (`User`, `Task`, `Tag`) -->
- Entidades
- Value Objects y Enums
- Interfaces de repositorios

> No depende de ninguna otra capa.
---

### Application

Contiene los **casos de uso** del sistema:

- DTOs
<!-- - Commands / Queries (CQRS) -->
- Validaciones
- Interfaces de servicios

> Depende de Domain y Persistence.

---

### Persistence

Responsable del **acceso a datos**:

- Entity Framework Core
- DbContext
- Implementación de repositorios
- Configuración de entidades y relaciones

<!-- > Depende de Domain y Application. -->
> Depende de Domain.

---

### WebApi

Capa de entrada del sistema:

- Controllers REST
- Autenticación y autorización
- Configuración de middlewares
- Exposición de endpoints para Angular

<!-- > Depende de Application y Persistence. -->

<!-- --- -->

## Tecnologías Utilizadas

### Backend

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- JWT Authentication
- AutoMapper
- FluentValidation
<!-- - MediatR (CQRS) -->

### Frontend

- Angular
- Angular Material / CDK
- RxJS
- FullCalendar (vista calendario)
- Drag & Drop (vista Kanban)

### Base de Datos

- SQL Server / PostgreSQL (configurable)
- Esquema relacional normalizado
- UUID como clave primaria

<!-- --- -->

## Funcionalidades Principales

### Gestión de Usuarios

- Registro de usuario
- Inicio y cierre de sesión
- Edición de perfil
- Preferencias de usuario (tema visual)

### Gestión de Tareas

- Crear, editar y eliminar tareas
- Prioridades y estados
- Archivado lógico
- Historial de cambios de estado

### Organización y Visualización

- Vista tipo Kanban
- Vista de calendario por fecha de vencimiento
- Etiquetas (tags) para filtrado avanzado

---

## Esquema de Base de Datos

El sistema utiliza el siguiente esquema relacional:

```
Table users {
  id uuid [pk]
  email varchar [unique, not null]
  password_hash varchar
  full_name varchar
  avatar_url varchar
  is_active boolean [default: true]
  created_at timestamp
  updated_at timestamp
}

Table user_preferences {
  id uuid [pk]
  user_id uuid [not null, ref: > users.id]
  theme varchar [note: "light | dark"]
  created_at timestamp
}

Table tasks {
  id uuid [pk]
  user_id uuid [not null, ref: > users.id]
  title varchar [not null]
  description text
  due_date timestamp
  status varchar [note: "pending | in_progress | completed"]
  priority varchar [note: "low | medium | high"]
  position int [note: "Orden para Kanban"]
  is_archived boolean [default: false]
  created_at timestamp
  updated_at timestamp
}

Table task_history {
  id uuid [pk]
  task_id uuid [not null, ref: > tasks.id]
  previous_status varchar
  new_status varchar
  changed_at timestamp
}

Table tags {
  id uuid [pk]
  name varchar [unique]
  color varchar
}

Table task_tags {
  task_id uuid [ref: > tasks.id]
  tag_id uuid [ref: > tags.id]

  Indexes {
    (task_id, tag_id) [unique]
  }
}

```

## Flujo General del Sistema

1. El usuario se autentica desde Angular
2. El backend genera un JWT
3. Angular consume los endpoints protegidos
4. Las tareas se organizan por estado (Kanban) o fecha (Calendario)
5. Los cambios de estado se registran en el historial

## Configuración y Ejecución

### Backend

```bash
dotnet restore
dotnet ef database update
dotnet run

```

### Frontend

```bash
npm install
ng serve

```