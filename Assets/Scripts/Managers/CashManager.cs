using UnityEngine;
using UnityEngine.UI;

public class CashManager : MonoBehaviour {

	public static CashManager instance;
	public Text Text;
	private int _cash;

	private void Awake ()
	{
		_cash = 0;
		setCashText();
        
		if (instance == null)
		{
			instance = this;
		}else if (instance != this)
		{
			Destroy(gameObject);
		}
        
	}

	public void addCash(int amount)
	{
		_cash += amount;
		GameControl.instance.addMoney(amount);
		setCashText();
	}

	private void setCashText()
	{
		Text.text = "$ " + _cash;
	}
}
