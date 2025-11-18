using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_menu;
    [SerializeField]
    GameObject m_options;

    private void Start()
    {
        m_options.SetActive(false);
    }

    public void openMenu()
    {
        m_options.SetActive(true);
    }

    public void closeMenu()
    {
        m_options.SetActive(false);
    }
}
