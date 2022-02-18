public class GetDestroyTimeService : IGetDestroyTimeService
{

    public float GetTimeX(float startTime)
    {
        if (startTime < 1)
        {
            return 0.25f;
        }
        if (startTime < 2)
        {
            return 0.5f;
        }
        if (startTime < 3)
        {
            return 0.75f;
        }
        if (startTime < 4)
        {
            return 1f;
        }

        return 1.2f;
    }
    
}