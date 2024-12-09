Random random = new Random();
int luck = random.Next(100);

string[] text = { "你有很多事要做", "今天是", "无论你做什么工作", "这是一个理想的时间" };
string[] good = { "期待.", "尝试新事物！", "很可能会成功。", "实现你的梦想！" };
string[] bad = { "害怕.", "避免重大决策。", "可能会有意想不到的结果。", "重新评估你的生活。" };
string[] neutral = { "欣赏。", "与朋友共度时光.", "应该与你的价值观保持一致.", "与自然和谐相处." };
TellFortune();
void TellFortune()
{
    Console.WriteLine("一位算命师低声说了以下几句话:");
    string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
    for (int i = 0; i < 4; i++)
    {
        Console.Write($"{text[i]} {fortune[i]} ");
    }
}