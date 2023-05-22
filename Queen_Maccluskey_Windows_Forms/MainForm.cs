using Queen_Maccluskey_Windows_Forms.Services;

namespace Queen_Maccluskey_Windows_Forms
{
    public partial class MainForm : Form
    {
        QuinMaccluskeyAlgorithm mq = new();
        public MainForm()
        {
            InitializeComponent();
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            int numberOfVaribles = Convert.ToInt32(this.variableNumericUpDown.Value);
            var result = mq.MQCalculator(this.MintermsTextBox.Text, this.DontCaresTextBox.Text, numberOfVaribles);
            this.ResultTextBox.Text = result.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}