using UnityEngine;

public class CameraSmoothTransition : MonoBehaviour
{
  public bool debug = false;

  // ------------- //

  private float smoothTime = 2.0f;
  private Vector3 velocity = Vector3.zero;
  private float rotationStep = 0.0625f;
  private bool isAnimating = false;
  private Vector3 tempPosision = Vector3.zero;
  private Vector3 mainPosition = Vector3.zero;

  public bool CameraMenuAnimation(Camera mainCamera, Camera tempCamera)
  {
    isAnimating = true;

    // Links da documentação
    // https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html
    // https://docs.unity3d.com/ScriptReference/Quaternion.RotateTowards.html
    // https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
    transform.position = Vector3.SmoothDamp(
      transform.position,
      mainCamera.transform.position,
      ref velocity,
      smoothTime
    );
    transform.rotation = Quaternion.RotateTowards(
      transform.rotation,
      mainCamera.transform.rotation,
      rotationStep
    );


    tempPosision = tempCamera.transform.position;
    mainPosition = mainCamera.transform.position;
    if (Vector3.Distance(tempPosision, mainPosition) < 0.125f)
    {
      if (debug) { print("FIM"); }
      mainCamera.enabled = true;
      tempCamera.enabled = false;
      isAnimating = false;
    }

    return isAnimating;
  }
}
