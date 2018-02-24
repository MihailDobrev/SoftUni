
namespace Mordor_s_Cruelty_Plan
{
    public class MoodFactory
    {
        public virtual string SetMood(int happiness)
        {
            return $"{this.GetType().Name}";
        }
    }
}
