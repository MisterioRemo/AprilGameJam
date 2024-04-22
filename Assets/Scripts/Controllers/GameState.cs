using UnityEngine;

namespace aprilJam
{
  public class GameState
  {
    private static GameState instance;

    private GameState() { }

    public static GameState Instance { get { if (instance == null)
                                               instance = new GameState();
                                             return instance;
                                           }
                                     }

    #region PARAMETERS
    private int  deathCount         = 0;
    private bool wereGoodSailorOnce = false;

    public EndingType Ending = EndingType.Lonely;

    public readonly int           MaxLifeCount           = 3;
    public readonly Nationality[] SailorNationalityOrder = new[] { Nationality.Greek, Nationality.Viking, Nationality.Frenchman };
    #endregion

    #region PROPERTIES
    public int         DeathCount { get => deathCount;
                                    set => deathCount = Mathf.Min(value, MaxLifeCount);
                                  }
    public bool        CanBeAnyProfession => (DeathCount == MaxLifeCount - 1 && !wereGoodSailorOnce) ? false : true;
    public Nationality SailorNationality  => SailorNationalityOrder[DeathCount];
    #endregion
  }
}
