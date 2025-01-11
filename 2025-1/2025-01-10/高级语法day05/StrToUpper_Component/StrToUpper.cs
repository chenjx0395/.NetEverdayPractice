using System.Windows.Forms;
using Notepad_Component_Rlue;

namespace StrToUpper_Component
{
    public class StrToUpper : IComponentRule
    {
        public string Name => "转大写";

        public void ChangeText(TextBox textBox)
        {
            textBox.Text = textBox.Text.ToUpper();
        }
    }
}
