using UnityEngine;

public class PanelShowController : MonoBehaviour
{
    public void ShowPanel(GameObject panelTemp)
    {
        if (panelTemp.activeSelf)
        {
            panelTemp.SetActive(false);
        }
        else
        {
            panelTemp.SetActive(true);
        }
    }
}
