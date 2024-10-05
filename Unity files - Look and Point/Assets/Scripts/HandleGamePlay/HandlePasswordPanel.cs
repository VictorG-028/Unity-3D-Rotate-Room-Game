using UnityEngine;

public class HandlePasswordPanel : MonoBehaviour
{
  public GamePlayState state;
  public string color;
  public Material material;
  public Material black;

  void OnMouseDown()
  {
    if (state.placedInRavi && state.passwordCorrect == false)
    {
      state.press(color);
    }
  }

  public void turnOn()
  {
    gameObject.GetComponent<MeshRenderer>().material = material;
  }

  public void turnOff()
  {
    gameObject.GetComponent<MeshRenderer>().material = black;
  }
}
