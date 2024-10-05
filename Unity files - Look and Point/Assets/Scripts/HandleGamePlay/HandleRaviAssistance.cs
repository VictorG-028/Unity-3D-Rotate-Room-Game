using UnityEngine;

public class HandleRaviAssistance : MonoBehaviour
{
  public GamePlayState state;
  public GameObject memoryCard;
  public GameObject[] buttons;
  public Transform target;

  void OnMouseDown()
  {
    if (state.repairOnHand)
    {
      state.repairOnHand = false;

      memoryCard.transform.position = target.position;
      memoryCard.transform.rotation = target.rotation;

      foreach (GameObject button in buttons)
      {
        button.GetComponent<HandlePasswordPanel>().turnOn();
      }

      state.placedInRavi = true;
    }
    else if (state.repairPieceHaveNewFirmWare)
    {
      state.repairOnHand = true;

      memoryCard.transform.position = new Vector3(0, -50f, 0);

      foreach (GameObject button in buttons)
      {
        button.GetComponent<HandlePasswordPanel>().turnOff();
      }
    }
  }
}
