using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button button;
    private MyPlanetsCreator m_Creator;
    [SerializeField] private GraphExecuter graphExecuter;

    private void Start()
    {
        button=GetComponent<Button>();
        m_Creator= GetComponent<MyPlanetsCreator>();
        button.onClick.AddListener(() => graphExecuter.MarkRoute(m_Creator.PlanetName));
    }
}