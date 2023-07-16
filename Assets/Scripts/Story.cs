using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Story : MonoBehaviour
{
    private List<string> Story1;
    private IEnumerator<string> iterator;
    private Canvas canvas;
    void Start()
    {
        Story1 = new List<string>();
        Story1.Add("1");
        Story1.Add("2");
        Story1.Add("3");
        Story1.Add("4");
        Story1.Add("5");
        iterator = Story1.GetEnumerator();
        canvas = this.GetComponent<Canvas>();
    }

    public void OnButtonPress() {
        if (iterator != null) {
            if (iterator.Current == Story1[Story1.Count-1]) {
                iterator.Reset();
            }
            else if (iterator.MoveNext()) {
                Debug.Log(iterator.Current);
            }
        }
    }
}
