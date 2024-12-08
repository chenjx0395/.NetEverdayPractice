namespace polymorphicExer01
{
  public  class Rectangle : Shape
  {
    public double width { get; set; }
    public double height { get; set; }
    public override string name { get; } = "矩形";

    public Rectangle(double width, double height){
      this.width = width;
      this.height = height;
    }
    
    public override void  draw(){
      Console.WriteLine($"绘图中，绘制了一个宽 {width} 高 {height} 的{name}");
    }
  }
}