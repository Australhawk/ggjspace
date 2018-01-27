using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "Planet", order = 1)]
public class PlanetObject : ScriptableObject {
	public string planetName = "Earth";
	public float planetRadius = 0;
	public Texture texture;
	public Texture normalMap;
	public float planetMass = 10;
}
