using UnityEngine;

public class RotateCamera : MonoBehaviour
{

  public Vector3 centerPoint;
  public int rotationSteps = 360;
  public DisplaySystem displayController;

  // -------------- //

  private Vector3 axisToRotate = new Vector3(0f, 1f, 0f);
  private bool isRotating = false;
  private int direction = 0;
  private float anglePerStep; // start
  private int initialRotationSteps; // start

  private Vector2 activeGroups = new Vector2(0, 1);
  private Transform currentPosition; // start

  void Start()
  {
    // Confiuguração inicial
    anglePerStep = (float)90f / rotationSteps;
    initialRotationSteps = rotationSteps;
    // print($"anglePerStep = {anglePerStep}");

    currentPosition = transform;

    displayController.disableAllRenderers();
    displayController.DisplayOnlyActiveGroups(activeGroups);
  }

  void Update()
  {
    // Quaternion.RotateTowards(currentRotationQua, currentRotationQua * angle, 90f);

    if (isRotating) { Rotate(); }
    else if (Input.GetKeyDown(KeyCode.D))
    {
      isRotating = true;
      direction = 1;
    }
    else if (Input.GetKeyDown(KeyCode.A))
    {
      isRotating = true;
      direction = -1;
    }
  }

  public void HandleRightArrowUIPress()
  {
    if (!isRotating)
    {
      isRotating = true;
      direction = 1;
    }
  }

  public void HandleLeftArrowUIPress()
  {
    if (!isRotating)
    {
      isRotating = true;
      direction = -1;
    }
  }

  void Rotate()
  {
    // gameObject.transform.RotateAround(centerPoint, axisToRotate, speed * Time.deltaTime);
    gameObject.transform.RotateAround(
      centerPoint,
      axisToRotate,
      anglePerStep * direction
    );

    rotationSteps -= 1;

    if (rotationSteps == 0)
    {
      UpdateActiveGroup();

      // Reseta para configuração inicial
      isRotating = false;
      direction = 0;
      rotationSteps = initialRotationSteps;

      displayController.DisplayOnlyActiveGroups(activeGroups);

      // Salva a nova posição
      currentPosition = transform;
    }

  }

  void UpdateActiveGroup()
  {
    int first = (int)activeGroups[0];
    int second = (int)activeGroups[1];

    first += direction;
    if (first == 4) { first = 0; }
    else if (first == -1) { first = 3; }

    second += direction;
    if (second == 4) { second = 0; }
    else if (second == -1) { second = 3; }

    // print($"antes: {activeGroup}");
    activeGroups = new Vector2(first, second);
    // print($"depois: {activeGroup}");
  }
}
