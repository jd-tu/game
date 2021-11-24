using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void OpenChannel()
	{
		#if !UNITY_EDITOR
		openWindow("https://jd-tu.github.io/game/");
		#endif
	}


	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}