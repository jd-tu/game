using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void OpenChannel()
	{
		#if !UNITY_EDITOR
		openWindow("https://github.com/jd-tu/game");
		#endif
	}


	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}