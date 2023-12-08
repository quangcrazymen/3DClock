using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;

// using System.Numerics;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
	Transform pointPrefab;

    [SerializeField, Range(10, 100)]
	int resolution = 10;

    [SerializeField, Range(0, 1)]
	int function;

    Transform []points;
    void Awake(){
        points = new Transform[resolution];
        float step = 2f / resolution;
        var position = Vector3.zero;
		var scale = Vector3.one * step;
		for (int i = 0; i < resolution; i++) {
			// Transform point = Instantiate(pointPrefab);
			// position.x = (i + 0.5f) * step - 1f;
			// position.y = position.x * position.x * position.x;
            Transform point = points[i] = Instantiate(pointPrefab);
			position.x = (i + 0.5f) * step - 1f;
			point.localPosition = position;
			point.localScale = scale;
            point.SetParent(transform);
            
		}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(2);
        float time = Time.time;
        for (int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			//position.y = position.x * position.x * position.x;
            // Animated sine wave
            //position.y = FunctionLibrary.MultiWave(position.x,time);
            position.y = f(position.x, time);
			point.localPosition = position;
		}
    }
}
