using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuskaricLyricCollections;
using System.Xml.Serialization;
using System.IO;

namespace PuskaricLyricCollection
{
    public partial class MyLyricForm : Form
    {
        List<SongInfo> songLib = new List<SongInfo>();
        BindingList<SongInfo> bindingSongLib;

        public MyLyricForm()
        {
            InitializeComponent();
            bindingSongLib = new BindingList<SongInfo>(songLib);
            bindingSongLib.RaiseListChangedEvents = true;
            bindingSongLib.AllowNew = true;
            bindingSongLib.AllowEdit = true;

            listBox1.DataSource = bindingSongLib;
            listBox1.DisplayMember = "Name";

            comboBox1.DataSource = Enum.GetValues(typeof(Genre)); // fix
        }

        private void MyLyricForm_Load(object sender, EventArgs e)
        {

        }

        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer s = new XmlSerializer(songLib.GetType());
                using (TextWriter w = new StreamWriter(saveFileDialog.FileName))
                {
                    s.Serialize(w, songLib);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            SongInfo selectedSong = listBox1.SelectedItem as SongInfo;
            if(selectedSong != null)
            {
                selectedSong.Name = textBox1.Text;
                selectedSong.Artist = textBox2.Text;
                selectedSong.Genre = (Genre) comboBox1.SelectedIndex;
                selectedSong.Year = (int) numericUpDown1.Value;
                selectedSong.Duration = textBox3.Text;
                selectedSong.Lyrics = richTextBox1.Rtf;
                bindingSongLib.ResetItem(index);

            }

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SongInfo song = (SongInfo)this.listBox1.SelectedItem;
            if(song != null)
            {
                textBox1.Text = song.Name;
                textBox2.Text = song.Artist;
                comboBox1.SelectedIndex = (int)song.Genre;
                numericUpDown1.Value = song.Year;
                textBox3.Text = song.Duration;
                richTextBox1.Rtf = song.Lyrics;
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Lyrics_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer s = new XmlSerializer(songLib.GetType());
                using (TextReader reader = new StreamReader(openFileDialog.FileName))
                {
                    List<SongInfo> newSongs = (List<SongInfo>)s.Deserialize(reader);
                    foreach (SongInfo song in newSongs)
                        bindingSongLib.Add(song);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newSongToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SongInfo newSong = new SongInfo();
            bindingSongLib.Add(newSong);
            listBox1.SetSelected(songLib.Count - 1, true);
        }

    }
}
