# TO DO LIST API

## About
Framework .net5<br/>
API documented using Swagger<br/>
API already versioned<br/>

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
