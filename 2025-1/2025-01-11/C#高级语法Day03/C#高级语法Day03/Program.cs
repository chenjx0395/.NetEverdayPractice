using System;
using System.Threading;

namespace C_高级语法Day03
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            var musicPlayer = new MusicPlayer();
            // 事件不能使用赋值的方式绑定方法
            /*
            musicPlayer.BeforeMusicPlays = () =>
            {
                Console.WriteLine("检查音乐是否是会员音乐……");

            };
            musicPlayer.AfterMusicPlays = () =>
            {
                Console.WriteLine("切换音乐……"); 

            };
            // 事件需要使用 += 或 -= 的方式
           */
            musicPlayer.BeforeMusicPlays += () =>
            {
                Console.WriteLine("检查音乐是否是会员音乐……");
            
            };
            musicPlayer.AfterMusicPlays += () =>
            {
                Console.WriteLine("切换音乐……");
            
            };
            // 委托可以调用,事件不行
            // musicPlayer.AfterMusicPlays(); true
            // musicPlayer.AfterMusicPlays(); false
            musicPlayer.Start();
        }

       
    }

    class MusicPlayer
    {
        public event Action BeforeMusicPlays;
        public event Action AfterMusicPlays;

        public MusicPlayer()
        {
            // 可以绑定 null 
            BeforeMusicPlays += null;
            AfterMusicPlays += null;
        }

        // 内部音乐播放方法
        private void Playing()
        {
            Console.WriteLine("音乐播放中……");
        }

        // 音乐播放接口
        public void Start()
        {
           
            Console.WriteLine("准备开始播放音乐");
            /*
             * 播放前可能需要执行一些逻辑
             * 如： 1. 检查音乐是否是VIP音乐
             *      2. 检查用户是否是VIP
             *      3. 加载歌词
             */
            BeforeMusicPlays();
            Playing();
            // 模拟音乐播放过程
            Thread.Sleep(3000);
            Stop();
            /*
             * 播放后可能需要执行一些逻辑
             * 如：1. 添加推荐音乐到播放队列
             *     2. 切换下一首
             */
            AfterMusicPlays();
        }

        // 音乐播放需要执行的逻辑

        private void Stop()
        {
            Console.WriteLine("音乐播放结束");
        }
    }

}
