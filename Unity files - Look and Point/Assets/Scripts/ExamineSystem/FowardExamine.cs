using UnityEngine;

public class FowardExamine : MonoBehaviour
{

  public Camera globalCamera;
  public Vector3 viewPosition;
  public int angle;
  public Vector3 rotationAxis; // 1,0,0 para X | 0,1,0 para Y | 0,0,1 para Z
  public ExamineState state;
  public bool debug = false;
  public GameObject[] nearObjects;

  // ------------- //

  private GameObject tempCamera; // OnMouseDown
  private Camera tempCameraComponent; // OnMouseDown
  private bool onFocus = false;

  void Update()
  {
    if (onFocus)
    {
      if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse1))
      {
        if (debug) { print("Esc Pressed! -> Saio de Foward Inspection"); }

        // Troca câmera principal -> câmera temporária
        globalCamera.enabled = true;
        tempCameraComponent.enabled = false;

        // Desabilita input de teclado
        onFocus = false;

        // Reabilita o colider
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        b.enabled = true;

        // Destroi camera temporária
        Destroy(tempCamera);

        // Atualiza o estado de exame
        state.isExamining = false;

        // Desabilita interagir com objetos menores
        foreach (GameObject nearObj in nearObjects)
        {
          nearObj.GetComponent<BoxCollider>().enabled = false;
        }
      }
    }
  }

  void OnMouseDown()
  {
    if (state.isExamining == false && state.InRoom == true)
    {
      if (debug) { print("Box Clicked! -> Entrou em Foward Inspection"); }

      // Cria uma nova câmera temporária
      tempCamera = new GameObject("tempCamera");
      tempCameraComponent = tempCamera.AddComponent<Camera>();

      // Configura a posição da nova camera
      tempCamera.transform.position = viewPosition;
      tempCamera.transform.LookAt(transform);
      tempCamera.transform.Rotate(rotationAxis, angle);

      // Transição para a nova câmera
      // https://answers.unity.com/questions/49542/smooth-camera-movement-between-two-targets.html
      // Troca câmera principal -> câmera temporária
      tempCameraComponent.enabled = true;
      globalCamera.enabled = false;

      // Habilita input para o objeto selecionado
      onFocus = true;

      // Desabilita o box colider para deixar o colisor dos objetos menores clicáveis
      BoxCollider b = gameObject.GetComponent<BoxCollider>();
      b.enabled = false;

      // Atualiza o estado de exame
      state.isExamining = true;

      // Habilita interagir com objetos menores
      foreach (GameObject nearObj in nearObjects)
      {
        nearObj.GetComponent<BoxCollider>().enabled = true;
      }
    }
  }
}
