using UnityEngine;

public class HotspotInteractiva : MonoBehaviour
{
    // El panel de información de la UI asignado a este Hotspot
    public GameObject panelInformacion;

    private AudioSource miAudioSource;

    void Start()
    {
        // Obtenemos de forma automática el componente de audio que le pusimos a esta esfera
        miAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Detectar toque en la pantalla táctil del celular
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit))
            {
                if (hit.transform == this.transform)
                {
                    // 1. Abrimos el panel de información visual
                    panelInformacion.SetActive(true);

                    // 2. Si hay un audio asignado y no está sonando, lo reproducimos
                    if (miAudioSource != null && !miAudioSource.isPlaying)
                    {
                        miAudioSource.Play();
                    }
                }
            }
        }
    }

    // Esta función la llamaremos desde el botón "X" de cerrar para detener la voz en off
    public void DetenerAudioExplicacion()
    {
        if (miAudioSource != null && miAudioSource.isPlaying)
        {
            miAudioSource.Stop();
        }
    }
}