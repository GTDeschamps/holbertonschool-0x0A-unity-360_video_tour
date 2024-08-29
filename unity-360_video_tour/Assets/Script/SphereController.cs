using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System;

public class SphereController : MonoBehaviour
{
	public GameObject[] spheres; // Tableau des GameObjects pour chaque sphère
	public GameObject xrOrigin; // Référence à la caméra XR
	public Animator fadeAnim;

	private int currentSphereIndex = 0; // Indice de la sphère actuelle

	// Méthode à appeler pour changer de sphère par nom
	public void ChangeSphereByName(string sphereName)
	{

		// Imprimer les noms des sphères pour déboguer
		foreach (GameObject sphere in spheres)
		{
		}

		// Trouver l'index de la sphère par son nom
		for (int i = 0; i < spheres.Length; i++)
		{
			if (spheres[i].name.Equals(sphereName, StringComparison.OrdinalIgnoreCase)) // Comparaison insensible à la casse
			{
				StartCoroutine(TransitionToSphere(i));
				return; // Sortir de la méthode après avoir trouvé la sphère
			}
		}
	}

	private IEnumerator TransitionToSphere(int index)
	{
		Debug.Log($"Transition vers la sphère à l'index : {index}");

		// Désactiver la sphère courante et arrêter la vidéo
		Debug.Log($"Désactivation de la sphère courante à l'index : {currentSphereIndex}");
		spheres[currentSphereIndex].SetActive(false);
		VideoPlayer currentVideoPlayer = spheres[currentSphereIndex].GetComponent<VideoPlayer>();
		currentVideoPlayer.Stop();

		// Lancer le fondu enchainé
		   fadeAnim.SetTrigger("FadeIn");
		   Debug.Log($"lancement du fondu enchainé");
		   yield return new WaitForSeconds(1f);

		// Activer la nouvelle sphère
		spheres[index].SetActive(true);
		VideoPlayer newVideoPlayer = spheres[index].GetComponent<VideoPlayer>();
		newVideoPlayer.Play(); // Lancer la vidéo de la sphère activée


		// Déplacer la caméra au centre de la nouvelle sphère
		xrOrigin.transform.position = spheres[index].transform.position;

		// Mettre à jour l'indice de la sphère actuelle
		currentSphereIndex = index;
	}
}
