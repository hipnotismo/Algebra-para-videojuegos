using CustomMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicios : MonoBehaviour
{
    [SerializeField, Range(1, 10)] int exerciseIndex = 1;
    [SerializeField] Vector3 vectorA;
    [SerializeField] Vector3 vectorB;

    Vec3 vecA = Vec3.Zero;
    Vec3 vecB = Vec3.Zero;
    Vec3 vecC = Vec3.Zero;

    private float time = 0;
    private const int timeLimit = 10;

    void Start()
    {
        MathDebbuger.Vector3Debugger.AddVector(transform.position, transform.position + vecA, Color.red, "VectorA");
        MathDebbuger.Vector3Debugger.AddVector(transform.position, transform.position + vecB, Color.green, "VectorB");
        MathDebbuger.Vector3Debugger.AddVector(transform.position, transform.position + vecC, Color.blue, "VectorC");
        MathDebbuger.Vector3Debugger.EnableEditorView();
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            vecA = new Vec3(vectorA);
            vecB = new Vec3(vectorB);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (exerciseIndex)
        {
            case 1: // Suma de vectores
                vecC = vecA + vecB;
                break;
            case 2:
                vecC = vecB - vecA; // Diferencia de vectores
                break;
            case 3:
                vecC = new Vec3(vecA.x * vecB.x, vecA.y * vecB.y, vecA.z * vecB.z); // Multiplicacion de vectores
                break;
            case 4:
                vecC = -Vec3.Cross(vecA, vecB); // Producto cruz invertido
                break;
            case 5:
                time = time > 1 ? 0 : time + Time.deltaTime;

                vecC = Vec3.Lerp(vecA, vecB, time); break;
            case 6:
                vecC = Vec3.Max(vecA, vecB);
                break;
            case 7:
                vecC = Vec3.Project(vecA, vecB);
                break;
            case 8:
                vecC = new Vec3((vecA + vecB).normalized) * Vec3.Distance(vecA, vecB);
                break;
            case 9:
                vecC = Vec3.Reflect(vecA, new Vec3(vecB.normalized));
                break; 
            case 10:
                time = time > timeLimit ? 0 : time + Time.deltaTime;

                vecC = Vec3.LerpUnclamped(vecA, vecB, time);
                break;
        }

        MathDebbuger.Vector3Debugger.UpdatePosition("VectorA", transform.position, transform.position + vecA);
        MathDebbuger.Vector3Debugger.UpdatePosition("VectorB", transform.position, transform.position + vecB);
        MathDebbuger.Vector3Debugger.UpdatePosition("VectorC", transform.position, transform.position + vecC);
    }
}
