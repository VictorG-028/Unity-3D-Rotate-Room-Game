using UnityEngine;

public class HandleRepairPiece : MonoBehaviour
{
  public GamePlayState state;

  // ---

  // void Update()
  // {
  //   if (state.repairOnHand)
  //   {

  //   }
  // }

  void OnMouseDown()
  {
    state.repairOnHand = true;

    gameObject.transform.position = new Vector3(0, -50.0f, 0);
  }
}
