using System.Windows.Forms;
using System;

namespace Assignment_1
{
    public partial class InputBoxForm : Form
    {
        public string InputValue => txtInput.Text;

        public InputBoxForm(string prompt)
        {
            InitializeComponent();
            lblPrompt.Text = prompt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }


        private Button btnOK;
        private TextBox txtInput;
        private Label lblPrompt;
    }
}