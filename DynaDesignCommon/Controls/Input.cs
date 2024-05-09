using System.Windows.Controls;

namespace Controls
{
    public class Input
    {
        private Input() { }

        public static TextBox CreateTextBox(string text)
        {
            TextBox textBox = new TextBox();
            textBox.Text = text;

            return textBox;
        }
    }
}
