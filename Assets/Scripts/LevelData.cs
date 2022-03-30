[System.Serializable]
public class LevelData
{
    public int levelScore;
    public int levelStar;
    public bool isComplete;

    public LevelData(Level level)
    {
        if (level == null)
        {
            levelScore = 0;
            levelStar = 0;
            isComplete = false;
        }
        else
        {
            levelScore = level.levelScore;
            levelStar = level.levelStar;
            isComplete = level.isComplete;
        }
    }
}