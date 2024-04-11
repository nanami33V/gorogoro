using UnityEngine;

public class HowToPlay : MonoBehaviour
{
	public GameObject Play;
	public GameObject Sett;
    private void Start()
    {
		Play.SetActive(false);
	}
    void OnMouseOver()
    {
		if(Sett.activeSelf==false) Play.SetActive(true);
	}
	
	void OnMouseExit()
	{
		Play.SetActive(false);
	}
}
