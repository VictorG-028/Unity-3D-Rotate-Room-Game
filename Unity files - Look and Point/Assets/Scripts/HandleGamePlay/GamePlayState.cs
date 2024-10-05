using UnityEngine;


public class GamePlayState : MonoBehaviour
{
  public bool removedBrokenMemoryCard = false;
  public bool repairOnHand = false;
  public bool placedInRavi = false;
  public bool repairPieceHaveNewFirmWare = false;
  public bool repairPieceisReady = false;
  public bool passwordCorrect = false;

  private string[] password = { "Yellow", "Green", "Blue", "Red" };
  private int i = 0;

  public void press(string s)
  {

    if (i < 4 && password[i] == s)
    {
      print(password[i]);
      i += 1;
    }
    else
    {
      print("Reset password");
      i = 0;
    }

    if (i == 4)
    {
      passwordCorrect = true;
      repairPieceHaveNewFirmWare = true;
      print("Password accepted!");
    }

  }
}
