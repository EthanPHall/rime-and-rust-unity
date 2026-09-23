using UnityEngine;

public interface SurvivorSink
{
    public int GetNumberOfAttachedSurvivors();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="amount">The amoutn of survivors to attach to this sink</param>
    /// <returns>The number that were actually attached</returns>
    public int TryToAttachSurvivors(int amount);
}
