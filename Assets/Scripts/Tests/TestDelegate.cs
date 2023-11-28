using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDelegate : MonoBehaviour
{
    public delegate void DelegateExample();
   
    void Start()
    {
        FooBar(printTest);   
    }

    // Update is called once per frame
    public void FooBar(DelegateExample del)
    {
        del();
    }
    public void printTest()
    {
        Debug.Log("Test");
    }
}

