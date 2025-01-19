namespace _02_打印日志到文件_V2
{
    /// <summary>
    /// 订单相关类
    /// </summary>
    public class OrderService
    {
        private readonly Logger _logger = Logger.GetInstance();

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(Order order)
        {
            // 创建订单……
            _logger.WriteLog($@"创建了一个订单:{order.Id}");
        }


    }

    /// <summary>
    /// 订单类
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}