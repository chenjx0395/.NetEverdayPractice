namespace _01_打印日志到文件_V1
{
    /// <summary>
    /// 实现 Logger 类，它能将日志打印到文件中，文件位置为项目根目录
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new User() { Id = 1, Name = "张三" };
            var order = new Order() { Id = 1, Name = "买电脑" };
            var userService = new UserService();
            var orderService = new OrderService();
            //模拟用户登录与创建订单操作
            userService.UserLogin(user);
            orderService.CreateOrder(order);

            
        }
    }
}
