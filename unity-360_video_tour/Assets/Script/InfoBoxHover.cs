using UnityEngine;
using UnityEngine.UI;

public class InfoBoxHover : MonoBehaviour
{
     public void  ManageInformations(GameObject information) => information.SetActive(!information.activeSelf);
}
