using System.Windows.Forms;
using Notepad_Component_Rlue;

namespace StrToLower_Component
{
    public class StrToLower : IComponentRule
    {
        public string Name => "转小写";
        public void ChangeText(TextBox textBox)
        {
            textBox.Text = textBox.Text.ToLower();
        }
    }
}
