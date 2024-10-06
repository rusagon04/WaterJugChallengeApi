# Water Jug Challenge Api

## Descripción

Esta API permite calcular los pasos necesarios para medir exactamente Z galones utilizando dos jarras con capacidades X y Y galones. Este proyecto utiliza ASP.NET Core para implementar un servicio RESTful que permite a los usuarios enviar solicitudes y recibir soluciones en formato JSON.

## Endpoints

### 1. Medir Agua

- **URL**: `/api/WaterJugChallenge`
- **Método**: `POST`
- **Descripción**: Este endpoint permite a los usuarios enviar las capacidades de las jarras (X y Y) y la cantidad de agua deseada (Z).

  
## Parámetros de Entrada

```json
{
  "x_capacity": 5,
  "y_capacity": 3,
  "z_amount_wanted": 4
}
```
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
