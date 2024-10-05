using UnityEngine;

public class HandleBrokenMachine : MonoBehaviour
{
  public GamePlayState state;
  public GameObject memoryCard;
  public GameObject brokenPart;
  public Transform target;
  public GameObject finishButton;
  public Material green;
  public GameObject machineLight;
  public Material neonBlue;

  void OnMouseDown()
  {
    if (state.removedBrokenMemoryCard == false)
    {
      state.removedBrokenMemoryCard = true;
      brokenPart.SetActive(false);
      brokenPart.transform.position = new Vector3(0, -100.0f, 0);
    }
    else if (state.repairOnHand && state.repairPieceHaveNewFirmWare)
    {
      memoryCard.transform.position = target.position;
      memoryCard.transform.rotation = target.rotation;

      finishButton.GetComponent<MeshRenderer>().material = green;
      machineLight.GetComponent<MeshRenderer>().material = neonBlue;
      finishButton.GetComponent<HandleAcceptOffer>().canClick = true;
    }
  }
}
