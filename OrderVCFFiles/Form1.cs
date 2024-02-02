using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderVCFFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string file = FileString.OpenAs("Select the VCF file", "*.vcf|*.vcf");
            if (System.IO.File.Exists(file) == false) { return; }

            string newName = file.Substring(0, file.Length - 4) + "_sorted.vcf";

            System.IO.StreamReader fs = null;
            System.IO.StreamWriter fw = null;

            try
            {
                fs = new System.IO.StreamReader(file);
                fw = new System.IO.StreamWriter(newName);

                string line = "";

                List<string> hashs = new List<string>();

                bool done = false;
                while (fs.Peek() > 0 && done== false)
                {
                    line = fs.ReadLine();
                    if (line.StartsWith("##contig=<ID=") == true)
                    {
                        hashs.Add(line);
                    }                    
                    else if (line.StartsWith("#CHROM") == true)
                    { done = true; }
                }
                fs.Close();

                hashs.Sort(new HashLineSorter());

                fs = new System.IO.StreamReader(file);

                done = false;
                bool added = false;
                while (fs.Peek() > 0 && done == false)
                {
                    line = fs.ReadLine();
                    if (line.StartsWith("##contig=<ID=") == true && added==false)
                    {
                        added = true;
                        foreach (string s in hashs)
                        {
                            fw.Write(s + "\n");
                        }
                    }
                    else if (line.StartsWith("##") && line.StartsWith("##contig=<ID=") == false)
                    {
                        fw.Write(line + "\n");
                    }
                    else if (line.StartsWith("#CHROM") == true)
                    {
                        fw.Write(line + "\n");
                        done = true; 
                    }
                }

                Dictionary<string, List<string> > chromosomes = new Dictionary<string, List<string> >();
                foreach (string s in hashs)
                {
                    int index = s.IndexOf(",");
                    string name = s.Substring(13, index - 13);
                    chromosomes.Add(name, new List<string>());
                }

                string[] items = null;
                while (fs.Peek() > 0)
                {
                    line = fs.ReadLine();
                    items = line.Split('\t');
                    if (chromosomes.ContainsKey(items[0]) == true)
                    {
                        chromosomes[items[0]].Add(line);
                    }
                }

                LineSorter ls = new LineSorter();
                foreach (List<string> v in chromosomes.Values)
                {
                    v.Sort(ls);
                }

                foreach (string c in hashs)
                {
                    int index = c.IndexOf(",");
                    string k = c.Substring(13, index - 13);

                    if (chromosomes.ContainsKey(k))
                    {
                        foreach(string l in chromosomes[k])
                        {
                            fw.Write(l + "\n");
                        }
                    }
                }

            }
            catch(System.IO.IOException ex)
            { MessageBox.Show("Could open and read the files"); }
            catch (Exception ex){ MessageBox.Show("An error occured: " + ex.Message); }
            finally
            {
                if (fw != null) { fw.Close(); }
                if (fs != null) { fs.Close(); }
            }

        }
    }
}
