using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    [SerializeField] private int totalCoins;
    [SerializeField] private int speedLevel;
    [SerializeField] private int shieldLevel;
    [SerializeField] private int magnetLevel;
    [SerializeField] private int boostLevel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        Save();
        if (UIManager.Instance != null)
        {
            UIManager.Instance.RefreshHUD();
        }
    }

    public bool TryBuyUpgrade(string upgradeName)
    {
        int cost = GetUpgradeCost(upgradeName);
        if (totalCoins < cost)
        {
            return false;
        }

        totalCoins -= cost;

        switch (upgradeName)
        {
            case "Speed":
                speedLevel++;
                break;
            case "Shield":
                shieldLevel++;
                break;
            case "Magnet":
                magnetLevel++;
                break;
            case "Boost":
                boostLevel++;
                break;
        }

        Save();
        if (UIManager.Instance != null)
        {
            UIManager.Instance.RefreshHUD();
        }
        return true;
    }

    public int GetUpgradeCost(string upgradeName)
    {
        switch (upgradeName)
        {
            case "Speed": return 25 + speedLevel * 20;
            case "Shield": return 30 + shieldLevel * 25;
            case "Magnet": return 35 + magnetLevel * 25;
            case "Boost": return 40 + boostLevel * 30;
            default: return 0;
        }
    }

    public int GetTotalCoins() => totalCoins;
    public int GetSpeedLevel() => speedLevel;
    public int GetShieldLevel() => shieldLevel;
    public int GetMagnetLevel() => magnetLevel;
    public int GetBoostLevel() => boostLevel;

    public float GetSpeedMultiplier()
    {
        return 1f + speedLevel * 0.1f;
    }

    public float GetMagnetRange()
    {
        return 1f + magnetLevel * 0.5f;
    }

    public int GetBoostCharges()
    {
        return boostLevel;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("StarFlightCoins", totalCoins);
        PlayerPrefs.SetInt("StarFlightSpeedLevel", speedLevel);
        PlayerPrefs.SetInt("StarFlightShieldLevel", shieldLevel);
        PlayerPrefs.SetInt("StarFlightMagnetLevel", magnetLevel);
        PlayerPrefs.SetInt("StarFlightBoostLevel", boostLevel);
    }

    public void Load()
    {
        totalCoins = PlayerPrefs.GetInt("StarFlightCoins", 0);
        speedLevel = PlayerPrefs.GetInt("StarFlightSpeedLevel", 0);
        shieldLevel = PlayerPrefs.GetInt("StarFlightShieldLevel", 0);
        magnetLevel = PlayerPrefs.GetInt("StarFlightMagnetLevel", 0);
        boostLevel = PlayerPrefs.GetInt("StarFlightBoostLevel", 0);
    }
}
