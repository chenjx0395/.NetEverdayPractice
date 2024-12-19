namespace polymorphicExer01
{
  public  class Circle : Shape
  {
    public double radius { get; set; }
    public override string name { get; } = "圆形";

    public Circle(double radius){
      this.radius = radius;
    }
    
    public override  void draw(){
      Console.WriteLine($"绘图中，绘制了一个半径 {radius} 的{name}");
    }
  }
}