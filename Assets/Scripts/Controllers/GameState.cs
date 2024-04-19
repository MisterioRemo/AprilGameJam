using System.Collections;
using System.Collections.Generic;
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
    public EndingType Ending     = EndingType.Lonely;
    public int        DeathCount = 0;
    #endregion

    #region PROPERTIES
    public int MaxLifeCount { get; } = 3;
    #endregion
  }
}
