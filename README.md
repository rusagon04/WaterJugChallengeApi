# Water Jug Challenge Api

## Descripción

Esta API permite calcular los pasos necesarios para medir exactamente Z galones utilizando dos jarras con capacidades X y Y galones. Este proyecto utiliza ASP.NET Core para implementar un servicio RESTful que permite a los usuarios enviar solicitudes y recibir soluciones en formato JSON.

## Endpoints

### 1. Post

- **URL**: `/api/WaterJugChallenge`
- **Método**: `POST`
- **Descripción**: Este endpoint permite a los usuarios enviar las capacidades de las jarras (X y Y) y la cantidad de agua deseada (Z).

  
## Formato de parámetros de Entrada

```json
{
  "x_capacity": 5,
  "y_capacity": 3,
  "z_amount_wanted": 4
}
```

### Campos

> x_capacity: Capacidad de la jarra X (entero no negativo).
> y_capacity: Capacidad de la jarra Y (entero no negativo).
> z_amount_wanted: Cantidad deseada de agua (entero no negativo).


## Formato de Respuesta 

```json
{
  "message": "",  // Mensaje de error (opcional)
  "solution": [
    {
      "step": 1,
      "bucketX": 0,
      "bucketY": 4, 
      "action": "Llenar Jarra Y",
      "status": ""  // Vacío para pasos intermedios, "Solved" cuando se cumple el objetivo.
    },
    // ... más pasos de ser requerido
  ]
}
```

### Campos

> message: Mensaje informativo o de error.
> solution: Lista de pasos (cada paso es un objeto que incluye el número de paso, el estado de cada jarra, la acción realizada y el estado del proceso (El estado del proceso solo se muestra una vez se cumple el ultimo paso, el cual da solucion al algoritmo)).

## Manejo de Errores

La API devuelve mensajes de error en formato JSON para entradas inválidas (enteros no positivos) o si no se encuentra solución:

> The capacity of jar X must be a non-negative integer (La capacidad de la jarra X debe ser un entero no negativo).
> The capacity of jar Y must be a non-negative integer (La capacidad de la jarra Y debe ser un entero no negativo).
> The capacity of jar X must be a non-negative integer (La capacidad de la jarra Z debe ser un entero no negativo).
> No solution possible. Display “No Solution” (No existe solución para las capacidades y el volumen objetivo dados).


