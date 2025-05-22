using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        TestOne();
    }

    void TestOne()
    {
        Test2();
    }

    void Test2()
    {
        float a = 0;

        for (int i = 0; i < 10; i++) 
        {
            a++;
            Debug.Log(a);
        }

    }
}
