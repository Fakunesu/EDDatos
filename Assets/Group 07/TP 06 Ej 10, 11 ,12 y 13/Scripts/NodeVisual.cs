using UnityEngine;
using TMPro;

public class NodeVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text data;
    [SerializeField] private LineRenderer leftArrow;
    [SerializeField] private LineRenderer rightArrow;
    
  // public void SetLine()
  // {
  //     leftArrow.SetPosition(0, transform.position);
  // }

    public void SetNode(string value, bool hasLeft, bool hasRight)
    {
        data.text = value;
        leftArrow.gameObject.SetActive(hasLeft);
        rightArrow.gameObject.SetActive(hasRight);
    }
}