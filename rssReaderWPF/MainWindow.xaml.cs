using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace rssReaderWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something didn't quite work correctly: {0}", e.Message);
            }
            finally
            {
            
            }
        }

        string[,] rssData = null;

        private String[,] getRssData(String channel)
        {
            try
            {
                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(channel);
                System.Net.WebResponse myResponse = myRequest.GetResponse();

                System.IO.Stream rssStream = myResponse.GetResponseStream();
                System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();

                rssDoc.Load(rssStream);

                System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

                string[,] tempRssData = new string[200, 3];

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
            catch (Exception e)
            {
                descriptionTextBox.Text = "Something didn't quite work correctly with WebRequest: " + e.Message;
                return null;
            }
            finally
            {
            
            }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                titlesListBox.Items.Clear();
                
                rssData = getRssData(channelTextBox.Text);
                for (int i = 0; i < rssData.GetLength(0); i++)
                {
                    if (rssData[i, 0] != null)
                    {
                        rssData[i, 0] = rssData[i, 0].Trim();
                        titlesListBox.Items.Add(rssData[i, 0]);
                    }
                    titlesListBox.SelectedIndex = 0;
                }

            }
            catch (Exception f)
            {
                descriptionTextBox.Text = "Something didn't quite work correctly with refreshButton: " + f.Message;
            }
            finally
            {
                // Perform any cleanup to roll back the data or close connections
                // to files, database, network, etc.
            }
        }

        private void titlesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            savedLabel.Content = "";
            if (rssData[titlesListBox.SelectedIndex, 1] != null || titlesListBox.SelectedIndex == -1)
            {
                string text = rssData[titlesListBox.SelectedIndex, 1];

                descriptionTextBox.Text = text;
            }
            if (rssData[titlesListBox.SelectedIndex, 2] != null)
                textBlock.Text = "Go to: " + rssData[titlesListBox.SelectedIndex, 0];
        }

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (rssData[titlesListBox.SelectedIndex, 2] != null)
                    System.Diagnostics.Process.Start(rssData[titlesListBox.SelectedIndex, 2]);
            }
            catch (Exception f)
            {
                descriptionTextBox.Text = "Something didn't quite work correctly: " + f.Message;
            }
            finally
            {
                // Perform any cleanup to roll back the data or close connections
                // to files, database, network, etc.
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (descriptionTextBox.Text.Length == 0) savedLabel.Content = "Nothing to save";
                else
                {
                    string title = titlesListBox.SelectedItem.ToString();
                    string text = descriptionTextBox.Text;

                    title = title.Replace(":", "_");
                    title = title.Replace("?", "_");
                    title = title.Trim();

                    StreamWriter targetFile = new StreamWriter("saved/" + title + ".txt");
                    targetFile.Write(text);
                    targetFile.Close();
                    savedLabel.Content = "Saved";
                }
            }
            catch (Exception f)
            {
                descriptionTextBox.Text = "Something didn't quite work correctly: " + f.Message;
            }
            finally
            {
                // Perform any cleanup to roll back the data or close connections
                // to files, database, network, etc.
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            favoriteComboBox.Items.Add(channelTextBox.Text);

            string favTitle = channelTextBox.Text;
            
            File.AppendAllText("fav.txt", favTitle);
        }

        private void favoriteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (favoriteComboBox.SelectedItem != null) channelTextBox.Text = favoriteComboBox.SelectedItem.ToString();
        }

        private void channelTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            channelTextBox.Text = "";
        }

        private void favoriteComboBox_Initialized(object sender, EventArgs e)
        {
            try
            {
                favoriteComboBox.Items.Clear();

                StreamReader File = new StreamReader("fav.txt");
               
                string line;

                while((line = File.ReadLine()) != null)
                {
                    favoriteComboBox.Items.Add(line);
                }
                File.Close();
            }
            catch (Exception f)
            {
                descriptionTextBox.Text = "Something didn't quite work correctly with refreshButton: " + f.Message;
            }
            finally
            {
                // Perform any cleanup to roll back the data or close connections
                // to files, database, network, etc.
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            string line = null;
            string line_to_delete = "the line i want to delete";

            if (favoriteComboBox.SelectedItem != null) line_to_delete = favoriteComboBox.SelectedItem.ToString();
            if (favoriteComboBox.SelectedItem != null) favoriteComboBox.Items.RemoveAt(favoriteComboBox.SelectedIndex);

            if (File.Exists(@"copy.txt"))
            {
                File.Delete(@"copy.txt");
            }
            File.Copy(@"fav.txt", @"copy.txt");

            using (StreamReader reader = new StreamReader("copy.txt"))
            {
                using (StreamWriter writer = new StreamWriter("fav.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, line_to_delete) == 0)
                            continue;
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
