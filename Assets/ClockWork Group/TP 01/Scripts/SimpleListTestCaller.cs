using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleListTestCaller : MonoBehaviour
{
    private TextMeshPro tMPro;
    private TestSimpleList TestSimpleList;
    void Start()
    {
        tMPro = GetComponent<TextMeshPro>();
        TestSimpleList = GameObject.FindGameObjectWithTag("Text").GetComponent<TestSimpleList>();
    }

    public void Hola()
    {
        tMPro.text = TestSimpleList.list.ToString();
    }
    void Update()
    {
        // tMPro.text=TestSimpleList.list.ToString();
    }
}
