using UnityEngine;

public class DisplaySystem : MonoBehaviour
{

  public GameObject[] allSceneObjects;

  public void disableAllRenderers()
  {
    // Coloca todos os objetos invisíveis
    foreach (GameObject obj in allSceneObjects)
    {
      MeshRenderer m = obj.GetComponent<MeshRenderer>();
      m.enabled = false;
    }
  }

  // public void disableAllColliders()
  // {
  //   // Coloca todos os objetos invisíveis
  //   foreach (GameObject obj in allSceneObjects)
  //   {
  //     BoxCollider c = obj.GetComponent<BoxCollider>();
  //     c.enabled = false;
  //   }
  // }

  public void DisplayOnlyActiveGroups(Vector2 activeGroups)
  {
    // print($"active groups: {activeGroups}");
    int currentID;
    foreach (GameObject obj in allSceneObjects)
    {
      currentID = obj.GetComponent<Group>().groupID;
      MeshRenderer m = obj.GetComponent<MeshRenderer>();
      BoxCollider b = obj.GetComponent<BoxCollider>();
      DisableBoxDisplay dbd = obj.GetComponent<DisableBoxDisplay>();

      if (currentID == (int)activeGroups[0] ||
          currentID == (int)activeGroups[1])
      {
        // print($"current obj -> {obj} -> is active in group {currentID}");
        m.enabled = true;
        if (b != null && (dbd == null || dbd.disabled == false)) { b.enabled = true; }
      }
      else
      {
        m.enabled = false;
        if (b != null) { b.enabled = false; }
      }
    }
  }
}
