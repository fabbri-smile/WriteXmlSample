namespace WriteXmlSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsXmlWriter XmlWriter = new clsXmlWriter();

            XmlWriter.WriteXml(@".\test_data.xml");
        }
    }
}