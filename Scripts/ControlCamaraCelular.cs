using UnityEngine;

public class ControlCamaraCelular : MonoBehaviour
{
    [Header("Configuración de Rotación (1 Dedo)")]
    public float velocidadRotacion = 3.0f;
    private float rotacionX = 0f;
    private float rotacionY = 0f;

    [Header("Configuración de Movimiento (2 Dedos)")]
    public float velocidadMovimiento = 0.5f;

    void Start()
    {
        Vector3 rotacionActual = transform.localEulerAngles;
        rotacionY = rotacionActual.y;
        rotacionX = rotacionActual.x;

        // ¡AQUÍ ACTIVAMOS EL SENSOR DEL CELULAR!
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
        // 1. CONTROL POR GIROSCOPIO (Si el celular tiene el sensor activo)
        if (SystemInfo.supportsGyroscope && Input.touchCount == 0)
        {
            // Lee la velocidad de rotación física del celular y la aplica a la cámara
            float gyroX = Input.gyro.rotationRateUnbiased.x;
            float gyroY = Input.gyro.rotationRateUnbiased.y;

            // En dispositivos móviles los ejes suelen invertirse, los ajustamos:
            transform.Rotate(-gyroX * Time.deltaTime * 50f, -gyroY * Time.deltaTime * 50f, 0);

            // Estabilizar el eje Z para que la pantalla no se incline de lado
            Vector3 rotacionLimpia = transform.localEulerAngles;
            rotacionLimpia.z = 0;
            transform.localEulerAngles = rotacionLimpia;
        }

        // 2. MOVERSE POR EL MAPA (Desplazamiento con DOS dedos)
        if (Input.touchCount == 2)
        {
            Touch toque0 = Input.GetTouch(0);
            Touch toque1 = Input.GetTouch(1);

            if (toque0.phase == TouchPhase.Moved || toque1.phase == TouchPhase.Moved)
            {
                Vector2 deltaPromedio = (toque0.deltaPosition + toque1.deltaPosition) / 2;
                Vector3 direccionMovimiento = new Vector3(-deltaPromedio.x, 0, -deltaPromedio.y) * velocidadMovimiento * Time.deltaTime;
                Vector3 movimientoDireccionado = transform.TransformDirection(direccionMovimiento);
                movimientoDireccionado.y = 0;
                transform.position += movimientoDireccionado;
            }
        }
        // 3. ROTAR CON UN DEDO (Alternativa por si falla el giroscopio o estás en PC)
        else if (Input.GetMouseButton(0) && Input.touchCount < 2)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            rotacionY += mouseX * velocidadRotacion;
            rotacionX -= mouseY * velocidadRotacion;
            rotacionX = Mathf.Clamp(rotacionX, -40f, 70f);

            transform.rotation = Quaternion.Euler(rotacionX, rotacionY, 0);
        }
    }
}