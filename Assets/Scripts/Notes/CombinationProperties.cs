using System;

namespace aprilJam
{
  public struct CombinationProperties
  {
    public CombinationProperties(Action _action, string _sfxName)
    {
      action  = _action;
      sfxName = _sfxName;
    }

    public readonly Action action;
    public readonly string sfxName;
  }
}
