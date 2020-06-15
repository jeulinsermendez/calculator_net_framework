using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pt2b
{
    public partial class Form1 : Form
    {
        String filePath;
        public Form1()
        {
            InitializeComponent();
            prepararOpenFileYSaveFile();
        }

        private void SeleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cridarem a un formulari modal amb informació nostre
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            //openFileDialog1 utilitzare

            filePath = string.Empty;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;
                lbMostrar.Items.Add(filePath);


            }



        }

        private void prepararOpenFileYSaveFile()
        {
            //preparo el openFileDialog1 amb les opcions
            openFileDialog1.InitialDirectory = "c:\\"; //primer directori
            openFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;


            //preparo el saveFileDialog1 amb les opcions



        }

        private void LbMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filePath.Contains(".rtf"))
            {
                //MessageBox.Show(lbMostrar.SelectedItem.ToString());
              richTextBox1.LoadFile(lbMostrar.SelectedItem.ToString(),RichTextBoxStreamType.RichText);

            }else if ( filePath.Contains(".txt"))
            {
                richTextBox1.LoadFile(lbMostrar.SelectedItem.ToString(), RichTextBoxStreamType.PlainText);
            }



        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Count() > 0)
            {
                DialogResult result = MessageBox.Show("¿Quieres guardar?", "Guardar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (saveFileDialog1.Filter.Equals(".txt"))
                        {
                            using ( StreamWriter sr = new StreamWriter(saveFileDialog1.FileName + "txt"))
                            {
                                sr.Write(richTextBox1.Text);
                            }
                        }
                        else
                        {
                            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                        }
                    }

                    richTextBox1.Clear();
                }
                else if (result == DialogResult.No)
                {
                    richTextBox1.Clear();
                }

            }
            else
            {

                richTextBox1.Clear();
            }





        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                if (filePath.Contains(".txt")| filePath.Contains(".rtf"))
                {
                    richTextBox1.LoadFile(filePath);

                   /* using (StreamReader sr = new StreamReader(filePath))
                    {
                        richTextBox1.Text = sr.ReadToEnd();

                    }*/
                }
              /*  else
                {
                    richTextBox1.LoadFile(filePath);
                }*/
            }

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //salvamos el documento
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
            
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void cortarCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();

        }

        private void copiarCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();

        }

        private void pegarCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

       
       
       

       

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Count() > 0)
            {

                DialogResult result = MessageBox.Show("¿Quieres guardar?", "Guardar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);

                    }

                    this.Close();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }

            }
            else
            {

                this.Close();
            }




        }


        //l'opcio Font del menu contextual
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fontContextMenu();
        }

        private void ColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            colorContextMenu();
        }

        private void fontContextMenu()
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                //este cambia todo el texto  richTextBox1.Font = fontDialog1.Font;
                //este cambia solo el texto seleccionado
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }
        private void colorContextMenu()
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }

        }
    }
    }

