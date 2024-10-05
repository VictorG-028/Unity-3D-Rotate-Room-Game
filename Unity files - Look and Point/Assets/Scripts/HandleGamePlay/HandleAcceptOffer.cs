using UnityEngine;

public class HandleAcceptOffer : MonoBehaviour
{
  public bool canClick = true;
  public Material black;
  public Material green;
  public Animator animatorPanel_1;
  public Animator animatorPanel_2;
  public Animator pistom;
  public BoxCollider machine;

  public GameObject monitor;
  public GameObject monitor2;

  // ------------- //

  int i = 0;

  void OnMouseDown()
  {
    if (canClick)
    {
      // Muda imagem do monitor
      // Abre paineis == Recebe pacote na mesa de trabalho
      // Habilita interagir com máquina quebrada
      // Muda sua cor para cinza
      // Desabilita possibilidade de clicar
      if (i == 0)
      {
        //

        animatorPanel_1.SetTrigger("open");
        animatorPanel_2.SetTrigger("open");
        pistom.SetTrigger("lift");

        gameObject.GetComponent<MeshRenderer>().material = black;

        machine.enabled = true;

        canClick = false;
        i = 1;
      }
      else if (i == 1)
      {
        // gameObject.GetComponent<MeshRenderer>().material = green;
        gameObject.GetComponent<MeshRenderer>().material = black;

        // Muda imagem do monitor para imagem final
        monitor.GetComponent<SpriteRenderer>().enabled = false;
        monitor2.GetComponent<SpriteRenderer>().enabled = true;

        canClick = false;
        i = 2;
      }

      // Destroy(this);
    }
  }
}
