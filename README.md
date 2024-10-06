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

## Respuesta Exitosa

{
  "message":"",
  "solution": [
    {
      "step": 1,
      "bucketX": 5,
      "bucketY": 0,
      "action": "Fill X",
      "status": "In Progress"
    },
    {
      "step": 2,
      "bucketX": 2,
      "bucketY": 3,
      "action": "Transfer from X to Y",
      "status": "In Progress"
    },
    {
      "step": 3,
      "bucketX": 2,
      "bucketY": 0,
      "action": "Empty Y",
      "status": "In Progress"
    },
    {
      "step": 4,
      "bucketX": 0,
      "bucketY": 2,
      "action": "Transfer from X to Y",
      "status": "Solved"
    }
  ]
}

## Respuesta de Error

{
  "message": "No solution possible. Display 'No Solution'",
  "solution": []
}
