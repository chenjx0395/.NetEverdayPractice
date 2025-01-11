using System.Windows.Forms;

namespace Notepad_Component_Rlue
{
    public interface IComponentRule
    {
        string Name { get; }
        void ChangeText(TextBox textBox);
    }
}
