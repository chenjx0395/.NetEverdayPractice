using System.Threading;

namespace _02_ID生成器_V1
{
    public class IdGenerator
    {
        private int _count;
        private static readonly IdGenerator Instance = new IdGenerator();
        private IdGenerator()
        {

        }
        public static IdGenerator GetInstance()
        {
            return Instance;
        }
        public int GetId()
        {
            // return _count++;
            return Interlocked.Increment(ref _count);
        }
    }
}