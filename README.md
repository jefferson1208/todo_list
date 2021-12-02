# TO DO LIST API

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## About

```bash
Framework .net5
API documented using Swagger
API already versioned
Unit tests and Integration

```

## Packages

```bash
AutoMapper.Extensions.Microsoft.DependencyInjection
FluentValidation
Microsoft.AspNetCore.Mvc.Versioning
Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
Newtonsoft.Json
Swashbuckle.AspNetCore.Swagger
Swashbuckle.AspNetCore.SwaggerGen
Swashbuckle.AspNetCore.SwaggerUI

```

## 1 - Create a task
```csharp
{
  "title": "string",
  "done": true
}
```
Title: Minimum 10 characters and maximum 50
## 2 - Update a task
Enter the id generated when creating the task and change the title and/or done fields

```csharp
{
  "title": "string",
  "done": true,
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

## 3 - Remove a task

Route: api/v1/todo/remove/6605e119-481c-4116-90bc-3d98219f88a1
<br/>Enter the id of the task you want to remove

## 4 - Get all tasks or by id

Route: api/v1/todo/all-todos

## 5 - Get task by id

Route: api/v1/todo/todo-by-id/6605e119-481c-4116-90bc-3d98219f88a1

## 3 - Technologies
<div style="display: inline_block"><br>
  <img align="center" alt="Jeferson-Netcore" height="30" width="40" src="https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg">
  <img align="center" alt="Jeferson-Csharp" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">
</div>
