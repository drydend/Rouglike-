using System.Collections.Generic;
using UnityEngine;

public class PowerUPHandler : MonoBehaviour
{
    [SerializeField]
    private PowerUPCreator _upgradeCreator;
    [SerializeField]
    private PowerUPChoiceMenuUI _upgradeChoiceMenu;

    [SerializeField]
    private Player _player;

    private PowerUPBlank _selectedUpgrade;

    private List<CharacterModificator> _currentModificators = new List<CharacterModificator>();

    public bool _playerIsChoosing { get; private set; }

    private void Start()
    {
        _upgradeChoiceMenu.OnConfrimedChoice += ConfrimChoice;
    }

    public void ApplySelectedPowerUp()
    {   
        _currentModificators.Remove(_selectedUpgrade.CurrentModificator);
        
        foreach (var item in _currentModificators)
        {
            _upgradeCreator.AddPowerUp(item);
        }

        _currentModificators.Clear();

        _selectedUpgrade.CurrentModificator.ApplyModificator(_player);

        _selectedUpgrade = null;
        _upgradeChoiceMenu.OnModificatorChoosen();

        _playerIsChoosing = false;
    }
    
    public void ShowPowerUps()
    {
        _playerIsChoosing = true;

        for (int i = 0; i < 3; i++)
        {
            _currentModificators.Add(_upgradeCreator.GetRandomModificator());
        }

        var powerUpsUI = _upgradeChoiceMenu.Show(_currentModificators);

        foreach (var item in powerUpsUI)
        {
            item.OnSelected += OnUpgradeSelected;
        }
    }

    private void OnUpgradeSelected(PowerUPBlank upgradeBlank)
    {
        _selectedUpgrade?.Unselect();
        _selectedUpgrade = upgradeBlank;
    }

    private void ConfrimChoice()
    {
        if(_selectedUpgrade == null)
        {
            return;
        }

        ApplySelectedPowerUp();
    }
}
