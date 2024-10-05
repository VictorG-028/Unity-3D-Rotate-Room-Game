using UnityEngine;

public class MenuScene : MonoBehaviour
{
  // public Vector3 pointA; // Menu position = 2.16 2.92 -4.8
  // public Vector3 pointB; // Initial position = -10.95 12.53 -10.89 // rotation 30 35 0
  // public Transform target; // Target gameObject
  // public Camera mainCamera;
  public GameObject Main_Camera;
  public CameraSmoothTransition transitionController;
  [SerializeField] public Texture image;
  public bool debug = false;

  // ------------- //

  private bool isAnimating = false;
  private bool hasFinishedAnimation = false;
  private Camera menuCamera;
  private Camera mainCamera;
  private GUIStyle centeredStyle;

  // string message = "Pressione Botão Esquerdo do Mouse ou ESC para começar.";
  // private float size = 0.02f * Screen.width;
  private float width;
  private float height;

  void Start()
  {
    menuCamera = gameObject.GetComponent<Camera>();
    mainCamera = Main_Camera.GetComponent<Camera>();
  }

  void Update()
  {
    if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape)
      ) && isAnimating == false && hasFinishedAnimation == false)
    {
      if (debug) { print("Começou animação"); }
      isAnimating = true;
    }
    else if (isAnimating)
    {
      isAnimating = transitionController.CameraMenuAnimation(mainCamera, menuCamera);
      hasFinishedAnimation = !isAnimating; // Always oposite bool value
    }
    else if (hasFinishedAnimation)
    {
      if (debug) { print("Terminou animação"); }

      RotateCamera ScriptToStartGameCameraLogic = Main_Camera.GetComponent<RotateCamera>();
      ScriptToStartGameCameraLogic.enabled = true;
      hasFinishedAnimation = false;

      // Disable skyscrapper render
      GameObject.Find("Skyscraper").GetComponent<MeshRenderer>().enabled = false;

      // Kill this script
      // gameObject.GetComponent<MenuScene>().enabled = false;
      Destroy(gameObject);
    }
  }

  void OnGUI()
  {
    // Links úteis:
    // Screen.resolutions: https://docs.unity3d.com/ScriptReference/Screen-resolutions.html
    // Screen: https://answers.unity.com/questions/1173714/how-to-get-window-resolution-in-windowed-mode-not.html
    // TextAnchor: https://answers.unity.com/questions/37223/how-do-i-center-a-gui-label.html
    // image parameter: https://answers.unity.com/questions/1580508/can-i-set-a-solid-background-for-a-gui-label.html
    // Resolution[] resolutions = Screen.resolutions;
    // foreach (Resolution res in resolutions)
    // {
    //   print(res);
    // }
    if (isAnimating == false && hasFinishedAnimation == false)
    {
      centeredStyle = GUI.skin.GetStyle("Label");
      centeredStyle.alignment = TextAnchor.UpperCenter;

      width = 0.75f * Screen.width;
      height = 0.1f * Screen.width;

      GUI.Label(
          new Rect((Screen.width - width) / 2, (Screen.height - height), width, height),
          image, // Font da imagem: BAUHS93
                 // $"<color=red><size={size}>{message}</size></color>",
          centeredStyle
      );
    }
  }
}
