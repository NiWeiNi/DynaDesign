using System.Windows.Controls;

namespace Controls
{
    public class UserInformation
    {
        private UserInformation() { }

        public static Label CreateLabel(string text)
        {
            Label label = new Label();
            label.Content = text;

            return label;
        }
    }
}
