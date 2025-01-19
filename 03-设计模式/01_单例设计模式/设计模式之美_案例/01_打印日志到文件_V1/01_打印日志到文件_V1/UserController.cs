namespace _01_打印日志到文件_V1
{
    /// <summary>
    /// 用户相关操作
    /// </summary>
    public class UserService
    {
        private readonly Logger _logger = new Logger();
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