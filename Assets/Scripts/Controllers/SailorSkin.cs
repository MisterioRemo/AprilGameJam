using UnityEngine;

namespace aprilJam
{
  public class SailorSkin : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private GameObject greekSkin;
    [SerializeField] private GameObject vikingSkin;
    [SerializeField] private GameObject frenchmanSkin;

    [SerializeField] private GameObject swords;
    [SerializeField] private GameObject horns;
    [SerializeField] private GameObject parrot;
    #endregion

    #region PROPERTIES
    [field:SerializeField] public Nationality SailorNationality { get; private set; }
    [field:SerializeField] public Profession  SailorProfession  { get; private set; }
    #endregion

#if UNITY_EDITOR
    private void OnValidate()
    {
      ChangeSkin(SailorNationality);
    }
#endif

    #region LIFECYCLE
    private void Awake()
    {
      ChangeSkin(GameState.Instance.SailorNationality);
      ChooseProfession();
    }
    #endregion

    #region METHODS
    private void ChooseProfession()
    {
      SailorProfession = GameState.Instance.CanBeAnyProfession
                           ? (Profession)Random.Range(0, 4)
                           : Profession.Sailor;
    }
    #endregion

    #region INTERFACE
    public void ChangeSkin(Nationality _type)
    {
      greekSkin.SetActive(false);
      vikingSkin.SetActive(false);
      frenchmanSkin.SetActive(false);

      if (_type == Nationality.Greek)
        greekSkin.SetActive(true);
      else if (_type == Nationality.Viking)
        vikingSkin.SetActive(true);
      else if (_type == Nationality.Frenchman)
        frenchmanSkin.SetActive(true);
    }

    public void SetProfessionAttribute()
    {
      if (SailorProfession == Profession.Devil)
        horns.SetActive(true);
      else if (SailorProfession == Profession.Witcher)
        swords.SetActive(true);
      else if (SailorProfession == Profession.Pirat)
        parrot.SetActive(true);
    }
    #endregion
  }
}
