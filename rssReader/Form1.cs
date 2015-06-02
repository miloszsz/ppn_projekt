using System;
using System.IO;
using System.Windows.Forms;

namespace rssReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[,] rssData = null;

        private String[,] getRssData(String channel)
        {
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

            rssDoc.Load(rssStream);

            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

            string[,] tempRssData = new string[100, 3];

            for (int i = 0; i < rssItems.Count; i++)
            {
                System.Xml.XmlNode rssNode;

                rssNode = rssItems.Item(i).SelectSingleNode("title");
                if (rssNode != null) tempRssData[i, 0] = rssNode.InnerText;
                else tempRssData[i, 0] = "";

                rssNode = rssItems.Item(i).SelectSingleNode("description");
                if (rssItems != null) tempRssData[i, 1] = rssNode.InnerText;
                else tempRssData[i, 1] = "";

                rssNode = rssItems.Item(i).SelectSingleNode("link");
                if (rssNode != null) tempRssData[i, 2] = rssNode.InnerText;
                else tempRssData[i, 2] = "";
            }
            return tempRssData;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            titlesComboBox.Items.Clear();
            rssData = getRssData(channelTextBox.Text);
            for (int i = 0; i < rssData.GetLength(0); i++)
            {
                if (rssData[i, 0] != null) titlesComboBox.Items.Add(rssData[i, 0]);
                titlesComboBox.SelectedIndex = 0;
            }
        }

        private void titlesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            savedLabel.Text = "";
            if (rssData[titlesComboBox.SelectedIndex, 1] != null)
                descriptionTextBox.Text = rssData[titlesComboBox.SelectedIndex, 1];
            if (rssData[titlesComboBox.SelectedIndex, 2] != null)
                linkLabel.Text = "Go to:" + rssData[titlesComboBox.SelectedIndex, 0];
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rssData[titlesComboBox.SelectedIndex, 2] != null)
                System.Diagnostics.Process.Start(rssData[titlesComboBox.SelectedIndex, 2]);
        }

        private void channelTextBox_Click(object sender, EventArgs e)
        {

        }

        private void channelTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void channelTextBox_Enter(object sender, EventArgs e)
        {
            channelTextBox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string title = titlesComboBox.Text;
            string text = descriptionTextBox.Text;

            title = title.Replace(":","_");
            title = title.Replace("?", "_");

            StreamWriter targetFile = new StreamWriter(title + ".txt");

            targetFile.Write(text);
      
            targetFile.Close();

            savedLabel.Text = "Saved";
        }
    }
}
