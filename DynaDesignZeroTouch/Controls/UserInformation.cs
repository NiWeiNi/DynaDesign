using System.Windows.Controls;

namespace Controls
{
    public class UserInformation
    {
        private UserInformation() { }

        public static Label CreateLabel(string text)
        {
            Label label = new Label
            {
                Content = text
            };

            return label;
        }

        public static TextBlock CreateTextBlock(string text)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = text
            };

            return textBlock;
        }
    }
}