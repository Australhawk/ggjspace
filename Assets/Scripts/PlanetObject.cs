using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "Planet", order = 1)]
public class PlanetObject : ScriptableObject {
	public string planetName;
	public float planetRadius;
	public Material material;
	public float planetMass;
}
