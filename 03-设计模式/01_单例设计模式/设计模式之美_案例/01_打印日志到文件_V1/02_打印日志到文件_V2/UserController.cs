namespace _02_打印日志到文件_V2
{
    /// <summary>
    /// 用户相关操作
    /// </summary>
    public class UserService
    {
        private readonly Logger _logger = Logger.GetInstance();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        public void UserLogin(User user)
        {
            _logger.WriteLog($"用户 {user.Name} 已登录");
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}