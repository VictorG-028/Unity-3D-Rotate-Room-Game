using UnityEngine;

public class PickUpExamine : MonoBehaviour
{
  public Transform frontPoint;
  public Camera globalCamera;
  public ExamineState state;
  public bool debug = false;

  // ------------- //

  private bool onFocus = false;
  private Vector3 originalPosition; // start
  private Vector3 originalAngle; // start
  private Vector3 originalScale; // start
  private GameObject tempCamera; // OnMouseDown
  private Camera tempCameraComponent; // OnMouseDown
  private float h = 0f;
  private float v = 0f;
  private float horizontal_sensitivity = 8.0f;
  private float vertical_sensitivity = 6.0f;

  void Start()
  {
    originalPosition = transform.localPosition;
    originalAngle = transform.localEulerAngles;
    originalScale = transform.localScale;
  }

  void Update()
  {
    if (onFocus)
    {
      if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse1))
      {
        if (debug) { print("Esc Pressed! -> Saio de Pick Up Inspection"); }

        // Disable skyscrapper render
        GameObject.Find("Skyscraper").GetComponent<MeshRenderer>().enabled = false;

        // Troca câmera principal -> câmera temporária
        globalCamera.enabled = true;
        tempCameraComponent.enabled = false;

        // Desabilita input de teclado
        onFocus = false;

        // Reabilita o colider
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        b.enabled = true;

        // Coloca o objeto na posição original
        transform.position = originalPosition;
        transform.rotation = Quaternion.Euler(originalAngle);
        transform.localScale = originalScale;

        // Destroi camera temporária
        Destroy(tempCamera);

        // Atualiza o estado de exame
        state.isExamining = false;
      }
      else if (Input.GetKey(KeyCode.Mouse0))
      {
        h = horizontal_sensitivity * Input.GetAxis("Mouse X");
        v = vertical_sensitivity * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, h, 0, Space.World);
      }
    }
  }

  void OnMouseDown()
  {
    if (state.isExamining == false && state.InRoom == true)
    {
      if (debug) { print("Box Clicked! -> Entrou em Pick Up Inspection"); }

      // Enable Skyscrapper renderer
      GameObject.Find("Skyscraper").GetComponent<MeshRenderer>().enabled = true;

      // Cria uma nova câmera temporária
      tempCamera = new GameObject("tempCamera");
      tempCameraComponent = tempCamera.AddComponent<Camera>();

      // Configura a posição da nova camera
      tempCamera.transform.position = globalCamera.transform.position;
      tempCamera.transform.LookAt(frontPoint);

      // Pega o objeto na frente da camera
      transform.position = frontPoint.position;
      transform.LookAt(tempCamera.transform.position);
      transform.Rotate(-90, 0, 0, Space.Self);

      // Troca câmera principal -> câmera temporária
      tempCameraComponent.enabled = true;
      globalCamera.enabled = false;

      // Habilita input para o objeto selecionado
      onFocus = true;

      // Desabilita o colider
      BoxCollider b = gameObject.GetComponent<BoxCollider>();
      b.enabled = false;

      // Atualiza o estado de exame
      state.isExamining = true;
    }
  }

}
